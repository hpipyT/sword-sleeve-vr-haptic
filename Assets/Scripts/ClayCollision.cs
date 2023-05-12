using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayCollision : MonoBehaviour
{
    public SSHConnect connection;
    bool recentCollision = false;

    // Start is called before the first frame update
    void Start()
    {
        connection = GameObject.Find("Connection").GetComponent<SSHConnect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && recentCollision == false)
        {
            recentCollision = true;
            StartCoroutine(CollisionTimer());
            connection.LaunchServoOption("4");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        connection.HaltJitter();
        StartCoroutine(ToggleToCenter());
    }

    public IEnumerator CollisionTimer()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        recentCollision = false;
    }

    public IEnumerator ToggleToCenter()
    {
        yield return new WaitForSeconds(1.5f);
        connection.LaunchServoOption("2");
        yield return null;
    }

}
