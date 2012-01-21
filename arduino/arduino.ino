int pushval = 0;      // pushbutton value

int push1 = 8;   // pushbuttons pins
int push2 = 9;
int push3 = 10;

int led1 = 11;   // leds pins
int led2 = 12;
int led3 = 13;

bool l1State = false;  // leds states
bool l2State = false;
bool l3State = false;

void setup() {
  // declare push buttons
  pinMode(push1, INPUT);    // pushbutton1
  pinMode(push2, INPUT);    // pushbutton2
  pinMode(push3, INPUT);    // pushbutton3
  
  // declare lights
  pinMode(led1, OUTPUT);  // LED 1
  pinMode(led2, OUTPUT);  // LED 2
  pinMode(led3, OUTPUT);  // LED 3

  // Lights Init - All off at start
  digitalWrite(led1, LOW);  // turn LED1 OFF
  digitalWrite(led2, LOW);  // turn LED2 OFF
  digitalWrite(led3, LOW);  // turn LED3 OFF
  Serial.begin(9600);
}

void l1(bool state) {
   digitalWrite(11, state ? HIGH : LOW);
   l1State = state;
}

void l2(bool state) {
   digitalWrite(12, state ? HIGH : LOW);
   l2State = state;
}

void l3(bool state) {
   digitalWrite(13, state ? HIGH : LOW);
   l3State = state;
}

void togglel1() {
  l1(!l1State);
  printStates();
}

void togglel2() {
  l2(!l2State);
  printStates();
}

void togglel3() {
  l3(!l3State);
  printStates();
}

// Writes to Serial controlled states to be parsed
void printStates() {
  Serial.print("L1-"); Serial.print(l1State, DEC);
  Serial.print("L1-"); Serial.print(l1State, DEC);
  Serial.print("L3-"); Serial.print(l1State, DEC);
}

void loop(){  

  // remote control
  if (Serial.available() > 0) {
    int b = Serial.read();
    if (b == 'a')  {
      Serial.println("L1-ACTION");
      togglel1();
    }
    
    if (b == 'b')  {
      Serial.println("L2-ACTION");
      togglel2();
    }
    
    if (b == 'c')  {
      Serial.println("L3-ACTION");
      togglel3();
    }
    
    Serial.flush();
  }

  // hardware buttons tretaments
  pushval = digitalRead(push1);  // read input value
  if (pushval == HIGH) {         // check if the input is HIGH (button released)
      Serial.println("L1-ACTION");
      togglel1();
  } 
  
  pushval = digitalRead(push2);  
  if (pushval == HIGH) {        
      Serial.println("L2-ACTION");
      togglel2();
  } 
  
  pushval = digitalRead(push3);  
  if (pushval == HIGH) {        
      Serial.println("L3-ACTION");
      togglel3();
  } 
}
