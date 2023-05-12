using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureTens : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalibrateServo()
    {

    }


    // if Servo, servo script
    // connect to pi, turn dial a degree amount

    // if DigiPot, digiPot logic,
    // python script for digiPot


    // DigiPot setup:
    // 5V, Ground, SCL

    // import smbus
    // bus = smbus.SMBus(1)

    // potAddress = 0x2C
    // data = bus.read_byte_data(potAddress, 0x00)

    // resistance = (data / 256.0 ) * 10.0
    // print "Resistance : %.2f K" %resistance

    // bus.write_byte_data(potAddress, 0x00, 0x32)


}
