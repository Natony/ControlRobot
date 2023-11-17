#include <LiquidCrystal_I2C.h>

const int step1 = 2;
const int dir1 = 5;

const int step2 = 3;
const int dir2 = 6;

const int step3 = 4;
const int dir3 = 7;

int ena = 8;
LiquidCrystal_I2C lcd(0x27, 16, 2);

char c;
String dataIn;
int8_t indexOfA, indexOfB, indexOfC, indexOfD;

// Thêm biến để lưu trữ góc mục tiêu và góc hiện tại của động cơ
int curDegreeMotor1 = 0, curDegreeMotor2 = 0, curDegreeMotor3 = 0, curDegreeMotor4 = 0;
int tarDegreeMotor1 = 0, tarDegreeMotor2 = 0, tarDegreeMotor3 = 0, tarDegreeMotor4 = 0;
int stepsMotor1, stepsMotor2, stepsMotor3, stepsMotor4;
int tarDegree = 0, curDegree = 0;

void setup() {
  Serial.begin(9600);

  lcd.init();
  lcd.backlight();

  pinMode(ena, OUTPUT);

  pinMode(step1, OUTPUT);
  pinMode(dir1, OUTPUT);

  pinMode(step2, OUTPUT);
  pinMode(dir2, OUTPUT);

  // pinMode(step3, OUTPUT);
  // pinMode(dir3, OUTPUT);

  digitalWrite(ena, LOW);
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
  String str_stpMoto1Degree, str_stpMoto2Degree, str_stpMoto3Degree, str_stpMoto4Degree;

  indexOfA = dataIn.indexOf("A");
  indexOfB = dataIn.indexOf("B");
  indexOfC = dataIn.indexOf("C");
  indexOfD = dataIn.indexOf("D");

  if (indexOfA > -1) {
    str_stpMoto1Degree = dataIn.substring(0, indexOfA);
    tarDegreeMotor1 = str_stpMoto1Degree.toInt();
  }
  if (indexOfB > -1) {
    str_stpMoto2Degree = dataIn.substring(indexOfA + 1, indexOfB);
    tarDegreeMotor2 = str_stpMoto2Degree.toInt();
  }
  if (indexOfC > -1) {
    str_stpMoto3Degree = dataIn.substring(indexOfB + 1, indexOfC);
    tarDegreeMotor3 = str_stpMoto3Degree.toInt();
  }
  if (indexOfD > -1) {
    str_stpMoto4Degree = dataIn.substring(indexOfC + 1, indexOfD);
    tarDegreeMotor4 = str_stpMoto4Degree.toInt();
  }
}

void motorStepper1() {
  if (tarDegreeMotor1 != curDegreeMotor1) {
    int diffDegreeMotor1 = tarDegreeMotor1 - curDegreeMotor1;

    stepsMotor1 = (diffDegreeMotor1) / 1.8;
    digitalWrite(dir1, stepsMotor1 > 0 ? LOW : HIGH); // Xác định hướng quay dựa trên stepsMotor1
    for (int i = 0; i < abs(stepsMotor1); i++) {
      lcd.setCursor(0, 1);
      lcd.print(i);
      digitalWrite(step1, HIGH);
      delayMicroseconds(15000);
      digitalWrite(step1, LOW);
      delayMicroseconds(15000);
    }

    curDegreeMotor1 = tarDegreeMotor1; // Cập nhật góc hiện tại
  }
}

void motorStepper2() {
  if (tarDegreeMotor2 != curDegreeMotor2) {
    int diffDegreeMotor2 = tarDegreeMotor2 - curDegreeMotor2;

    stepsMotor2 = diffDegreeMotor2 / 1.8;
    digitalWrite(dir2, stepsMotor2 > 0 ? LOW : HIGH); // Xác định hướng quay dựa trên stepsMotor1
    for (int i = 0; i < abs(stepsMotor2); i++) {
      lcd.setCursor(5, 1);
      lcd.print(i);
      digitalWrite(step2, HIGH);
      delayMicroseconds(20000);
      digitalWrite(step2, LOW);
      delayMicroseconds(10000);
    }

    curDegreeMotor2 = tarDegreeMotor2; // Cập nhật góc hiện tại
  }
}
void motorStepper(int tarDegree, int curDegree, int step, int dir)
{
  if(tarDegree != curDegree){
    int diffDegree = tarDegree - curDegree;

    int stepMotor = diffDegree / 1.8;
    digitalWrite(dir, stepMotor > 0 ? LOW : HIGH);
    for (int i = 0; i < abs(stepMotor); i++) {
      lcd.setCursor(0, 1);
      lcd.print(i);
      digitalWrite(step, HIGH);
      delayMicroseconds(10000);
      digitalWrite(step, LOW);
      delayMicroseconds(10000);
    }
    curDegree = tarDegree;
  }
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

  lcd.setCursor(5, 0);
  lcd.print(tarDegreeMotor2); // Hiển thị góc hiện tại thay vì stpMoto1Degree
  
  // motorStepper(tarDegreeMotor1, curDegreeMotor1, step1, dir1);
  // motorStepper(tarDegreeMotor2, curDegreeMotor2, step2, dir2);
  motorStepper1();
  motorStepper2();
//  motorStepper3();
}


