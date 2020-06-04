# CSV To I2C Log Converter

Some logic analyser software cannot output I2C data in text based log file.
The RAW sampled logic data is big and required logic analyser software to decode I2C protocol.

This [CSV To I2C Log Converter] helps to convert RAW sampled logic data based on I2C protocol to text based log file.
 - Start Bit : [S]
 - ACK       : 8-bit Data ended with ' '
 - NACK      : 8-bit Data ended with '?'
 - Stop Bit  : [P]

Example log:
> 10.33ms:[S] 70 08 [P]
> 10.55ms:[S] 71 00 40?[P]
> 15.34ms:[S] 70 08 [S]71 00 40?[P]

Timestamp can be enabled/disabled.
If timestamp enabled, please select correct Sampling Rate.
Please take note that Sampling Rate should be more than double of I2C speed.
For example, I2C @ 100KHz ==> Sampling Rate should be more than 200KHz.
Note: Accuracy ratio might have to be tuned in source code accordingly.


