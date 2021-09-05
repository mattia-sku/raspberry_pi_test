from gpiozero import AngularServo,LED
from time import sleep

servo = AngularServo(17, min_angle=0, max_angle=180)
rgbLed = LED(4)

rgbLed.on()
sleep(1)
for a in range(0,180,10):
    servo.angle = a
    sleep(1)
sleep(1)
rgbLed.off()
