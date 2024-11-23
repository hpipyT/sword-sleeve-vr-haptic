// Distributed with a free-will license.
// Use it any way you want, profit or free, provided it fits in the licenses of its associated works.
// AD5252
// This code is designed to work with the AD5252_I2CPOT_10K I2C Mini Module available from ControlEverything.com.
// https://www.controleverything.com/content/Potentiometers?sku=AD5252_I2CPOT_10K#tabs-0-product_tabset-2

#include<Wire.h>
#include <Servo.h>
// AD5252 I2C address is 0x2C(44)
#define Addr 0x2C


// Servo
int servoPin = 9;
Servo servo1;
unsigned long last_time = 0;

int servoAngle = 90;


void setup()
{ 

  // Potentiometer ///////////////////////////////////////////////////
  // Initialise I2C communication as Master
  
  // Initialise I2C communication as Master
  Wire.begin();
  // Initialise serial communication, set baud rate = 9600
  Serial.begin(9600);

  // Start I2C transmission
  Wire.beginTransmission(Addr);
  // Send instruction for POT channel-0
  Wire.write(0x01);
  // Input resistance value, 0x80(128)

  // Start at 0 - the lowest power setting, always
  Wire.write(0x00);
  // Stop I2C transmission
  Wire.endTransmission();

  // Servo ///////////////////////////////////////////////////

  servo1.attach(servoPin);
  Serial.begin(9600);

}

void loop()
{
  unsigned int data;

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
      servo1.write(servoAngle);
      break;
    case '2':
      Serial.println("Turning servo mid");
      servoAngle = 100;
      servo1.write(servoAngle);
      break;
    case '3':
      Serial.println("Turning servo right");
      servoAngle = 63;
      servo1.write(servoAngle);
      break;
    case '4':
      Serial.println("Stimming TENS");

        servoAngle = 100;
        servo1.write(servoAngle);
        Wire.beginTransmission(Addr);
        // Send instruction for POT channel-0
        Wire.write(0x01);
        // Input resistance value, 0x80(128)
        //Wire.write(0x28);
        Wire.write(0x45);
        
        // Stop I2C transmission
        Wire.endTransmission();

        delay(400);

        Wire.beginTransmission(Addr);
        // Send instruction for POT channel-0
        Wire.write(0x01);
        // Input resistance value, 0x80(128)
        Wire.write(0x00);
        
        // Stop I2C transmission
        Wire.endTransmission();
      break;
    default:
      break;
  }

}