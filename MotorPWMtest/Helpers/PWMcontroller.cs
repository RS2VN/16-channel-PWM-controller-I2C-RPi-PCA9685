using System;
using System.Threading.Tasks;
using Windows.Devices.I2c;

namespace MotorPWMtest.Helpers
{
    // PCA9685 16-channel, 12-bit PWM Fm+ I2C-bus LED controller
    class PWMcontroller
    {
        private I2cDevice pwmController;

        public bool NotConnectedMessage = false;

        public async void InitPWMcontroller()
        {
            var settings = new I2cConnectionSettings(PWMC_I2C_ADDRESS);
            settings.BusSpeed = I2cBusSpeed.FastMode;
            var controller = await I2cController.GetDefaultAsync();
            pwmController = controller.GetDevice(settings);
            if (pwmController == null)
            {
                NotConnectedMessage = true;
            }
            byte NoSleepMode1 = 0b00000001;
            byte[] BufNoSleep = new byte[] { MODE1, NoSleepMode1 };
            pwmController.Write(BufNoSleep);
            await Task.Delay(TimeSpan.FromMilliseconds(1));
        }

        public void DisposePwmController()
        {
            if (pwmController != null)
            {
                pwmController.Dispose();
            }
        }

        public void SetPWM(uint channel_0to15, UInt16 startFrom0to4095, UInt16 stopFrom0to4095) // channel 0 -> 15, ON&OFF -> 0 - 4095
        {
            UInt16 ON = startFrom0to4095;
            UInt16 OFF = stopFrom0to4095;

            switch (channel_0to15)
            {
                case 0:
                    WriteLed(LED0_ON_L, LED0_ON_H, LED0_OFF_L, LED0_OFF_H, ON, OFF);
                    break;
                case 1:
                    WriteLed(LED1_ON_L, LED1_ON_H, LED1_OFF_L, LED1_OFF_H, ON, OFF);
                    break;
                case 2:
                    WriteLed(LED2_ON_L, LED2_ON_H, LED2_OFF_L, LED2_OFF_H, ON, OFF);
                    break;
                case 3:
                    WriteLed(LED3_ON_L, LED3_ON_H, LED3_OFF_L, LED3_OFF_H, ON, OFF);
                    break;
                case 4:
                    WriteLed(LED4_ON_L, LED4_ON_H, LED4_OFF_L, LED4_OFF_H, ON, OFF);
                    break;
                case 5:
                    WriteLed(LED5_ON_L, LED5_ON_H, LED5_OFF_L, LED5_OFF_H, ON, OFF);
                    break;
                case 6:
                    WriteLed(LED6_ON_L, LED6_ON_H, LED6_OFF_L, LED6_OFF_H, ON, OFF);
                    break;
                case 7:
                    WriteLed(LED7_ON_L, LED7_ON_H, LED7_OFF_L, LED7_OFF_H, ON, OFF);
                    break;
                case 8:
                    WriteLed(LED8_ON_L, LED8_ON_H, LED8_OFF_L, LED8_OFF_H, ON, OFF);
                    break;
                case 9:
                    WriteLed(LED9_ON_L, LED9_ON_H, LED9_OFF_L, LED9_OFF_H, ON, OFF);
                    break;
                case 10:
                    WriteLed(LED10_ON_L, LED10_ON_H, LED10_OFF_L, LED10_OFF_H, ON, OFF);
                    break;
                case 11:
                    WriteLed(LED11_ON_L, LED11_ON_H, LED11_OFF_L, LED11_OFF_H, ON, OFF);
                    break;
                case 12:
                    WriteLed(LED12_ON_L, LED12_ON_H, LED12_OFF_L, LED12_OFF_H, ON, OFF);
                    break;
                case 13:
                    WriteLed(LED13_ON_L, LED13_ON_H, LED13_OFF_L, LED13_OFF_H, ON, OFF);
                    break;
                case 14:
                    WriteLed(LED14_ON_L, LED14_ON_H, LED14_OFF_L, LED14_OFF_H, ON, OFF);
                    break;
                case 15:
                    WriteLed(LED15_ON_L, LED15_ON_H, LED15_OFF_L, LED15_OFF_H, ON, OFF);
                    break;
                default:
                    break;
            }
        }

        public void SetAllLedPWM(UInt16 startFrom0to4095, UInt16 stopFrom0to4095)
        {
            UInt16 ON = startFrom0to4095;
            UInt16 OFF = stopFrom0to4095;
            WriteLed(ALL_LED_ON_L, ALL_LED_ON_H, ALL_LED_OFF_L, ALL_LED_OFF_H, ON, OFF);
        }

        public void SetPWMFreq(uint Freq24to1526Hz)
        {
            byte val = (byte)(25000000 / (4096 * Freq24to1526Hz));
            byte[] Buf_SetFreq = new byte[] { PRE_SCALE, val };
            pwmController.Write(Buf_SetFreq);
        }

        private void WriteLed(byte LED_ON_L, byte LED_ON_H, byte LED_OFF_L, byte LED_OFF_H, ushort ON, ushort OFF)
        {
            byte ON_L = (byte)ON;
            byte ON_H = (byte)(ON >> 8);
            byte OFF_L = (byte)OFF;
            byte OFF_H = (byte)(OFF >> 8);

            byte[] Buf_ON_L = new byte[] { LED_ON_L, ON_L };
            byte[] Buf_ON_H = new byte[] { LED_ON_H, ON_H };
            byte[] Buf_OFF_L = new byte[] { LED_OFF_L, OFF_L };
            byte[] Buf_OFF_H = new byte[] { LED_OFF_H, OFF_H };

            pwmController.Write(Buf_ON_L);
            pwmController.Write(Buf_ON_H);
            pwmController.Write(Buf_OFF_L);
            pwmController.Write(Buf_OFF_H);
        }

        /***** registers *****/
        private const byte PWMC_I2C_ADDRESS = 0x40;
        private const byte MODE1 = 0x00;
        private const byte MODE2 = 0x01;
        private const byte SUBADR1 = 0x02;
        private const byte SUBADR2 = 0x03;
        private const byte SUBADR3 = 0x04;
        private const byte ALLCALLADR = 0x05;
        private const byte LED0_ON_L = 0x06;
        private const byte LED0_ON_H = 0x07;
        private const byte LED0_OFF_L = 0x08;
        private const byte LED0_OFF_H = 0x09;
        private const byte LED1_ON_L = 0x0A;
        private const byte LED1_ON_H = 0x0B;
        private const byte LED1_OFF_L = 0x0C;
        private const byte LED1_OFF_H = 0x0D;
        private const byte LED2_ON_L = 0x0E;
        private const byte LED2_ON_H = 0x0F;
        private const byte LED2_OFF_L = 0x10;
        private const byte LED2_OFF_H = 0x11;
        private const byte LED3_ON_L = 0x12;
        private const byte LED3_ON_H = 0x13;
        private const byte LED3_OFF_L = 0x14;
        private const byte LED3_OFF_H = 0x15;
        private const byte LED4_ON_L = 0x16;
        private const byte LED4_ON_H = 0x17;
        private const byte LED4_OFF_L = 0x18;
        private const byte LED4_OFF_H = 0x19;
        private const byte LED5_ON_L = 0x1A;
        private const byte LED5_ON_H = 0x1B;
        private const byte LED5_OFF_L = 0x1C;
        private const byte LED5_OFF_H = 0x1D;
        private const byte LED6_ON_L = 0x1E;
        private const byte LED6_ON_H = 0x1F;
        private const byte LED6_OFF_L = 0x20;
        private const byte LED6_OFF_H = 0x21;
        private const byte LED7_ON_L = 0x22;
        private const byte LED7_ON_H = 0x23;
        private const byte LED7_OFF_L = 0x24;
        private const byte LED7_OFF_H = 0x25;
        private const byte LED8_ON_L = 0x26;
        private const byte LED8_ON_H = 0x27;
        private const byte LED8_OFF_L = 0x28;
        private const byte LED8_OFF_H = 0x29;
        private const byte LED9_ON_L = 0x2A;
        private const byte LED9_ON_H = 0x2B;
        private const byte LED9_OFF_L = 0x2C;
        private const byte LED9_OFF_H = 0x2D;
        private const byte LED10_ON_L = 0x2E;
        private const byte LED10_ON_H = 0x2F;
        private const byte LED10_OFF_L = 0x30;
        private const byte LED10_OFF_H = 0x31;
        private const byte LED11_ON_L = 0x32;
        private const byte LED11_ON_H = 0x33;
        private const byte LED11_OFF_L = 0x34;
        private const byte LED11_OFF_H = 0x35;
        private const byte LED12_ON_L = 0x36;
        private const byte LED12_ON_H = 0x37;
        private const byte LED12_OFF_L = 0x38;
        private const byte LED12_OFF_H = 0x39;
        private const byte LED13_ON_L = 0x3A;
        private const byte LED13_ON_H = 0x3B;
        private const byte LED13_OFF_L = 0x3C;
        private const byte LED13_OFF_H = 0x3D;
        private const byte LED14_ON_L = 0x3E;
        private const byte LED14_ON_H = 0x3F;
        private const byte LED14_OFF_L = 0x40;
        private const byte LED14_OFF_H = 0x41;
        private const byte LED15_ON_L = 0x42;
        private const byte LED15_ON_H = 0x43;
        private const byte LED15_OFF_L = 0x44;
        private const byte LED15_OFF_H = 0x45;

        private const byte ALL_LED_ON_L = 0xFA;
        private const byte ALL_LED_ON_H = 0xFB;
        private const byte ALL_LED_OFF_L = 0xFC;
        private const byte ALL_LED_OFF_H = 0xFD;
        private const byte PRE_SCALE = 0xFE;
    }
}
