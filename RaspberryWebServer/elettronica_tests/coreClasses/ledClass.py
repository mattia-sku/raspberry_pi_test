#import RPi.GPIO as GPIO
from coreClasses.fakeGpio import GPIO
import time

class LedClass:
    def __init__(self, pinNumber):
        self.pinNumber = pinNumber # remember my pinNumber

    def turnOnOff(self, acceso):
        if acceso:
            GPIO.output(self.pinNumber,GPIO.HIGH)
        else:
            GPIO.output(self.pinNumber,GPIO.LOW)

    def __del__(self):
        GPIO.output(self.pinNumber,GPIO.LOW)