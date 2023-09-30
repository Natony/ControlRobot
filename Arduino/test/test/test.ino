#include <LiquidCrystal_I2C.h>

int dir[4] = {4, 7, 10, 13}; // Chân định hướng cho 4 động cơ
int step[4] = {5, 8, 11, 12}; // Chân bước cho 4 động cơ
int ena[4] = {6, 9, 14, 15}; // Chân bật/tắt động cơ cho 4 động cơ

LiquidCrystal_I2C lcd(0x27, 16, 2);

char c;
String dataIn;
int8_t indexOfChars[4]; // Mảng lưu vị trí của ký tự A, B, C, D cho từng động cơ

// Biến lưu trữ góc mục tiêu và góc hiện tại của các động cơ
int curDegree[4] = {0, 0, 0, 0};
int tarDegree[4] = {0, 0, 0, 0};
int steps[4];

void setup() {
  Serial.begin(9600);
  lcd.init();
  lcd.backlight();

  for (int i = 0; i < 4; i++) {
    pinMode(ena[i], OUTPUT);
    pinMode(step[i], OUTPUT);
    pinMode(dir[i], OUTPUT);
    digitalWrite(ena[i], LOW);
  }
}

void loop() {
  receiveSerialData();
  if (c == '\n') {
    parseData();
    c = 0;
    dataIn = "";
  }

  for (int i = 0; i < 4; i++) {
    lcd.setCursor(0, i);
    lcd.print(tarDegree[i]);
    controlMotor(i);
  }
}

void controlMotor(int motorIndex) {
  if (tarDegree[motorIndex] != curDegree[motorIndex]) {
    int degreeDiff = tarDegree[motorIndex] - curDegree[motorIndex];
    steps[motorIndex] = degreeDiff / 1.8;
    digitalWrite(dir[motorIndex], steps[motorIndex] > 0 ? LOW : HIGH);

    for (int i = 0; i < abs(steps[motorIndex]); i++) {
      digitalWrite(step[motorIndex], HIGH);
      delayMicroseconds(10000);
      digitalWrite(step[motorIndex], LOW);
      delayMicroseconds(10000);
    }

    curDegree[motorIndex] = tarDegree[motorIndex];
  }
}

void receiveSerialData() {
  while (Serial.available() > 0) {
    c = Serial.read();
    if (c == '\n') {
      break;
    } else {
      dataIn += c;
    }
  }
}

void parseData() {
  String currentMotor = ""; // Biến lưu trữ động cơ hiện tại
  String currentDegree = ""; // Biến lưu trữ góc hiện tại

  for (int i = 0; i < dataIn.length(); i++) {
    char c = dataIn.charAt(i);
    Serial.print("Received character: ");
    Serial.println(c); // Debug: In ra ký tự đang xử lý
    if (isAlpha(c)) {
      // Nếu ký tự là chữ cái, nó là động cơ mới
      currentMotor = String(c);
      currentDegree = "";
    } else if (isDigit(c)) {
      // Nếu ký tự là số, thêm vào biến lưu trữ góc
      currentDegree += String(c);
    }
    // Nếu gặp ký tự khác, xử lý và đặt góc cho động cơ hiện tại
    if (!isDigit(dataIn.charAt(i + 1)) || i == dataIn.length() - 1) {
      if (currentMotor == "A") {
        tarDegree[0] = currentDegree.toInt();
        Serial.print("Set motor A degree to: ");
        Serial.println(tarDegree[0]); // Debug: In ra góc của động cơ A
      } else if (currentMotor == "B") {
        tarDegree[1] = currentDegree.toInt();
        Serial.print("Set motor B degree to: ");
        Serial.println(tarDegree[1]); // Debug: In ra góc của động cơ B
      } else if (currentMotor == "C") {
        tarDegree[2] = currentDegree.toInt();
        Serial.print("Set motor C degree to: ");
        Serial.println(tarDegree[2]); // Debug: In ra góc của động cơ C
      } else if (currentMotor == "D") {
        tarDegree[3] = currentDegree.toInt();
        Serial.print("Set motor D degree to: ");
        Serial.println(tarDegree[3]); // Debug: In ra góc của động cơ D
      }
    }
  }
}



