using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GME : MonoBehaviour
{
    [SerializeField]
    private bool nextLevel;
    public WinManager winManager;
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;
    public int LevelToUnlock = 2;
    Animator anim;
    float restartTimer;

    void Awake()
    {
        anim = GetComponent<Animator>();
        winManager = GetComponent<WinManager>();
    }

    /*public void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene("LEVEL EASY");
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }*/

    /*public void WinLevel()
    {
        nextLevel = true;
        PlayerPrefs.SetInt("LevelReached", LevelToUnlock);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }*/
}
