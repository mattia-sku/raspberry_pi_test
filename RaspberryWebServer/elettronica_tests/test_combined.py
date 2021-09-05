from coreClasses.servoClass import servoClass
from coreClasses.ledClass import LedClass

#import RPi.GPIO as GPIO
from coreClasses.fakeGpio import GPIO


GPIO.setmode(GPIO.BOARD)
GPIO.setup([7,11],GPIO.OUT)

servo = servoClass(7)
led = LedClass(11)

led.turnOnOff(True)
servo.rotateControlled(10,10)
led.turnOnOff(False)



GPIO.cleanup([7,11])