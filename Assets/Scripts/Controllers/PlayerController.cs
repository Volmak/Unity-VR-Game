using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public float maxSpeed;
	public int points;
	public float hp;
	public bool displayHPDecimal;

	public Text pointsText;
	public Text hpText;
	public Text alertText;
	public Text instructionsText;

	public AudioSource bumpSound;
	public float velocityToSound;
	public AudioSource winSound;
	public AudioSource loseSound;

	private Rigidbody rb;
	private Vector3 force;
	private bool isAlive = true;

	void Start()
	{
		points = 0;
		force.y = 0; //not needed, but a reminder that the movement is set to 2d (x,z)
		rb = GetComponent<Rigidbody>();

		updatePointsText ();
		updateHPText ();
	}

	// Perform on every Physics calculation
	void FixedUpdate () 
	{
		rb.AddForce (force);
	}

	void OnCollisionEnter (Collision collision)
	{
		/* play a bump sound on collision */
		ContactPoint contact = collision.contacts[0];
		bumpSound.transform.position = contact.point;
		bumpSound.volume = collision.relativeVelocity.magnitude * velocityToSound;
		bumpSound.Play ();
	}

	public void giveDirection (Vector3 pointer)
	{
		if (isAlive) {
			Vector3 temp = pointer - transform.position;
			force.x = Mathf.Clamp (temp.x, -maxSpeed, maxSpeed);
			force.z = Mathf.Clamp (temp.z, -maxSpeed, maxSpeed);
		}
	}

	public void removeForce ()
	{
		force.x = 0;
		force.z = 0;
	}

	public void addPoints (int numberOfPoints)
	{
		points += numberOfPoints;
		updatePointsText ();

		if (GameController.Game.checkWin (points)) {
			win ();
		}
	}

	public void takeDamage (float damage)
	{
		if (isAlive && GameController.Game.getIsRunning()) 
		{
			hp -= damage;

			if (hp <= 0) {
				lose ();
			}

			updateHPText ();
		}
	}

	void updatePointsText ()
	{
		pointsText.text = "Score: " + points.ToString();
	}

	void updateHPText ()
	{
		string dispVal = displayHPDecimal ? Mathf.Round (hp + 0.5f).ToString () : hp.ToString ();
		hpText.text = "Hit Points: " + dispVal;
	}

	void win ()
	{
		winSound.Play ();
		alertText.text = "<b>YOU'VE WON!!!</b>";
		displayGameOverMessage ();
	}

	void lose ()
	{
		isAlive = false;
		hp = 0;
		removeForce ();

		loseSound.Play ();
		alertText.text = "<color=red><b>YOU'VE LOST!!!</b></color>";
		displayGameOverMessage ();

		GameController.Game.checkLose ();
	}

	void displayGameOverMessage ()
	{
		instructionsText.text = "Take a comfortable position \n for the game will now restart";
	}
}
