using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Animator anim;
    public float moveSpeed = 5f;
    GameObject Player;
    public float rotateSpeed = 100f;
    public Transform rightGunBone;
    public Transform leftGunBone;
    public Arsenal[] arsenal;
    PlayerShooting playerShooting;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (arsenal.Length > 0)
        {
            SetArsenal(arsenal[0].name);
        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            float zPos = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

            transform.Translate(new Vector3(0f, 0f, zPos));

            anim.SetBool("WALK", true);
            anim.SetBool("SPRINT", false);
        }
        else
        {
            moveSpeed = 0f;
        }

        if (moveSpeed == 0f)
        {
            anim.SetBool("SPRINT", false);
            anim.SetBool("WALK", false);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            anim.SetBool("AIMING", true);
            moveSpeed = 0f;
        }
        else
        {
            anim.SetBool("AIMING", false);
            moveSpeed = 5f;
            Sprint();
        }

    }

    public void Sprint()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 15f;
            anim.SetBool("SPRINT", true);
        }
        else
        {
            moveSpeed = 5f;
            anim.SetBool("SPRINT", false);
        }
    }

    public void SetArsenal(string name)
    {
        foreach (Arsenal hand in arsenal)
        {
            if (hand.name == name)
            {
                if (rightGunBone.childCount > 0)
                    Destroy(rightGunBone.GetChild(0).gameObject);
                if (leftGunBone.childCount > 0)
                    Destroy(leftGunBone.GetChild(0).gameObject);
                if (hand.rightGun != null)
                {
                    GameObject newRightGun = (GameObject)Instantiate(hand.rightGun);
                    newRightGun.transform.parent = rightGunBone;
                    newRightGun.transform.localPosition = Vector3.zero;
                    newRightGun.transform.localRotation = Quaternion.Euler(90, 0, 0);
                }
                if (hand.leftGun != null)
                {
                    GameObject newLeftGun = (GameObject)Instantiate(hand.leftGun);
                    newLeftGun.transform.parent = leftGunBone;
                    newLeftGun.transform.localPosition = Vector3.zero;
                    newLeftGun.transform.localRotation = Quaternion.Euler(90, 0, 0);
                }
                anim.runtimeAnimatorController = hand.controller;
                return;
            }
        }
    }

    [System.Serializable]
    public struct Arsenal
    {
        public string name;
        public GameObject rightGun;
        public GameObject leftGun;
        public RuntimeAnimatorController controller;
    }
}
