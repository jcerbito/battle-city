using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class LevelOneAssasin : MonoBehaviour
{

    [Header("Hit")]
    [SerializeField]
    Image healthbar;
    [SerializeField] int hitPoints = 7;
    [SerializeField] ParticleSystem explodeEffect;

    [Header("Target Points")]
    public Transform[] targetPoints;
    private int destPoint = 0;
    public Transform currentTarget;
    private NavMeshAgent agent;

    [SerializeField] GameObject finalPoint;

    void Start()
    {
         
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetPoints[destPoint].position;
        agent.autoBraking = false;
        

    }

    void AgentLookAround()
    {
        var dist = Vector3.Distance(targetPoints[destPoint].position, transform.position);
        currentTarget = targetPoints[destPoint];

       
        if (currentTarget.transform.rotation.eulerAngles.y == 180)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 5f);
        }
        else if (currentTarget.transform.rotation.eulerAngles.y == 90)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * 5f);
        }
        else if (currentTarget.transform.rotation.eulerAngles.y == 360)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * 5f);
        }
        else if (currentTarget.transform.rotation.eulerAngles.y == -90)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 5f);
        }



        if (dist < 5)
        {
            if (destPoint < targetPoints.Length - 1)
            {
                destPoint++;
                agent.destination = targetPoints[destPoint].position;
            }



            if (destPoint == targetPoints.Length)
            {
                agent.autoBraking = true;

            }


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
            EnemiesKilled.enemiesKilled += 1;
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
