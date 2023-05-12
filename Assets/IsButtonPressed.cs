
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class IsButtonPressed : MonoBehaviour
{

    public bool isPressed = false;
    public bool unityCallHintExperimental = false;

    public string iden;

    bool roomTesting = false;
    public SSHConnect connection;

    Vector3 firstPos;
    private void Start()
    {
        connection = GameObject.Find("Connection").GetComponent<SSHConnect>();
        firstPos = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed && other.tag == "Player")
        {
            isPressed = true;
            gameObject.transform.position = new Vector3(firstPos.x, firstPos.y - 0.1f, firstPos.z);
            Debug.Log("launching 6");
            connection.LaunchServoOption("6");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(WaitASec());
            gameObject.transform.position = new Vector3(firstPos.x, firstPos.y, firstPos.z);
        }
    }

    IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(1.0f);
        isPressed = false;
    }
}
;