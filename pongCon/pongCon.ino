const int ledPin = 13;

int incomingByte;

void setup()
{
  // init serial.
  Serial.begin(9600);
  // init LED pin as out.
  pinMode(ledPin, OUTPUT);
}

void loop()
{
  // see if there's incomind serial data:
  if (Serial.available() > 0){
    // read the oldest byte in the serial buffer:
    incomingByte = Serial.read();
    // if it's a capital H (ASCII 72), turn on the LED:
    if (incomingByte == 'H'){
      digitalWrite(ledPin, HIGH);
    }
    // if it's an L (ASCII 76) turn off the LED:
    if (incomingByte == 'L') {
      digitalWrite(ledPin, LOW);
    }
    
    if (incomingByte == 'I'){
      Serial.print(analogRead(A0));
      Serial.print("-");
      Serial.println(analogRead(A1));
    }
  }
}
