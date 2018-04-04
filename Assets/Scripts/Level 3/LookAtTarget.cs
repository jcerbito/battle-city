using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookAtTarget : MonoBehaviour {

    [Header("Target Points")]
    public Transform targetPoints;
    private NavMeshAgent agent;
    //public Transform taget;
    public int _onLoop;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetPoints.position;
        
    }


    void Update () {
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(targetPoints.position - this.transform.position), .5f * Time.deltaTime);

        if (Vector3.Distance(targetPoints.position, this.transform.position) > 50)
        {
            this.transform.position += this.transform.forward * 5f * Time.deltaTime;
        }
        else
        {
            agent.Stop();
        }
    }
}
