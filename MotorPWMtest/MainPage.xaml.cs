using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using MotorPWMtest.Helpers;

namespace MotorPWMtest
{
    /// <summary>
    /// 8 LED PWM control using sliders and PCA9685 16-channel, 12-bit PWM on I2C-bus.
    /// LED connected to channel 4-11.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        PWMcontroller pWMC = new PWMcontroller();
        public MainPage()
        {
            this.InitializeComponent();
            pWMC.InitPWMcontroller();
            pWMC.SetPWMFreq(200);
        }

        private void Slider1_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            UInt16 val = (UInt16)e.NewValue;
            string msg = String.Format("{0}", val);
            TextBlock1.Text = msg;
            pWMC.SetPWM(4, 0, val);
        }

        private void Slider2_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            UInt16 val = (UInt16)e.NewValue;
            string msg = String.Format("{0}", val);
            TextBlock2.Text = msg;
            pWMC.SetPWM(5, 0, val);
        }

        private void Slider3_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            UInt16 val = (UInt16)e.NewValue;
            string msg = String.Format("{0}", val);
            TextBlock3.Text = msg;
            pWMC.SetPWM(6, 0, val);
        }

        private void Slider4_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            UInt16 val = (UInt16)e.NewValue;
            string msg = String.Format("{0}", val);
            TextBlock4.Text = msg;
            pWMC.SetPWM(7, 0, val);
        }

        private void Slider5_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            UInt16 val = (UInt16)e.NewValue;
            string msg = String.Format("{0}", val);
            TextBlock5.Text = msg;
            pWMC.SetPWM(8, 0, val);
        }

        private void Slider6_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            UInt16 val = (UInt16)e.NewValue;
            string msg = String.Format("{0}", val);
            TextBlock6.Text = msg;
            pWMC.SetPWM(9, 0, val);
        }

        private void Slider7_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            UInt16 val = (UInt16)e.NewValue;
            string msg = String.Format("{0}", val);
            TextBlock7.Text = msg;
            pWMC.SetPWM(10, 0, val);
        }

        private void Slider8_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            UInt16 val = (UInt16)e.NewValue;
            string msg = String.Format("{0}", val);
            TextBlock8.Text = msg;
            pWMC.SetPWM(11, 0, val);
        }

        private void SliderAll_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            UInt16 val = (UInt16)e.NewValue;
            string msg = String.Format("{0}", val);
            TextBlockAll.Text = msg;
            pWMC.SetAllLedPWM(0, val);
            TextBlock1.Text = msg;
            Slider1.Value = val;
            TextBlock2.Text = msg;
            Slider2.Value = val;
            TextBlock3.Text = msg;
            Slider3.Value = val;
            TextBlock4.Text = msg;
            Slider4.Value = val;
            TextBlock5.Text = msg;
            Slider5.Value = val;
            TextBlock6.Text = msg;
            Slider6.Value = val;
            TextBlock7.Text = msg;
            Slider7.Value = val;
            TextBlock8.Text = msg;
            Slider8.Value = val;
        }
    }
}
