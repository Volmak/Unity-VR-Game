using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridController : MonoBehaviour
{
	public GameObject Plane;
	public GameObject Player;
	public GameObject ViewPoint;
	public Camera Camera;

	private float multiplier;
	private PlayerController PlayerController;
	private bool isPointerInside;

	// Use this for initialization
	void Start () 
	{
		PlayerController = Player.gameObject.GetComponent<PlayerController>();

		float baseHeight = Plane.transform.position.y;
		float cameraHeight = ViewPoint.transform.position.y;

		multiplier = (cameraHeight - baseHeight) / (cameraHeight - transform.position.y);
	}
	
	//Trigger isPointerInside flag
	public void setIsPointerInside (bool isInside)
	{
		isPointerInside = isInside;
	}
		
	void FixedUpdate () 
	{
		// if looking at the coordinate grid
		if (isPointerInside) {
			// cast a ray to get the coordinates
			RaycastHit hit;
			Ray ray = Camera.main.ViewportPointToRay (new Vector3 (0.5F, 0.5F, 0));

			if (Physics.Raycast (ray, out hit)) {
				// multiply by the distance multiplier and pass the direction to the player
				PlayerController.giveDirection (hit.point * multiplier);
			}
		} else {
			PlayerController.removeForce();
		}
	}
}
