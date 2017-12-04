using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour {

	public int damagePerSec;
	public AudioSource damageSound;

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

		damageSound.Play (); //don't move the source, the player should always hear this loud and clear 
	}

	void OnTriggerExit(Collider other) 
	{
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerOnLava = null;
		}

		damageSound.Stop ();
	}
}
