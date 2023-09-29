int dir =4;
int step = 5;
int ena = 6;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(ena, OUTPUT);
  pinMode(step, OUTPUT);
  pinMode(dir, OUTPUT);

  digitalWrite(ena, LOW);
}

void loop() {
  // put your main code here, to run repeatedly:
  digitalWrite(dir, LOW);

  for(int i = 0; i < 200; i++){
    digitalWrite(step, HIGH);
    delayMicroseconds(1000);
    digitalWrite(step, LOW);
    delayMicroseconds(1000);
  }
  delay(1000);

}
