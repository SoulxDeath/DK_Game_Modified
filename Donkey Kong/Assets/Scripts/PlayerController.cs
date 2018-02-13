using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;

	public float jump;

	public float moveVelocity;


	public GameObject ladder;

	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{


		if (Input.GetKey ("w")) 
		{
			moveUp ();
		}

		if(Input.GetKey ("s"))
		{
			moveDown ();
		}

		if(Input.GetKey ("a"))
		{
			moveLeft ();
		}

		if(Input.GetKey ("d"))
		{
			moveRight ();
		}

		//Jumping
		if (Input.GetKey ("z")) 
		{
			jumpPlayer ();
		}
	}

	void moveUp()
	{
		transform.position += new Vector3 (0, moveSpeed);
	}
	void moveDown()
	{
		transform.position -= new Vector3 (0, moveSpeed);
	}
	void moveLeft()
	{
		transform.position -= new Vector3 (moveSpeed, 0);
	}
	void moveRight()
	{
		transform.position += new Vector3 (moveSpeed, 0);
	}
	void jumpPlayer()
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
	}

}
