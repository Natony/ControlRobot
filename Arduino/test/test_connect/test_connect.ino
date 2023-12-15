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
int8_t indexOfA, indexOfB, indexOfC, indexOfD, indexOfH;

// Thêm biến để lưu trữ góc mục tiêu và góc hiện tại của động cơ
int curDegreeMotor1 = 0, curDegreeMotor2 = 0, curDegreeMotor3 = 0, curDegreeMotor4 = 0;
int tarDegreeMotor1 = 0, tarDegreeMotor2 = 0, tarDegreeMotor3 = 0, tarDegreeMotor4 = 0;
int diffDegreeMotor1 = 0, diffDegreeMotor2 = 0, diffDegreeMotor3 = 0, diffDegreeMotor4 = 0;
int stepsMotor1, stepsMotor2, stepsMotor3, stepsMotor4;
int tarDegree = 0, curDegree = 0;
int tt_DC = 0;
int step3 = 0;

int state1 = 0;
int state2 = 0;
int state3 = 0;
int state4 = 0;

int statusSetHome = 0; 
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
  String str_stpMoto1Degree, str_stpMoto2Degree, str_stpMoto3Degree, str_stpMoto4Degree, str_SetHome;;

  indexOfA = dataIn.indexOf("A");
  indexOfB = dataIn.indexOf("B");
  indexOfC = dataIn.indexOf("C");
  indexOfD = dataIn.indexOf("D");
  indexOfH = dataIn.indexOf("H");

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
  if (indexOfH > -1) {
    str_SetHome = dataIn.substring(indexOfD + 1, indexOfH);
    statusSetHome = str_SetHome.toInt();
  }
}

void motorStepper1() {
  if (tarDegreeMotor1 != curDegreeMotor1) {
    diffDegreeMotor1 = tarDegreeMotor1 - curDegreeMotor1;

    stepsMotor1 = (diffDegreeMotor1) / 0.05625;
    digitalWrite(dirX, stepsMotor1 > 0 ? LOW : HIGH); // Xác định hướng quay dựa trên stepsMotor1
    for (int i = 0; i < abs(stepsMotor1); i++) {
      digitalWrite(stepX, HIGH);
      delayMicroseconds(1200);
      digitalWrite(stepX, LOW);
      delayMicroseconds(1200);
    }

    curDegreeMotor1 = tarDegreeMotor1; // Cập nhật góc hiện tại
  }
}

void motorStepper2() {
  if (tarDegreeMotor2 != curDegreeMotor2) {
    diffDegreeMotor2 = tarDegreeMotor2 - curDegreeMotor2;

    stepsMotor2 = diffDegreeMotor2 / 0.0375;
    digitalWrite(dirY, stepsMotor2 < 0 ? HIGH : LOW); // Xác định hướng quay dựa trên stepsMotor1
    for (int i = 0; i < abs(stepsMotor2); i++) {
      digitalWrite(stepY, HIGH);
      delayMicroseconds(3000);
      digitalWrite(stepY, LOW);
      delayMicroseconds(3000);
    }

    step3 =  (diffDegreeMotor2/1.5) / 0.025;
    digitalWrite(dirZ, step3 < 0 ? LOW : HIGH); // Xác định hướng quay dựa trên stepsMotor1
    for (int i = 0; i < abs(step3); i++) {
      digitalWrite(stepZ, HIGH);
      delayMicroseconds(3000);
      digitalWrite(stepZ, LOW);
      delayMicroseconds(3000);    
    }
    curDegreeMotor2 = tarDegreeMotor2; // Cập nhật góc hiện tại
    //tt_DC = 1;
  }
}
void motorStepper3() {
  if (tarDegreeMotor3 != curDegreeMotor3) {
    diffDegreeMotor3 = tarDegreeMotor3 - curDegreeMotor3;
    //if (tt_DC == 1)
    //{
    //  diffDegreeMotor3 = diffDegreeMotor3 + (diffDegreeMotor2 - diffDegreeMotor2/1.5);
    //}
    
    stepsMotor3 = diffDegreeMotor3 / 0.025;
    digitalWrite(dirZ, stepsMotor3 < 0 ? LOW : HIGH); // Xác định hướng quay dựa trên stepsMotor1
    for (int i = 0; i < abs(stepsMotor3); i++) {
      digitalWrite(stepZ, HIGH);
      delayMicroseconds(3000);
      digitalWrite(stepZ, LOW);
      delayMicroseconds(3000);
    }

    curDegreeMotor3 = tarDegreeMotor3; // Cập nhật góc hiện tại
    //tt_DC = 0;
  }
}
void motorStepper4() {
  if (tarDegreeMotor4 != curDegreeMotor4) {
    diffDegreeMotor4 = tarDegreeMotor4 - curDegreeMotor4;

    stepsMotor4 = diffDegreeMotor4 / 0.09;
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

  if(stateLS1 == LOW)
  {
    state1 = 1;
  }
    if(stateLS2 == LOW)
  {
    state2 = 1;
  }
    if(stateLS3 == LOW)
  {
    state3 = 1;
  }
    if(stateLS4 == LOW)
  {
    state4 = 1;
  }
  if(state1 == 0 && state2 == 1 && state3 == 1 && state4 == 1 )
  {
      digitalWrite(dirX, LOW);
      digitalWrite(stepX, HIGH);
      delayMicroseconds(800);
      digitalWrite(stepX, LOW);
      delayMicroseconds(800);
  }
    if(state2 == 0 )
  {
      digitalWrite(dirY, HIGH);
      digitalWrite(stepY, HIGH);
      delayMicroseconds(800);
      digitalWrite(stepY, LOW);
      delayMicroseconds(800);
  }
    if(state3 == 0 && state2 == 1 && state4 == 1)
  {
      digitalWrite(dirZ, LOW);
      digitalWrite(stepZ, HIGH);
      delayMicroseconds(800);
      digitalWrite(stepZ, LOW);
      delayMicroseconds(800);
  }
    if(state4 == 0 && state2 == 1)
  {
      digitalWrite(dirA, HIGH);
      digitalWrite(stepA, HIGH);
      delayMicroseconds(800);
      digitalWrite(stepA, LOW);
      delayMicroseconds(800);
  }
  if(state1 == 1 && state2 == 1 && state3 == 1 && state4 == 1)
  {
    digitalWrite(stepX, LOW);
    delayMicroseconds(1000);
    digitalWrite(dirX, HIGH);
    for(int i = 0; i <= 600; i++)
    {
      digitalWrite(stepX, HIGH);
      delayMicroseconds(1000);
      digitalWrite(stepX, LOW);
      delayMicroseconds(1000);
    }
    digitalWrite(dirZ, HIGH);
    for(int i = 0; i <= 5050; i++)
    {
      digitalWrite(stepZ, HIGH);
      delayMicroseconds(2000);
      digitalWrite(stepZ, LOW);
      delayMicroseconds(2000); 
    }
    digitalWrite(dirY, LOW);
    for(int i = 0; i <= 1350; i++)
    {
      digitalWrite(stepY, HIGH);
      delayMicroseconds(1000);
      digitalWrite(stepY, LOW);
      delayMicroseconds(1000);
    }
    digitalWrite(dirA, LOW);
    for(int i = 0; i <=1280; i++)
    {
      digitalWrite(stepA, HIGH);
      delayMicroseconds(1000);
      digitalWrite(stepA, LOW);
      delayMicroseconds(1000);
    }
    state1 = 0;
    state2 = 0;
    state3 = 0;
    state4 = 0;
    curDegreeMotor1 = 0;
    curDegreeMotor2 = 0;
    curDegreeMotor3 = 0;
    curDegreeMotor4 = 0;
    tarDegreeMotor1 = 0;
    tarDegreeMotor2 = 0;
    tarDegreeMotor3 = 0;
    tarDegreeMotor4 = 0;
    statusSetHome = 0;
  }
}

void display() {
  lcd.setCursor(1, 0);
  lcd.print(tarDegreeMotor1);

  lcd.setCursor(5, 0);
  lcd.print(tarDegreeMotor2);

  lcd.setCursor(1, 1);
  lcd.print(tarDegreeMotor3);

  lcd.setCursor(5, 1);
  lcd.print(tarDegreeMotor4);
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
  // setHome();

  display();

  if(statusSetHome == 1){
    setHome();
  }  
 
}



