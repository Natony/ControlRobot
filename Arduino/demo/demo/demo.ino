#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27, 16, 2);

char c;
String dataIn;
uint8_t stpMoto1Degree, stpMoto2Degree, stpMoto3Degree, stpMoto4Degree, gripper;
signed  pointX, pointY, pointZ;
int8_t indexOfA, indexOfB, indexOfC, indexOfD, indexOfE, indexOfF, indexOfG, indexOfH;

void peripheral_setup() {
}

void peripheral_loop() {
}
//---CONFIG_END---
void setup() {
  peripheral_setup();
  // TODO: put your setup code here, to run once:
  Serial.begin(9600);

  //lcd
  lcd.init();
  lcd.backlight();
}

void loop() {
  peripheral_loop();
  // TODO: put your main code here, to run repeatedly:
  Receive_Serial_Data();
  if (c == '\n') {
    Parse_the_Data();
    c = 0;
    dataIn = "";
  }
  // lcd
  //jonit
  lcd.setCursor(0, 0);
  lcd.print(stpMoto1Degree);
  lcd.setCursor(3, 0);
  lcd.print(stpMoto2Degree);
  lcd.setCursor(6, 0);
  lcd.print(stpMoto3Degree);
  lcd.setCursor(9, 0);
  lcd.print(stpMoto4Degree);

  //point
  lcd.setCursor(0, 1);
  lcd.print(pointX);
  lcd.setCursor(5, 1);
  lcd.print(pointY);
  lcd.setCursor(10, 1);
  lcd.print(pointZ);

  //gripper
  lcd.setCursor(13, 0);
  lcd.print(gripper);

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
  String str_stpMoto1Degree, str_stpMoto2Degree, str_stpMoto3Degree, str_stpMoto4Degree, str_pointX, str_pointY, str_pointZ, str_gripper;

  indexOfA = dataIn.indexOf("A");
  indexOfB = dataIn.indexOf("B");
  indexOfC = dataIn.indexOf("C");
  indexOfD = dataIn.indexOf("D");
  indexOfE = dataIn.indexOf("E");
  indexOfF = dataIn.indexOf("F");
  indexOfG = dataIn.indexOf("G");
  indexOfH = dataIn.indexOf("H");

  if (indexOfA > -1) {
    str_stpMoto1Degree = dataIn.substring(0, indexOfA);
    stpMoto1Degree = str_stpMoto1Degree.toInt();
  }

  if (indexOfB > -1) {
    str_stpMoto2Degree = dataIn.substring(indexOfA + 1, indexOfB);
    stpMoto2Degree = str_stpMoto2Degree.toInt();
  }

  if (indexOfC > -1) {
    str_stpMoto3Degree = dataIn.substring(indexOfB + 1, indexOfC);
    stpMoto3Degree = str_stpMoto3Degree.toInt();
  }

  if (indexOfD > -1) {
    str_stpMoto4Degree = dataIn.substring(indexOfC + 1, indexOfD);
    stpMoto4Degree = str_stpMoto4Degree.toInt();
  }
  if (indexOfE > -1) {
    str_pointX = dataIn.substring(indexOfD + 1, indexOfE);
    pointX = str_pointX.toInt();
  }
  if (indexOfF > -1) {
    str_pointY = dataIn.substring(indexOfE + 1, indexOfF);
    pointY = str_pointY.toInt();
  }
  if (indexOfG > -1) {
    str_pointZ = dataIn.substring(indexOfE + 1, indexOfG);
    pointZ = str_pointZ.toInt();
  }
  if (indexOfH > -1) {
    str_gripper = dataIn.substring(indexOfG + 1, indexOfH);
    gripper = str_gripper.toInt();
  }
}
