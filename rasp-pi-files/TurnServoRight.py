from gpiozero import Servo
from time import sleep

myGPIO = 18

if input():
	servo = Servo(myGPIO)
	servo.max()
#	servo.value = -0.25
	print("Turned servo right")
	sleep(5)
