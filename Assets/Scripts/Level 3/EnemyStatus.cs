using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour {

    [Header("Hit")]
    [SerializeField] Image healthbar;
    [SerializeField] int hitPoints = 7;
    [SerializeField] float hitStripPoints = 0.25f;
    [SerializeField] ParticleSystem explodeEffect;

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
            healthbar.fillAmount = healthbar.fillAmount - hitStripPoints;
            hitPoints--;
            EnemyDies();
        }
    }
}
