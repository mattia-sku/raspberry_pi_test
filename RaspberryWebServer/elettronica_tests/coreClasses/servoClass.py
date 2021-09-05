import RPi.GPIO as GPIO
from PMWbase.PMWBase import PMWBase
import time

class servoClass(PMWBase):

    fullDegrees = 180

    def __init__(self, pinNumber):
        super(self, pinNumber)

    def angleToPulse(self, angle):
        return 2+(angle/18)

    def gotoAngle(self, angle):
        self.ChangeDutyCycle(self.angleToPulse(angle))

    def stabilize(self):
        self.ChangeDutyCycle(0)

    def gotoAngleSmooth(self, angle):
        self.gotoAngle(angle)
        time.sleep(0.5)
        self.stabilize()

    async def rotateControlled(self,steps,time):
        if(steps <= 0):
            raise Exception("steps MUST be greater than zero")

        singleStepTime = time / steps
        singleStepDegree = self.fullDegrees / steps

        currentDegree = 0

        while currentDegree < self.fullDegrees:
            self.gotoAngle(currentDegree)
            time.sleep(singleStepTime)
            currentDegree += singleStepDegree

        self.gotoAngle(self.fullDegrees)
        time.sleep(singleStepTime)
        self.stabilize()