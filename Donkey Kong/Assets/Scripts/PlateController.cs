using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour {


	public int dir;
	public Collider2D currentFloor;
	public float timeUntilFallDown = int.MaxValue;
	public float speed = 5f;
	public bool grounded = true;
	public float plateSpeed = 10f;
	public Rigidbody2D platePrefab;
	public Transform spawnPoint;

	void Start()
	{
		dir = 1;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Translate (speed * Time.deltaTime, 0, 0);
		if (timeUntilFallDown != int.MaxValue) 
		{
			timeUntilFallDown -= Time.fixedDeltaTime;
		}
		if (timeUntilFallDown <= 0) 
		{
			fallDown ();
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		float force = 30f;
		if(collision.collider.gameObject.name == ("Wall West"))
		{
			dir = 1;
		}
		else if(collision.collider.gameObject.name == ("Wall East"))
		{
			dir = -1;
		}
		else if(collision.collider.gameObject.name.Contains("Floor"))
		{
			currentFloor = collision.collider;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(force*dir, 0.0f));
		}
	}

	void fallDown()
	{
		Physics2D.IgnoreCollision(currentFloor, gameObject.GetComponent<Collider2D>());
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		grounded = false;
		timeUntilFallDown = int.MaxValue;
		dir*= -1;
	}

}
