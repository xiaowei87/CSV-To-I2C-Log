using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_To_I2C_Log
{
    public partial class Form1 : Form
    {
        enum I2C_Status
        {
            Idle,
            StartDetected,
            WaitSCLHigh,
            WaitSCLLow,
            Error
        }

        List<string> listSCL = new List<string>();
        List<string> listSDA = new List<string>();

        string csvpath = "";
        string txtpath = "";

        public Form1()
        {
            InitializeComponent();
        }
        
        private void BtnConvert_Click(object sender, EventArgs e)
        {
            BtnConvert.Enabled = false;
            BtnCancel.Enabled = true;

            bool filecheck;

            csvpath = "";
            txtpath = "";

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "D:\\";
            openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                csvpath = openFileDialog1.FileName;
            }

            filecheck = File.Exists(csvpath);

            if (filecheck)
            {
                txtpath = Path.ChangeExtension(csvpath, "log");

                if (File.Exists(txtpath))
                {
                    DialogResult dialogResult = MessageBox.Show(txtpath + " exists, do you want to replace?", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        using (StreamWriter sw = File.CreateText(txtpath))
                        {
                            sw.WriteLine("");
                        }
                        filecheck = true;
                    }
                    else //if (dialogResult == DialogResult.No)
                    {
                        filecheck = false;
                        MessageBox.Show("Conversion cancelled.", "Info", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(txtpath))
                    {
                        sw.WriteLine("");
                    }
                    filecheck = true;
                }
            }
            else
            {
                MessageBox.Show("Please select valid CSV file.", "Error", MessageBoxButtons.OK);
            }

            if (filecheck)
            {
                if (NumSCL.Value != NumSDA.Value)
                {
                    PbarConvert.Value = 0;
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Column of SCL cannot be same as Column of SDA.", "Error", MessageBoxButtons.OK);
                }
            }
        }

        public void CSV_To_I2C_Log()
        {
            int ColSCL = Decimal.ToInt16(NumSCL.Value);
            int ColSDA = Decimal.ToInt16(NumSDA.Value);

            using (var sr = new StreamReader(csvpath))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(',');

                    if (values.Length < ColSCL)
                    {
                        MessageBox.Show("SCL data stopped unexpectedly @ " + listSCL.Count, "Info", MessageBoxButtons.OK);
                        break;
                    }
                    else if (values.Length < ColSDA)
                    {
                        MessageBox.Show("SDA data stopped unexpectedly @ " + listSDA.Count, "Info", MessageBoxButtons.OK);
                        break;
                    }
                    else
                    {
                        listSCL.Add(values[(ColSCL - 1)]);
                        listSDA.Add(values[(ColSDA - 1)]);
                    }
                }

                if ((listSCL.Count > 1) && (listSDA.Count > 1))
                {
                    I2C_Status i2cStatus = I2C_Status.Idle;
                    int i2cBitPtr = 0;
                    int i2cData = 0;
                    string preSDA = "0";
                    bool timestampcheck = ChkTimestamp.Enabled;
                    double timestamp = 0;
                    int prePrecent = 0;
                    int i;

                    using (StreamWriter sw = File.AppendText(txtpath))
                    {
                        for (i = 1; i < listSCL.Count; i++)
                        {
                            switch (i2cStatus)
                            {
                                case I2C_Status.Idle:
                                    if ((listSCL[i] == "1") && (listSDA[i]) == "1")
                                    {
                                        // Idle
                                    }
                                    else if ((listSCL[i] == "1") && (listSDA[i]) == "0")
                                    {
                                        // Start Bit
                                        i2cStatus = I2C_Status.StartDetected;

                                        if (timestampcheck)
                                        {
                                            timestamp = 0;
                                            if (Rbtn250.Checked)
                                            {
                                                timestamp = i * 3.56 / 1000;
                                            }
                                            else if (Rbtn500.Checked)
                                            {
                                                timestamp = i * 1.78 / 1000;
                                            }
                                            else if (Rbtn1000.Checked)
                                            {
                                                timestamp = i * 0.89 / 1000;
                                            }
                                            sw.Write(timestamp.ToString("0.00") + "ms:");
                                        }
                                        sw.Write("[S] ");
                                    }
                                    else if ((listSCL[i] == "0") && (listSDA[i]) == "1")
                                    {
                                        // Error
                                        i2cStatus = I2C_Status.Error;
                                    }
                                    else if ((listSCL[i] == "0") && (listSDA[i]) == "0")
                                    {
                                        // Error
                                        i2cStatus = I2C_Status.Error;
                                    }
                                    break;
                                case I2C_Status.StartDetected:
                                    if ((listSCL[i] == "0") && (listSDA[i]) == "0")
                                    {
                                        // Ready to wait for data
                                        i2cStatus = I2C_Status.WaitSCLHigh;
                                        i2cBitPtr = 0;
                                        i2cData = 0;
                                    }
                                    break;
                                case I2C_Status.WaitSCLHigh:
                                    if (listSCL[i] == "1")
                                    {
                                        // SCL High, read bit
                                        if (i2cBitPtr < 8) // Bit0-7 Data
                                        {
                                            if (listSDA[i] == "1")
                                            {
                                                i2cData |= (1 << (7 - i2cBitPtr));
                                            }
                                            else
                                            {

                                            }
                                        }
                                        else // Bit8 ACK
                                        {
                                            sw.Write(i2cData.ToString("X2"));

                                            if (listSDA[i] == "0")
                                            {
                                                sw.Write(" ");
                                            }
                                            else
                                            {
                                                sw.Write("?");
                                            }
                                            i2cData = 0;
                                        }
                                        i2cStatus = I2C_Status.WaitSCLLow;
                                        i2cBitPtr++;
                                        preSDA = listSDA[i];
                                    }
                                    break;
                                case I2C_Status.WaitSCLLow:
                                    if (listSCL[i] == "0")
                                    {
                                        i2cStatus = I2C_Status.WaitSCLHigh;

                                        if (i2cBitPtr >= 9)
                                        {
                                            i2cBitPtr = 0;
                                        }
                                    }
                                    else
                                    {
                                        if (preSDA == "0")
                                        {
                                            if (preSDA != listSDA[i])
                                            {
                                                preSDA = listSDA[i];

                                                if (listSDA[i] == "1")
                                                {
                                                    sw.WriteLine("[P]");
                                                    i2cStatus = I2C_Status.Idle;
                                                    i2cBitPtr = 0;
                                                    i2cData = 0;
                                                }
                                            }
                                        }
                                        else if (preSDA == "1")
                                        {
                                            if (preSDA != listSDA[i])
                                            {
                                                preSDA = listSDA[i];

                                                if (listSDA[i] == "0")
                                                {
                                                    sw.Write("[S]");
                                                    i2cStatus = I2C_Status.StartDetected;
                                                    i2cBitPtr = 0;
                                                    i2cData = 0;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case I2C_Status.Error:
                                default:
                                    if ((listSCL[i] == "1") && (listSDA[i]) == "1")
                                    {
                                        // Back to Idle
                                        i2cStatus = I2C_Status.Idle;
                                    }
                                    break;
                            }
                            if ((100 * i / listSCL.Count) > (prePrecent + 2))
                            {
                                prePrecent += 2;
                                backgroundWorker1.ReportProgress(prePrecent);
                            }
                            if (backgroundWorker1.CancellationPending == true)
                            {
                                break;
                            }
                        }
                        if (i < listSCL.Count)
                        {
                            MessageBox.Show("Conversion was cancelled.", "Info", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Conversion is complete.", "Info", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void ChkTimestamp_CheckedChanged(object sender, EventArgs e)
        {
            GrpSamplingRate.Enabled = ChkTimestamp.Checked;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CSV_To_I2C_Log();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PbarConvert.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PbarConvert.Value = 100;
            BtnCancel.Enabled = false;
            BtnConvert.Enabled = true;
        }
    }
}
