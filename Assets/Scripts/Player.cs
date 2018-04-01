using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Quaternion startingRotation;
    public float startpos;
    public float speed = 1;
    private int timesHit = 0;
    public float movementSpeed = 5.0f;


    void Start()
    {
        //save the starting rotation
        startingRotation = this.transform.rotation;
        startpos = this.transform.rotation.eulerAngles.y; 
    }

   

    void Update()
    {
       
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.position += transform.forward * Time.deltaTime * movementSpeed;
            transform.Translate(Vector3.forward * movementSpeed * Time.fixedDeltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * movementSpeed * Time.fixedDeltaTime, Space.Self);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            timesHit++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            timesHit--;
        }

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, startpos + (timesHit * 90), 0), Time.deltaTime * speed);
        

    }

    IEnumerator Rotate(float rotationAmount)
    {
        Quaternion finalRotation = Quaternion.Euler(0, rotationAmount, 0) * startingRotation;

        while (this.transform.rotation != finalRotation)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, finalRotation, Time.deltaTime * speed);
            yield return 0;
        }
    }
}
