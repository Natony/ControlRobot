#include <LiquidCrystal_I2C.h>
#include <ezButton.h>

#define stepX 2
#define dirX 5

#define stepY 3
#define dirY 6

#define stepZ 4
#define dirZ 7

#define stepA 12
#define dirA 13
  
#define ena 8
LiquidCrystal_I2C lcd(0x27, 16, 2);
ezButton limitSwitchMotor1(9);
ezButton limitSwitchMotor2(10);
ezButton limitSwitchMotor3(11);
ezButton limitSwitchMotor4(A0);
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

  // setup lcd
  lcd.init();
  lcd.backlight();

  // setup pin driver
  pinMode(ena, OUTPUT);

  pinMode(stepX, OUTPUT);
  pinMode(dirX, OUTPUT);

  pinMode(stepY, OUTPUT);
  pinMode(dirY, OUTPUT);

  pinMode(stepZ, OUTPUT);
  pinMode(dirZ, OUTPUT);

  pinMode(stepA, OUTPUT);
  pinMode(dirA, OUTPUT);

  digitalWrite(ena, LOW);
  
  // steup debounce time limit switch
  limitSwitchMotor1.setDebounceTime(50);
  limitSwitchMotor2.setDebounceTime(50);
  limitSwitchMotor3.setDebounceTime(50);
  limitSwitchMotor4.setDebounceTime(50);

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

    stepsMotor1 = (diffDegreeMotor1) / 0.05625;
    digitalWrite(dirX, stepsMotor1 > 0 ? LOW : HIGH); // Xác định hướng quay dựa trên stepsMotor1
    for (int i = 0; i < abs(stepsMotor1); i++) {
      digitalWrite(stepX, HIGH);
      delayMicroseconds(1000);
      digitalWrite(stepX, LOW);
      delayMicroseconds(1000);
    }

    curDegreeMotor1 = tarDegreeMotor1; // Cập nhật góc hiện tại
  }
}

void motorStepper2() {
  if (tarDegreeMotor2 != curDegreeMotor2) {
    int diffDegreeMotor2 = tarDegreeMotor2 - curDegreeMotor2;

    stepsMotor2 = diffDegreeMotor2 / 0.0375;
    digitalWrite(dirY, stepsMotor2 > 0 ? HIGH : LOW); // Xác định hướng quay dựa trên stepsMotor1
    for (int i = 0; i < abs(stepsMotor2); i++) {
      digitalWrite(stepY, HIGH);
      delayMicroseconds(3000);
      digitalWrite(stepY, LOW);
      delayMicroseconds(3000);
    }

    curDegreeMotor2 = tarDegreeMotor2; // Cập nhật góc hiện tại
  }
}
void motorStepper3() {
  if (tarDegreeMotor3 != curDegreeMotor3) {
    int diffDegreeMotor3 = tarDegreeMotor3 - curDegreeMotor3;

    stepsMotor3 = diffDegreeMotor3 / 0.025;
    digitalWrite(dirZ, stepsMotor3 > 0 ? LOW : HIGH); // Xác định hướng quay dựa trên stepsMotor1
    for (int i = 0; i < abs(stepsMotor3); i++) {
      digitalWrite(stepZ, HIGH);
      delayMicroseconds(3000);
      digitalWrite(stepZ, LOW);
      delayMicroseconds(3000);
    }

    curDegreeMotor3 = tarDegreeMotor3; // Cập nhật góc hiện tại
  }
}
void motorStepper4() {
  if (tarDegreeMotor4 != curDegreeMotor4) {
    int diffDegreeMotor4 = tarDegreeMotor4 - curDegreeMotor4;

    stepsMotor4 = diffDegreeMotor4 / 0.045;
    digitalWrite(dirA, stepsMotor4 > 0 ? LOW : HIGH); // Xác định hướng quay dựa trên stepsMotor1
    for (int i = 0; i < abs(stepsMotor4); i++) {
      digitalWrite(stepA, HIGH);
      delayMicroseconds(2000);
      digitalWrite(stepA, LOW);
      delayMicroseconds(2000);
    }

    curDegreeMotor4 = tarDegreeMotor4; // Cập nhật góc hiện tại
  }
}

void setHome(){

  // initialize state 4 variable state for ls
  int stateLS1 = limitSwitchMotor1.getState();
  int stateLS2 = limitSwitchMotor2.getState();
  int stateLS3 = limitSwitchMotor3.getState();
  int stateLS4 = limitSwitchMotor4.getState();

  if(stateLS1 == LOW && stateLS2 == LOW && stateLS3 == LOW && stateLS4 == LOW){
    delay(5000);
    Serial.println("go to Home");
  }
  //limit switch 1
  if(limitSwitchMotor1.isPressed())
    Serial.println("The limit switch 1: UNTOUCHED -> TOUCHED");

  if(limitSwitchMotor1.isReleased())
    Serial.println("The limit switch1 : TOUCHED -> UNTOUCHED");
    
  if(stateLS1 == HIGH)
  {    
    Serial.println("The limit switch1: UNTOUCHED");
  }
  else
  {
    Serial.println("The limit switch1: TOUCHED");
  }

  //limit switch 2
  if(limitSwitchMotor2.isPressed())
    Serial.println("The limit switch 2: UNTOUCHED -> TOUCHED");

  if(limitSwitchMotor2.isReleased())
    Serial.println("The limit switch2 : TOUCHED -> UNTOUCHED");
    
  if(stateLS2 == HIGH)
  {    
    Serial.println("The limit switch2: UNTOUCHED");
  }
  else
  {
    Serial.println("The limit switch2: TOUCHED");
  }

  //limit switch 3
  if(limitSwitchMotor3.isPressed())
    Serial.println("The limit switch 3: UNTOUCHED -> TOUCHED");

  if(limitSwitchMotor3.isReleased())
    Serial.println("The limit switch3 : TOUCHED -> UNTOUCHED");
    
  if(stateLS3 == HIGH)
  {    
    Serial.println("The limit switch3: UNTOUCHED");
  }
  else
  {
    Serial.println("The limit switch3: TOUCHED");
  }

  //limit switch 4
  if(limitSwitchMotor4.isPressed())
    Serial.println("The limit switch 4: UNTOUCHED -> TOUCHED");

  if(limitSwitchMotor4.isReleased())
    Serial.println("The limit switch4 : TOUCHED -> UNTOUCHED");
    
  if(stateLS4 == HIGH)
  {    
    Serial.println("The limit switch4: UNTOUCHED");
  }
  else
  {
    Serial.println("The limit switch4: TOUCHED");
  }
  delay(2000);
}
void loop() {
  //call limit in loop

  limitSwitchMotor1.loop();
  limitSwitchMotor2.loop();
  limitSwitchMotor3.loop();
  limitSwitchMotor4.loop();

  // compare data
  Receive_Serial_Data();
  if (c == '\n') {
    Parse_the_Data();
    c = 0;
    dataIn = "";
  }
  
  // call funtion motor
  motorStepper1();
  motorStepper2();
  motorStepper3();
  motorStepper4();
  setHome();
}



