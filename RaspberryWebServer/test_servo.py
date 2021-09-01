import servoClass

servo = servoClass()

# Loop to allow user to set servo angle. Try/finally allows exit
# with execution of servo.stop and GPIO cleanup :)
while True:
    #Ask user for angle and turn servo to it
    angle = float(input('Enter angle between 0 & 180: '))
    servo.gotoAngle(angle)