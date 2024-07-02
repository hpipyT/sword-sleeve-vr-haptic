from gpiozero import Servo
from time import sleep

myGPIO = 18

servo = Servo(myGPIO)
servo.mid()
sleep(0.41)
