unsigned long last_time = 0;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(LED_BUILTIN, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if (millis() > last_time + 200)
  {
    Serial.println("Arduino is live");
    last_time = millis();
  }
  switch(Serial.read())
  {
    case '1':
      Serial.println("Turning on the light");
      digitalWrite(LED_BUILTIN, HIGH);
      break;
    case '2':
      Serial.println("Turning off the light");
      digitalWrite(LED_BUILTIN, LOW);
      break;
    default:
      break;
  }

}
