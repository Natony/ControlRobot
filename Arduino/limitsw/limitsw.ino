#define stepX 2
#define dirX 5
#define ena 8

void setup() {
  Serial.begin(9600);

  pinMode(ena, OUTPUT);

  pinMode(stepX, OUTPUT);
  pinMode(dirX, OUTPUT);
}

void loop() {

    digitalWrite(dirX, HIGH);
    for (int i = 0; i < 200; i++) {
      digitalWrite(stepX, HIGH);
      delayMicroseconds(3000);
      digitalWrite(stepX, LOW);
      delayMicroseconds(3000);
    }
}