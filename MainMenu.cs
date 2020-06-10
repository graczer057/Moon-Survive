using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    Animator anim;
    public GameObject quitUI;

    public void Start()
    {
        Cursor.visible = true;
        anim = GetComponent<Animator>();
    }

    public void Easy()
    {
        SceneManager.LoadScene("LEVEL EASY");
    }

    public void Hard()
    {
        SceneManager.LoadScene("LEVEL HARD");
    }

    public void Ez()
    {   
        anim.SetTrigger("INS");
        anim.SetBool("Ops", false);
        anim.SetBool("OPBA", false);
    }

    public void Medium()
    {
        SceneManager.LoadScene("LEVEL MEDIUM");
    }

    public void Options()
    {
        anim.SetBool("Ops", true);
        anim.SetBool("OPBA", false);
    }

    public void RestartOptions()
    {
        anim.SetBool("Ops", false);
        anim.SetBool("OPBA", true);
    }

    public void Surv()
    {
        SceneManager.LoadScene("Survival");
    }

    public void QuitGame()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (Input.GetKeyDown(KeyCode.F4))
            {
                quitUI.SetActive(true);
                PauseMenu.GameIsPaused = true;
                Cursor.visible = true;
            }
        }
        Application.Quit();
    }

}
