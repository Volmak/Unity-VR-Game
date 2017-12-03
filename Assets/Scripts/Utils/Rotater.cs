using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour 
{
	private Vector3 angle;

	// Use this for initialization
	void Start ()
	{
		angle = new Vector3 (15, 30, 45);
	}

	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (angle * Time.deltaTime);
	}
}
