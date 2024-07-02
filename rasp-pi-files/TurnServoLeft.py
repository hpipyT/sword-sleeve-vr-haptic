from gpiozero import Servo
from time import sleep

myGPIO = 18

servo = Servo(myGPIO)
while(True):
    servo.value = -0.65
    sleep(0.15)
    servo.value = -0.75
    sleep(0.15)

