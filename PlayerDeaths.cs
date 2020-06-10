using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeaths : MonoBehaviour {

    public static int Dead;

    public Text text;

    public void Awake()
    {
        text.text = PlayerPrefs.GetInt("HighScore").ToString();
        Dead = PlayerPrefs.GetInt("HighScore");
        text = GetComponent<Text>();
        Dead = 0;
    }

    public void Update()
    {
        text.text = Dead.ToString();
        PlayerPrefs.SetInt("HighScore", Dead);
        text.text = "Deaths: " + Dead;
    }
}
