from gpiozero import Servo
from time import sleep

servo = Servo(18)

while True:
    servo.value = -0.25
    sleep(0.1)
    servo.value = 0.25
    sleep(0.1)
