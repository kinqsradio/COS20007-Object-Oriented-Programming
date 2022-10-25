import os
from time import sleep
from Clock import Clock

clock = Clock()

for x in range(86400):
    clock.Tick()
    print(clock.Time)
    sleep(1)
    os.system('clear')
