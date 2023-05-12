using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    // servo options
    // 1: allow inward
    // 2: allow both
    // 3: allow outward
    // 4: TODO jitter resistance

    public SSHConnect connection;
    bool recentCollision = false;
    bool contacting = false;

    // Start is called before the first frame update
    void Start()
    {
        connection = GameObject.Find("Connection").GetComponent<SSHConnect>();
        //connection.ServoOptions();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && recentCollision == false)
        {
            contacting = true;
            recentCollision = true;
            StartCoroutine(CollisionTimer());
            connection.LaunchServoOption("1");
            //connection.DisconnectFromPi();
            //StartCoroutine(TensCountdown());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            contacting = false;
            connection.LaunchServoOption("mid");
            //connection.DisconnectFromPi();
        }
    }

    public IEnumerator CollisionTimer()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        recentCollision = false;
    }

    public IEnumerator TensCountdown()
    {
        yield return new WaitForSecondsRealtime(2.0f);

        if (contacting)
            connection.LaunchServoOption("5");
    }



}
