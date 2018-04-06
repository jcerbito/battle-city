using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public void Try()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        Player._playerDies = false;
        Base._baseDestroyed = false;
        Timer.timer = 50;
    }

    public void Quit()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Splashscreen");
        Application.Quit();
    }
}
