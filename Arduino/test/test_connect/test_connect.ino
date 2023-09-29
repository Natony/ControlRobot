#include <LiquidCrystal_I2C.h>

int dir = 4;
int step = 5;
int ena = 6;

LiquidCrystal_I2C lcd(0x27, 16, 2);

char c;
String dataIn;
int8_t indexOfA;

// Thêm biến để lưu trữ góc mục tiêu và góc hiện tại của động cơ
int currentDegree = 0;
int targetDegree = 0;
int steps;
void peripheral_setup() {
}

void peripheral_loop() {
}

void setup() {
  peripheral_setup();
  Serial.begin(9600);

  lcd.init();
  lcd.backlight();

  pinMode(ena, OUTPUT);
  pinMode(step, OUTPUT);
  pinMode(dir, OUTPUT);

  digitalWrite(ena, LOW);
}

void loop() {
  peripheral_loop();
  Receive_Serial_Data();
  if (c == '\n') {
    Parse_the_Data();
    c = 0;
    dataIn = "";
  }

  lcd.setCursor(0, 0);
  lcd.print(targetDegree); // Hiển thị góc hiện tại thay vì stpMoto1Degree
  lcd.setCursor(0, 1);
  lcd.print(steps);
  motorStepper1();
}

void motorStepper1() {
  if (targetDegree != currentDegree) {
    int degreeDiff = targetDegree - currentDegree;

    steps = degreeDiff / 1.8;
    digitalWrite(dir, steps > 0 ? LOW : HIGH); // Xác định hướng quay dựa trên steps
    lcd.setCursor(0, 1);
    for (int i = 0; i < abs(steps); i++) {
      digitalWrite(step, HIGH);
      delayMicroseconds(10000);
      digitalWrite(step, LOW);
      delayMicroseconds(10000);
    }

    currentDegree = targetDegree; // Cập nhật góc hiện tại
  }
}

void Receive_Serial_Data() {
  while (Serial.available() > 0) {
    c = Serial.read();
    if (c == '\n') {
      break;
    } else {
      dataIn += c;
    }
  }
}

void Parse_the_Data() {
  String str_stpMoto1Degree;

  indexOfA = dataIn.indexOf("A");

  if (indexOfA > -1) {
    str_stpMoto1Degree = dataIn.substring(0, indexOfA);
    targetDegree = str_stpMoto1Degree.toInt();
  }
}
