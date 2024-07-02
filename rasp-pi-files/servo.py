from gpiozero import Servo
from time import sleep
 
myGPIO=18
 
servo = Servo(myGPIO)
servo.mid()
sleep(1.0)
val = 0.0

servo.value = 0.78

sleep(0.1)
#try:
 #   while True:
#        sleep(0.1)
#        val = 0.78
#        servo.value = val
#        sleep(0.1)
#        val = -0.8
#        servo.value = val
# except KeyboardInterrupt:
#    print("Program stopped")
