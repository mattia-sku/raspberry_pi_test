from ledClass import LedClass

led = LedClass(7)

input("press enter for light")
led.turnOnOff(True)
input("press enter for dark")
led.turnOnOff(False)