import smbus
import time

# step = 1
# val = 0x32
# val = 0x64
res = [0x00]
print("val: " , int(res[0]))

if (int(res[0]) > 69):
    print("Max allowed val exceeded, setting to 0")
    res = [0x00]

bus = smbus.SMBus(1)
potAddress = 0x2C
channel = 0x01

bus.write_i2c_block_data(potAddress, channel, res)


# 0 maximum resistance 255 minimum
data = bus.read_byte_data(potAddress, channel)
resistance = (data / 256.0) * 50.0
print ("Resistance : %2.f K" %resistance)

