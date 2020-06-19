using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour {

    Animator anim;
    public float restartDelay = 1f;
    float restartTimer;
    public LevelSelection levelSelection;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        levelSelection = GetComponent<LevelSelection>();
    }

    public void Update()
    {
        if (GameObject.FindGameObjectWithTag("SPAWNER") == null)
        {
             anim.SetTrigger("WIN");

             restartTimer += Time.deltaTime;

             if (restartTimer >= restartDelay)
             {
                 //SceneManager.LoadScene("Menu");
                 Cursor.visible = true;
                 Cursor.lockState = CursorLockMode.None;
                //levelSelection.levelButtons[1].interactable = true;

            }
        }

    }
}
