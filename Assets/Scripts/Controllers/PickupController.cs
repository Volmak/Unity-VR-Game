using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour 
{
	public int points = 1;
	public AudioSource pickupSound;

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Player"))
		{
			gameObject.SetActive (false);
			other.gameObject.GetComponent<PlayerController>().addPoints (points);

			pickupSound.transform.position = transform.position;
			pickupSound.Play ();
		}
	}
}
