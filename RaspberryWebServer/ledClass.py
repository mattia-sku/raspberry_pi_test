# Import libraries
import RPi.GPIO as GPIO
import time

class LedClass:
    def __init__(self, pinNumber):
        # Set GPIO numbering mode
        GPIO.setmode(GPIO.BOARD)
        GPIO.setup(pinNumber,GPIO.OUT)
        self.pinNumber = pinNumber # remember my pinNumber

    def turnOnOff(self, acceso):
        if acceso:
            GPIO.output(self.pinNumber,GPIO.HIGH)
        else:
            GPIO.output(self.pinNumber,GPIO.LOW)

    def __del__(self):
        #finalize
        GPIO.cleanup()
        print("destructor called")