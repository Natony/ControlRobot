/* Main.ino file generated by New Project wizard
 *
 * Created:   Sat Sep 16 2023
 * Processor: Arduino Uno
 * Compiler:  Arduino AVR (Proteus)
 */
// Peripheral Configuration Code (do not edit)
//---CONFIG_BEGIN---
#pragma GCC push_options
#pragma GCC optimize("Os")


#pragma GCC pop_options

// Peripheral Constructors
#include <Servo.h>
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27, 16, 2);

Servo Servo1;
Servo Servo2;
Servo Servo3;
Servo Servo4;
Servo Servo5;

char c;
String dataIn;
uint8_t servo1Degree, servo2Degree, servo3Degree, servo4Degree, gripper;
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

  Servo1.attach(3);
  Servo2.attach(4);
  Servo3.attach(5);
  Servo4.attach(6);
  Servo5.attach(7);

  Servo1.write(50);
  Servo2.write(50);
  Servo3.write(50);
  Servo4.write(50);
  Servo5.write(50);

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
  lcd.print(servo1Degree);
  lcd.setCursor(3, 0);
  lcd.print(servo2Degree);
  lcd.setCursor(6, 0);
  lcd.print(servo3Degree);
  lcd.setCursor(9, 0);
  lcd.print(servo4Degree);

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
  String str_servo1Degree, str_servo2Degree, str_servo3Degree, str_servo4Degree, str_pointX, str_pointY, str_pointZ, str_gripper;

  indexOfA = dataIn.indexOf("A");
  indexOfB = dataIn.indexOf("B");
  indexOfC = dataIn.indexOf("C");
  indexOfD = dataIn.indexOf("D");
  indexOfE = dataIn.indexOf("E");
  indexOfF = dataIn.indexOf("F");
  indexOfG = dataIn.indexOf("G");
  indexOfH = dataIn.indexOf("H");

  if (indexOfA > -1) {
    str_servo1Degree = dataIn.substring(0, indexOfA);
    servo1Degree = str_servo1Degree.toInt();
  }

  if (indexOfB > -1) {
    str_servo2Degree = dataIn.substring(indexOfA + 1, indexOfB);
    servo2Degree = str_servo2Degree.toInt();
  }

  if (indexOfC > -1) {
    str_servo3Degree = dataIn.substring(indexOfB + 1, indexOfC);
    servo3Degree = str_servo3Degree.toInt();
  }

  if (indexOfD > -1) {
    str_servo4Degree = dataIn.substring(indexOfC + 1, indexOfD);
    servo4Degree = str_servo4Degree.toInt();
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
