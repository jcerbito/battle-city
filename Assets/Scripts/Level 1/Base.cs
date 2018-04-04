using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

    [Header("Hit")]
    [SerializeField] int hitPoints = 7;
    [SerializeField] ParticleSystem effect;
    
    public static bool _baseDestroyed = false;

    void BaseDestroyed()
    {
        if (hitPoints == 0)
        {
            
            effect.Play();
            _baseDestroyed = true;
            Destroy(gameObject, 0.5f);
           
                
            
        }
    }

    void OnParticleCollision(GameObject particleHolder)
    {
        if (particleHolder.name == "Enemy Bullet")
        {
            hitPoints--;
            BaseDestroyed();
        }
    }

}
