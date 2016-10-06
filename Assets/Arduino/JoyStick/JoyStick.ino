int joyPin1 = 0;                 // slider variable connecetd to analog pin 0
int joyPin2 = 1;                 // slider variable connecetd to analog pin 1
int value1 = 0;                  // variable to read the value from the analog pin 0
int value2 = 0;                  // variable to read the value from the analog pin 1

void setup()
{

 Serial.begin(9600);
}



void loop()
{
 // reads the value of the variable resistor
 value1 = analogRead(joyPin1);
 // this small pause is needed between reading
 // analog pins, otherwise we get the same value twice
 delay(100);
 // reads the value of the variable resistor
 value2 = analogRead(joyPin2);

value1=  map(value1, 0, 1023, 0, 360);
value2=  map(value2, 0, 1023, 0, 360);

 Serial.print(value1);
 Serial.print(",");
 Serial.print(value2);
 Serial.print(",");
 Serial.println(255);
}
