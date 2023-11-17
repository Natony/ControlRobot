
const int step1 = 2;
const int dir1 = 5;

const int step2 = 3;
const int dir2 = 6;
const int ena = 8;

void setup() {

  pinMode(ena, OUTPUT);
  pinMode(dir1, OUTPUT);
  pinMode(step1, OUTPUT);

  pinMode(dir2, OUTPUT);
  pinMode(step2, OUTPUT);

  digitalWrite(ena, LOW);
}

void loop() {    
    digitalWrite(dir2,HIGH);
    for (int i = 0; i < 0; i++) {
      digitalWrite(step2, HIGH);
      delayMicroseconds(15000);
      digitalWrite(step2, LOW);
      delayMicroseconds(15000);
    }

}
