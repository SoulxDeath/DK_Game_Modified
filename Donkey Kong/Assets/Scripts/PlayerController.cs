using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public LayerMask groundLayer;

	public float moveSpeed;
	public bool jump = false;
	public float jumpForce = 10f;

	public float moveVelocity;
	public bool grounded = false;

	//public Transform groundCheck;
	//public GameObject ladder;

	//public Rigidbody2D myRigidbody2D;

	void Start()
	{
		//myRigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		int yMovement = (int)Input.GetAxisRaw ("Vertical");
			if(yMovement == 1)
			{
				Jump();
			}

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
		if (Input.GetKey ("z") && grounded) 
		{
			jump = true;
		}
	}

	void FixedUpdate()
	{
		if(jump)
		{
			//myRigidbody2D.AddForce(new Vector2(0f, jumpForce));
				//jump = false;
		}
	}

	void Jump()
	{
		if (!IsGrounded ()) {
			return;
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpForce);
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
	/*void jumpPlayer()
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
	}*/
	bool IsGrounded() 
	{
		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = 1.0f;
		Debug.DrawRay(position, direction, Color.green);

		RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
		if (hit.collider != null) 
		{
			return true;
		}

		return false;
	}
}
