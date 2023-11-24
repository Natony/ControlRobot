  #include <LiquidCrystal_I2C.h>

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
char c;
String dataIn;
int8_t indexOfA, indexOfB, indexOfC, indexOfD;

// Thêm biến để lưu trữ góc mục tiêu và góc hiện tại của động cơ
int curDegreeMotor[] = {0, 0, 0, 0};
int tarDegreeMotor[] = {0, 0, 0, 0};
int stepMotor[] = {0, 0, 0, 0};
char stringReceive[] = {'A', 'B', 'C', 'D'};
int step[] = {stepX, stepY, stepZ, stepA};
int direction[] = {dirX, dirY, dirZ, dirA};
unsigned int delayArray[] = {8000, 15000, 15000, 1000};

int stepMotorPerRev = 0;

void setup() {
  Serial.begin(9600);
  pinMode(ena, OUTPUT);

  lcd.init();
  lcd.backlight();

  pinMode(stepX, OUTPUT);
  pinMode(dirX, OUTPUT);

  pinMode(stepY, OUTPUT);
  pinMode(dirY, OUTPUT);

  pinMode(stepZ, OUTPUT);
  pinMode(dirZ, OUTPUT);

  pinMode(stepA, OUTPUT);
  pinMode(dirA, OUTPUT);

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
    String str_stpMotoDegree;
    int indexOf[4];

    for (int i = 0; i < 4; i++) {
        indexOf[i] = dataIn.indexOf(stringReceive[i]);
        if (indexOf[i] > -1) {
            str_stpMotoDegree = dataIn.substring((i == 0) ? 0 : indexOf[i - 1] + 1, indexOf[i]);
            tarDegreeMotor[i] = str_stpMotoDegree.toInt();
        }
    }

}

void motorStepper(int tarDegree, int &curDegree, int step, int dir, int delay)
{
  if(tarDegree != curDegree){
    int diffDegree = tarDegree - curDegree;
    int microsteps = 16;
    int stepsPerRevolution = 200;
    int stepMotor = diffDegree * (microsteps * stepsPerRevolution) / 360;
    if(step == 2){
      stepMotorPerRev = stepMotor * 4.5;
    }
    else if(step == 3){
      stepMotorPerRev = stepMotor * 4.5;
    }
    else if(step == 4){
      stepMotorPerRev = stepMotor * 3;
    }
    else{
      stepMotorPerRev = stepMotor * 2.5;
    }
  lcd.setCursor(0, 0);
  lcd.print(stepMotorPerRev);
  lcd.setCursor(0, 1);
  lcd.print(tarDegree);
    digitalWrite(dir, stepMotorPerRev > 0 ? LOW : HIGH);
    for (int i = 0; i < abs(stepMotorPerRev); i++) {
      digitalWrite(step, HIGH);
      delayMicroseconds(delay);
      digitalWrite(step, LOW);
      delayMicroseconds(delay);
    }
    curDegree = tarDegree;
  }
}


void FK(int numMotor){
  for(int i = 0; i < numMotor; i++){
    motorStepper(tarDegreeMotor[i], curDegreeMotor[i], step[i], direction[i], delayArray[i]);
  }
}
void loop() {
  Receive_Serial_Data();
  if (c == '\n') {
    Parse_the_Data();
    c = 0;
    dataIn = "";
  }

  FK(4); 
}



