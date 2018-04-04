using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class TestEnemy : MonoBehaviour {

    [Header("Hit")]
    [SerializeField]
    Image healthbar;
    [SerializeField] int hitPoints = 7;
    [SerializeField] ParticleSystem explodeEffect;

    [Header("Target Points")]
    public Transform targetPoints;

   // private int destPoint = 0;
   // public Transform currentTarget;
    private NavMeshAgent agent;

    public Transform taget;

    public int _onLoop;

    [SerializeField] GameObject finalPoint;

    

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetPoints.position;
        agent.autoBraking = false;

       
    }

    void AgentLookAround()
    {

        //this.transform.rotation.y = this.transform.rotation.eulerAngles.y;

       // taget.transform.rotation.eulerAngles.y = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(), Time.deltaTime); ;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(targetPoints.position - this.transform.position), .5f * Time.deltaTime);


        


        //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, this.transform.rotation.eulerAngles.y, 0), Time.deltaTime);


        // this.transform.rotation.eulerAngles.y = this.transform.rotation.y;

        if (Vector3.Distance(targetPoints.position, this.transform.position) > .5)
        {
            this.transform.position += this.transform.forward * 5f * Time.deltaTime;
        }

    }


    void Update()
    {
        AgentLookAround();

    }

    void EnemyDies()
    {
        if (hitPoints == 0)
        {
            explodeEffect.Play();
            Destroy(gameObject, 0.5f);

        }
    }

    void OnParticleCollision(GameObject particleHolder)
    {
        if (particleHolder.name == "Player Bullet")
        {
            healthbar.fillAmount = healthbar.fillAmount - 0.25f;
            hitPoints--;
            EnemyDies();
        }
    }
}
