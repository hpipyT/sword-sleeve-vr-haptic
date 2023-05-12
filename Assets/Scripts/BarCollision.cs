using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCollision : MonoBehaviour
{
    // servo options
    // 1: allow inward
    // 2: allow both
    // 3: allow outward
    // 4: TODO jitter resistance

    public SSHConnect connection;
    bool recentCollision = false;
    bool contacting = false;

    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.3f, gameObject.transform.position.z);
        connection = GameObject.Find("Connection").GetComponent<SSHConnect>();
        //connection.ServoOptions();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && recentCollision == false && contacting == false)
        {
            contacting = true;
            recentCollision = true;
            StartCoroutine(CollisionTimer());
            connection.LaunchServoOption("1");
            //connection.DisconnectFromPi();
            StartCoroutine(TensCountdown());
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
        {
            StartCoroutine(RiseHim());
            connection.LaunchServoOption("5");
        }
    }

    public IEnumerator RiseHim()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Rising the bar");
        float t = 0.0f;
        float time = 1.0f;
        float speed = 10.0f;
        float step = speed * Time.deltaTime;
        Vector3 newPos = gameObject.transform.position;
        while (newPos.y < pos.y)
        {
            // interpolate where the droid will be at time (t/time), given start, and end (start + step)
            newPos = Vector3.Lerp(newPos, pos, speed * Time.fixedDeltaTime);
            if (Mathf.Abs(pos.y - newPos.y) < 0.08f)
            {
                newPos = pos;
            }
            this.gameObject.transform.position = newPos;


            t += Time.fixedDeltaTime;

            yield return null;
        }
        gameObject.transform.position = new Vector3(pos.x, pos.y - 0.3f, pos.z);

    }


}
