from coreClasses.servoClass import servoClass
from coreClasses.ledClass import ledClass
import asyncio

async def process():
    servo = servoClass(7)
    led = ledClass(11)

    led.turnOnOff(True)
    await servo.rotateControlled(10,10)
    led.turnOnOff(False)

asyncio.run(process())