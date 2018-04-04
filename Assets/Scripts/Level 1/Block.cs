using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [Header("Hit")]
    [SerializeField] int hitPoints = 5;
    [SerializeField] ParticleSystem explodeEffect;

    void Update()
    {

    }

    void BlockDestroyed()
    {
        if (hitPoints == 0)
        {
            explodeEffect.Play();
            Destroy(gameObject, 0.5f);
        }
    }

    void OnParticleCollision(GameObject particleHolder)
    {
        if(particleHolder.name == "Player Bullet" || particleHolder.name == "Enemy Bullet")
        {
            hitPoints--;
            BlockDestroyed();
        }
    }
}
