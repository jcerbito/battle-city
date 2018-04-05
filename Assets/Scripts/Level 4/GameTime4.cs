using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime4 : MonoBehaviour {

    private float countdown = 1f;

    void Start()
    {

    }


    void Update()
    {
        Timer.timer -= 1 * Time.deltaTime;
        Timer.timer = Mathf.Clamp(Timer.timer, 0, 50);

        if (Base._baseDestroyed == true || Player._playerDies == true)
        {
            countdown -= 1 * Time.deltaTime;
            countdown = Mathf.Clamp(countdown, 0, 1);
            if (countdown == 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Gameover");
            }
        }

        if (Timer.timer == 0 && Player._playerDies == false)
        {
            Player.PlayerSparkle();
            countdown -= 1 * Time.deltaTime;
            countdown = Mathf.Clamp(countdown, 0, 1);
            if (countdown == 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level5");
            }
        }
    }
}
