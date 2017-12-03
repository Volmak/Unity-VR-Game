using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour {

	public int damagePerSec;

	private GameObject PlayerOnLava; //use array for multiplayer

	void Update ()
	{
		if (PlayerOnLava != null) {
			PlayerOnLava.GetComponent<PlayerController> ().takeDamage (damagePerSec * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerOnLava = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other) 
	{
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerOnLava = null;
		}
	}
}
