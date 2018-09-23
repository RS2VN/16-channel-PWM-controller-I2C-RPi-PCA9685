# 16-channel-PWM-controller-I2C-RPi-PCA9685
Adafruit 16-channel PWM Servo HAT controlling 8 led. The project tests PCA9685 for using it to control DC motors and servos.

With that project I use Adafruit 16-channel PWM Servo HAT for controlling 8 led. That is a basic test for PWM control by PCA9685 on the hat. By that the hat is ready to control up to 8 DC motors or 16 servos using C# on Visual Studio 2017 and Windows 10 core. 
PWM signals are attached to ULN2803A Darlington Transistor Array to pins 1B – 8B.  Pins 1C – 8C are attached to cathode of 8 led. Make sure to reduce current to the led when attache anode to power +.

On RPi UI you will get 9 sliders, eight of them are for controlling each led separately and the 9th slider controls all leds.
