using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookAtTarget : MonoBehaviour {

    [Header("Target Points")]
    public Transform targetPoints;
    private NavMeshAgent agent;
    public int status;
    public float speed = 5f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetPoints.position;
        
    }


    void Update () {
       
        if (status == 1) { 
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(targetPoints.position - this.transform.position), .5f * Time.deltaTime);

                if (Vector3.Distance(targetPoints.position, this.transform.position) > 50)
                {
                        this.transform.position += this.transform.forward * speed * Time.deltaTime;
                }
                else
                {
                        agent.isStopped = true;
                }
        }else if (status == 2)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(targetPoints.position - this.transform.position), .5f * Time.deltaTime);

            if (Vector3.Distance(targetPoints.position, this.transform.position) > 0)
            {
               this.transform.position += this.transform.forward * speed * Time.deltaTime;
               
            }
        }

    }
}
