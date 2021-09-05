import RPi.GPIO as GPIO

class PMWBase:
    def __init__(self, pinNumber):
        # Set GPIO numbering mode
        GPIO.setmode(GPIO.BOARD)
        # Set pin (pinNumber) as an output, and define as servo as PWM pin
        GPIO.setup(pinNumber,GPIO.OUT)
        self.servo = GPIO.PWM(pinNumber,50) # pin (pinNumber) for servo, pulse 50Hz
        self.servo.start(0)

    def ChangeDutyCycle(self, pulse):
        self.servo.ChangeDutyCycle(pulse)

    def __del__(self):
        #finalize
        self.servo.stop()
        GPIO.cleanup()
        print("destructor called")