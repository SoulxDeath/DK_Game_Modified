using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour {



	public float speed = 5f;


	void Start()
	{

	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Translate (speed * Time.deltaTime, 0, 0);
	}
}
