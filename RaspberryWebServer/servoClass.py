# Import libraries
import RPi.GPIO as GPIO
import time

class servoClass:
    def __init__(self, pinNumber):
        # Set GPIO numbering mode
        GPIO.setmode(GPIO.BOARD)
        # Set pin (pinNumber) as an output, and define as servo as PWM pin
        GPIO.setup(pinNumber,GPIO.OUT)
        self.servo = GPIO.PWM(pinNumber,50) # pin (pinNumber) for servo, pulse 50Hz

    def gotoAngle(self, angle):
        self.servo.ChangeDutyCycle(2+(angle/18))
        time.sleep(0.5)
        self.servo.ChangeDutyCycle(0)

    def __del__(self):
        #finalize
        self.servo.stop()
        GPIO.cleanup()
        print("destructor called")