class GPIO:
    BOARD = 1
    OUT = 1
    IN = 1
    PMW = 1
    HIGH = "HIGH"
    LOW = "LOW"

    def PWM(pinNumber,freq):
        return PWM()

    def setmode(a):
        print(a)
    def setup(a, b):
        print(a)
    def output(a, b):
        print(a)
    def cleanup():
        print('cleaning')
    def setwarnings(flag):
        print('False')

class PWM:
    def ChangeDutyCycle(self,cycle):
        print(cycle)

    def start(self,number):
        print("start")

    def stop(self):
        print("stop")