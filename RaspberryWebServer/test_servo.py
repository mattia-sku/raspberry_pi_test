from servoClass import servoClass

servo = servoClass(11)

while True:
    #Ask user for angle and turn servo to it
    angle = float(input('Enter angle between 0 & 180: '))
    servo.gotoAngle(angle)