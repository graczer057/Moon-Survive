using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private Button medium;
    [SerializeField]
    private Button hard;
    private bool mediumBool;
    private bool hardBool;
    Medium mediumScript;
    Hard hardScript;
    Animator anim;
    public GameObject quitUI;

    public void Awake()
    {
        Cursor.visible = true;
        anim = GetComponent<Animator>();
        mediumScript = GetComponent<Medium>();
        hardScript = GetComponent<Hard>();
        string saveMedium = File.ReadAllText(Application.dataPath + "/medium.txt");
        Medium.SaveBollean saveBollean = JsonUtility.FromJson<Medium.SaveBollean>(saveMedium);
        mediumBool = saveBollean.medium;
        string saveHard = File.ReadAllText(Application.dataPath + "/hard.txt");
        Hard.SaveBoollean saveBoollean = JsonUtility.FromJson<Hard.SaveBoollean>(saveHard);
        hardBool = saveBoollean.hard;
        Debug.Log(mediumBool);
        Debug.Log(hardBool);
    }

    public void Easy()
    {
        anim.SetTrigger("INS");
        anim.SetBool("Ops", false);
        anim.SetBool("OPBA", false);
    }

    public void EasyButton()
    {
        SceneManager.LoadScene("LEVEL EASY");
    }

    public void Medium()
    {
        if(mediumBool == false)
        {
            medium.interactable = false;
        }
        else
        {
            medium.interactable = true;
        }
    }

    public void MediumButton()
    {       
        SceneManager.LoadScene("LEVEL MEDIUM");
    }

    public void Hard()
    {
        if(hardBool == false)
        {
            hard.interactable = false;
        }
        else
        {
            hard.interactable = true;
        }
    }

    public void HardButton()
    {
        SceneManager.LoadScene("LEVEL HARD");
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
