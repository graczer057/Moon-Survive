using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;

    public Text text;

    void Awake()
    {
        text.text = PlayerPrefs.GetInt("HighScore").ToString();
        score = PlayerPrefs.GetInt("HighScore");
        text = GetComponent<Text>();
        score = 0;
    }

	public void Update ()
    {
        text.text = score.ToString();
        PlayerPrefs.SetInt("HighScore", score);
        text.text = "Score: " + score;
	}
}
