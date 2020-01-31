const int echoPin = 12;
const int trigPin = 13;

const int echoPinTwo = 10;
const int trigPinTwo = 11;

int incomingByte;
long duration, dist, distTwo;

void setup()
{
  // init serial.
  Serial.begin(9600);

  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);

  pinMode(trigPinTwo, OUTPUT);
  pinMode(echoPinTwo, INPUT);
}

void loop()
{
  // see if there's incomind serial data:
  if (Serial.available() > 0){
    // read the oldest byte in the serial buffer:
    incomingByte = Serial.read();

    if (incomingByte == 'D')
    {
      digitalWrite(trigPin, LOW);
      delayMicroseconds(5);
      digitalWrite(trigPin, HIGH);
      delayMicroseconds(10);
      digitalWrite(trigPin, LOW);

      pinMode(echoPin, INPUT);
      duration = pulseIn(echoPin, HIGH);
      dist = (duration/2) / 29.1; 

      digitalWrite(trigPinTwo, LOW);
      delayMicroseconds(5);
      digitalWrite(trigPinTwo, HIGH);
      delayMicroseconds(10);
      digitalWrite(trigPinTwo, LOW);

      pinMode(echoPinTwo, INPUT);
      duration = pulseIn(echoPinTwo, HIGH);
      distTwo = (duration/2) / 29.1; 

      Serial.print(dist);
      Serial.print("-");
      Serial.print(distTwo);
      Serial.print("-");
      Serial.print(analogRead(A0));
      Serial.print("-");
      Serial.println(analogRead(A5));
    }
    
    if (incomingByte == 'I')
    {
      Serial.print(analogRead(A0));
      Serial.print("-");
      Serial.println(analogRead(A2));
    }
  }
}
