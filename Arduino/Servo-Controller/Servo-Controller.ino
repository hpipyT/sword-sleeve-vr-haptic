#include <Servo.h>

int servoPin = 9;
Servo servo1;
unsigned long last_time = 0;

int servoAngle = 90;

void setup() {
  // put your setup code here, to run once:
  servo1.attach(servoPin);
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  if (millis() > last_time + 2000)
  {

    Serial.println("Arduino is live");
    last_time = millis();
  }

  switch(Serial.read())
  {
    case '1':
      Serial.println("Turning servo left");
      servoAngle = 130;   
      break;
    case '2':
      Serial.println("Turning servo mid");
      servoAngle = 100;  
      break;
    case '3':
      Serial.println("Turning servo right");
      servoAngle = 63;  
      break;
    default:
      break;
  }
  servo1.write(servoAngle);
}
