using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesKilled : MonoBehaviour {


    public static int enemiesKilled;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = "enemies killed: " + enemiesKilled;
    }

}
