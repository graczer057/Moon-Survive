using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAiming : MonoBehaviour {

    PlayerMovement PM;

	// Use this for initialization
	void Start () {
        PM = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PM.SetArsenal("Gun");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PM.SetArsenal("Free");
        }
    }
}
