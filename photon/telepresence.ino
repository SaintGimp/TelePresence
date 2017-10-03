#include <Stepper.h>

int in1Pin = D0;
int in2Pin = D1;
int in3Pin = D2;
int in4Pin = D3;
 
Stepper motor(513, in1Pin, in2Pin, in3Pin, in4Pin);  

void setup() {
  pinMode(in1Pin, OUTPUT);
  pinMode(in2Pin, OUTPUT);
  pinMode(in3Pin, OUTPUT);
  pinMode(in4Pin, OUTPUT);
 
  motor.setSpeed(8);

   Particle.function("move", moveMotor);
   // This is saying that when we ask the cloud for the function "move", it will employ the function moveMotor() from this app.
  
}

void loop() {

}

int moveMotor(String command) {
    if (command=="left") {
        motor.step(50);
        return 1;
    }
    else if (command=="right") {
        motor.step(-50);
        return 0;
    }
    else {
        return -1;
    }
}
