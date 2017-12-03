using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public float maxSpeed;
	public Text pointsText;

	private Rigidbody rb;
	private Vector3 force;
	private int points;

	void Start()
	{
		points = 0;
		force.y = 0; //not needed, but a reminder that the movement is set to 2d (x,z)
		updatePointsText ();
		rb = GetComponent<Rigidbody>();
	}

	// Perform on every Physics calculation
	void FixedUpdate () 
	{
		rb.AddForce (force);
	}

	public void giveDirection (Vector3 pointer)
	{
		Vector3 temp = pointer - transform.position;
		force.x = Mathf.Clamp (temp.x, -maxSpeed, maxSpeed);
		force.z = Mathf.Clamp (temp.z, -maxSpeed, maxSpeed);
	}

	public void addPoints (int numberOfPoints)
	{
		points += numberOfPoints;
		updatePointsText ();
	}

	void updatePointsText ()
	{
		pointsText.text = "Points: " + points.ToString();
	}
}
