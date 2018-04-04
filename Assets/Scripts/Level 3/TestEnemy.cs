using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour {

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

    public Transform taget;

    public int _onLoop;

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


        var dista = Vector3.Distance(taget.position, transform.position);
        var distaa = Vector3.Distance(this.transform.position, transform.position);


        if (currentTarget.transform.rotation.eulerAngles.y == 0)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 5f);
        }
        else if (currentTarget.transform.rotation.eulerAngles.y == 90)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5f);
        }
        else if (currentTarget.transform.rotation.eulerAngles.y == 180)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 5f);
        }
        else if (currentTarget.transform.rotation.eulerAngles.y == (-90))
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5f);
        }

        if (dist < 5)
        {
            if (destPoint < targetPoints.Length - 1)
            {
                destPoint++;
                agent.destination = targetPoints[destPoint].position;
            }

            if (_onLoop == 0)
            {
                if (destPoint == targetPoints.Length)
                {
                    agent.autoBraking = true;
                    agent.updateRotation = false;

                }
            }
            else if (_onLoop == 1)
            {
                if (destPoint == targetPoints.Length - 1)
                {

                    destPoint = 0;
                    agent.destination = targetPoints[destPoint].position;

                }
            }
            /**
            if (destPoint == targetPoints.Length - 1)
            {
                agent.Stop;
                destPoint = 0;
                agent.destination = targetPoints[destPoint].position;
                
            }**/
        }

        if (dista - distaa < 5)
        {

            if (taget.transform.rotation.eulerAngles.y == 0)
            {
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 5f);
            }
            else if (taget.transform.rotation.eulerAngles.y == 90)
            {
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5f);
            }
            else if (taget.transform.rotation.eulerAngles.y == 180)
            {
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 5f);
            }
            else if (taget.transform.rotation.eulerAngles.y == (-90))
            {
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5f);
            }

            agent.autoBraking = true;
            agent.destination = taget.position;

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
