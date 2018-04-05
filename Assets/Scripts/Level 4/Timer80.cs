﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer80 : MonoBehaviour {

    public static float timer = 80f;
    Text text;
    string fullTime;

    void Start()
    {
        text = GetComponent<Text>();

    }

    void Update()
    {
        //text.text = "timer: " + timer;
        fullTime = "timer: " + string.Format("{0:00}", timer);
        text.text = fullTime;
    }
}
