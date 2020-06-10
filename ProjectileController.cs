using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProjectileController : MonoBehaviour {


	float speed = 20f;
	GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		transform.position += transform.forward * speed * Time.deltaTime;

		if (Vector3.Distance(transform.position, player.transform.position) > 20f)
		{
			Destroy(gameObject);
		}


	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Enemy")
		{
			//coll.gameObject.GetComponent<EnemyController> ().Harm();

			Destroy(gameObject);

		}
	}


    
}
