using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {

    public static int spawners;

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        spawners = 6;
    }

    void Update()
    {
        text.text = "Spawners: " + spawners;
    }

}
