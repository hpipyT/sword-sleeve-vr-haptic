from gpiozero import Servo
from time import sleep

import smbus
import time

# controller
choice = input()

# servo pin
myGPIO = 18

# tens init
res = [0x45]
if (int(res[0]) > 69):
    print("Max allowed val exceeded, setting to 0")
    res = [0x00]

bus = smbus.SMBus(1)
potAddress = 0x2C
channel = 0x01

# decision making

if choice == "min" or choice == "1":
    servo = Servo(myGPIO)
#    servo.min()
    servo.value = -0.8
    print("Turned servo left")
    sleep(0.1)
    servo.value = 0.0
    sleep(0.1)
elif choice == "max" or choice == "3":
    servo = Servo(myGPIO)
#    servo.max()
    servo.value = 0.78
    print("Turned servo right")
    sleep(0.1)
elif choice == "mid" or choice == "2":
    servo = Servo(myGPIO)
    servo.value = 0.0
    print("Centered servo")
    sleep(0.1)
elif choice == "jitter" or choice == "4":
    servo = Servo(myGPIO)
    while(True):
        servo.value = -0.5
        sleep(0.15)
        servo.value = -0.75
        sleep(0.15)
elif choice == "tens" or choice == "5":
    servo = Servo(myGPIO)
    # lower resistance
    bus.write_i2c_block_data(potAddress, channel, res)
    data = bus.read_byte_data(potAddress, channel)
    resistance = (data / 256.0) * 50.0
    print ("Resistance: %2.f K" %resistance)
    sleep(.75)
    # raise resistance after 1.5 seconds
    res = [0x00]
    bus.write_i2c_block_data(potAddress, channel, res)
    data = bus.read_byte_data(potAddress, channel)
    resistance = (data / 256.0) * 50.0
    print ("Resistance: %2.f K" %resistance)
    servo.value = 0.0
    sleep(1)
elif choice == "tens2" or choice == "6":
    bus.write_i2c_block_data(potAddress, channel, res)
    data = bus.read_byte_data(potAddress, channel)
    resistance = (data / 256.0) * 50.0
    print("Resistance: %2.f K" %resistance)
    sleep(0.75)
    res = [0x00]
    bus.write_i2c_block_data(potAddress, channel, res)
    data = bus.read_byte_data(potAddress, channel)
    resistance = (data / 256.0) * 50.0
    print ("Resistance: %2.f K" %resistance)
    sleep(1)
