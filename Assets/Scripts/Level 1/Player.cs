using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [Header("Movement")]
    [SerializeField] Quaternion startingRotation;
    [SerializeField] float startpos;
    [SerializeField] float speed = 1;
    [SerializeField] int timesHit = 0;
    [SerializeField] float movementSpeed = 5.0f;

    [Header("Shoot")]
    [SerializeField] ParticleSystem bullet;
    [SerializeField] ParticleSystem bulletEffect;

    [Header("Hit")]
    [SerializeField] Image healthbar;
    [SerializeField] int hitPoints = 10;
    [SerializeField] float hitStripPoints = 0.10f;
    [SerializeField] ParticleSystem explodeEffect;
    [SerializeField] ParticleSystem sparkleEffect;

    [SerializeField] GameObject hardBlock;

    public static ParticleSystem sparks;

    public static int collideWithPU = 0;

    public static bool _playerDies = false;

    public int pX;
    public int pY;
    public int pZ;
    

    void Start()
    {
        sparks = sparkleEffect;
        startingRotation = this.transform.rotation;
        startpos = this.transform.rotation.eulerAngles.y;
    }

    void Update()
    {
        PlayerMovement();
        PlayerShoots();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.fixedDeltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * movementSpeed * Time.fixedDeltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            timesHit++;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            timesHit--;
        }
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, timesHit, 0), Time.deltaTime * speed);
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

    void PlayerShoots()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletEffect.Play();
            bullet.Play();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            bulletEffect.Stop();
            bullet.Stop();
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void PlayerDies()
    {
        if (hitPoints == 0)
        {
            explodeEffect.Play();
            _playerDies = true;
            Destroy(gameObject, 0.5f);
            
        }
    }

    public static void PlayerSparkle()
    {
        sparks.Play();
    }


    void OnParticleCollision(GameObject particleHolder)
    {
        if (particleHolder.name == "Enemy Bullet")
        {
            healthbar.fillAmount = healthbar.fillAmount - hitStripPoints;
            hitPoints--;
            PlayerDies();
        }

    }

    
    void OnTriggerEnter(Collider powerUps)
    {
        if( powerUps.tag == "Life")
        {
            healthbar.fillAmount = healthbar.fillAmount + 1f;
            Destroy(powerUps.gameObject, 0.1f);
        }else if (powerUps.tag == "ProtectBase")
        {
            Instantiate(hardBlock, new Vector3(pX, pY, pZ), Quaternion.Euler(0, 0, 0));
            Destroy(powerUps.gameObject, 0.1f);
        }
    }

}
