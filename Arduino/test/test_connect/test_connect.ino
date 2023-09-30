#include <LiquidCrystal_I2C.h>

int dir = 4;
int step = 5;
int ena = 6;

LiquidCrystal_I2C lcd(0x27, 16, 2);

char c;
String dataIn;
int8_t indexOfA;

// Thêm biến để lưu trữ góc mục tiêu và góc hiện tại của động cơ
int curDegreeMotor1 = 0;
int tarDegreeMotor1 = 0;
int stepsMotor1;

void setup() {
  Serial.begin(9600);

  lcd.init();
  lcd.backlight();

  pinMode(ena, OUTPUT);
  pinMode(step, OUTPUT);
  pinMode(dir, OUTPUT);

  digitalWrite(ena, LOW);
}

void loop() {
  Receive_Serial_Data();
  if (c == '\n') {
    Parse_the_Data();
    c = 0;
    dataIn = "";
  }

  lcd.setCursor(0, 0);
  lcd.print(tarDegreeMotor1); // Hiển thị góc hiện tại thay vì stpMoto1Degree
  lcd.setCursor(0, 1);
  lcd.print(stepsMotor1);
  motorStepper1();
}

void motorStepper1() {
  if (tarDegreeMotor1 != curDegreeMotor1) {
    int diffDegreeMotor1 = tarDegreeMotor1 - curDegreeMotor1;

    stepsMotor1 = diffDegreeMotor1 / 1.8;
    digitalWrite(dir, stepsMotor1 > 0 ? LOW : HIGH); // Xác định hướng quay dựa trên stepsMotor1
    lcd.setCursor(0, 1);
    for (int i = 0; i < abs(stepsMotor1); i++) {
      digitalWrite(step, HIGH);
      delayMicroseconds(10000);
      digitalWrite(step, LOW);
      delayMicroseconds(10000);
    }

    curDegreeMotor1 = tarDegreeMotor1; // Cập nhật góc hiện tại
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
    tarDegreeMotor1 = str_stpMoto1Degree.toInt();
  }
}
