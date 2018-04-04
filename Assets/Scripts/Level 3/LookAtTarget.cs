using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookAtTarget : MonoBehaviour {

    [Header("Target Points")]
    public Transform targetPoints;
    private NavMeshAgent agent;
    public int _onLoop;
    public float speed = 5f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetPoints.position;
        
    }


    void Update () {
       
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(targetPoints.position - this.transform.position), .5f * Time.deltaTime);

        if (Vector3.Distance(targetPoints.position, this.transform.position) > 50)
        {
            this.transform.position += this.transform.forward * speed * Time.deltaTime;
        }
        else
        {
            agent.Stop();
        }
        
        
    }
}
