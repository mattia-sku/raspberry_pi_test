#import RPi.GPIO as GPIO
from coreClasses.fakeGpio import GPIO

class PMWBase:
    def __init__(self, pinNumber):
        self.servo = GPIO.PWM(pinNumber,50) # pin (pinNumber) for servo, pulse 50Hz
        self.servo.start(0)

    def ChangeDutyCycle(self, pulse):
        self.servo.ChangeDutyCycle(pulse)

    def __del__(self):
        #finalize
        self.servo.stop()