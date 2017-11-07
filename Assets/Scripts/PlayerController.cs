using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb;
	Vector2 AxisInput;
	public float speed;
	Animator animator;
	private Transform puckPosition;
	public bool hasPuckPossession = false;
	Rigidbody2D puckrb;
	GameObject puck;
	bool team2Posession;
	GameObject rink;


	public void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		puckPosition = transform.Find ("PuckPosition");
		puck = GameObject.Find ("Pucks");
		rink = GameObject.Find ("Rink");
	}

	public void TakePossession(GameObject puck)
	{
		puck.transform.parent = puckPosition;
		puck.transform.position = Vector3.zero;
	}
	public void OnTriggerEnter2D (Collider2D col)
	{
		if(col.gameObject.tag.Equals("Puck")) {
			hasPuckPossession = true;		
			TakePossession (GameObject.FindGameObjectWithTag("Puck"));
		}
	}


	void FixedUpdate ()
	{
		if (hasPuckPossession)
		{
			
			puck.transform.localPosition = Vector3.zero;
		}
		//Movement
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) 
		{
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) 
			{
				rb.AddForce ( new Vector2(-1, 1) * speed);
				animator.SetInteger ("moveState", 5);
			} 
				else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) 
			{
				rb.AddForce (new Vector2(1, 1) * speed);
				animator.SetInteger ("moveState", 6);
			} 
			else 
			{
				rb.AddForce (Vector2.up * speed);
				animator.SetInteger ("moveState", 1);
			}
		} 

		else if (Input.GetKey (KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
		{
			if (Input.GetKey (KeyCode.A) ||Input.GetKey (KeyCode.LeftArrow))
			{
				rb.AddForce (new Vector2 (-1, -1) * speed);
				animator.SetInteger ("moveState", 7);
			} 
			else if (Input.GetKey (KeyCode.D) ||Input.GetKey( KeyCode.RightArrow)) 
			{
				rb.AddForce (new Vector2 (1, -1) * speed);
				animator.SetInteger ("moveState", 8);
			} 
			else 
			{
				rb.AddForce (Vector2.down * speed);
				animator.SetInteger ("moveState", 3);
			}
		}

		else if (Input.GetKey (KeyCode.D) ||Input.GetKey (KeyCode.RightArrow)) 
		{
			
			rb.AddForce (Vector2.right * speed);
			animator.SetInteger ("moveState", 2);
		}

		else if (Input.GetKey (KeyCode.A) || Input.GetKey( KeyCode.LeftArrow))
		{

			rb.AddForce (Vector2.left * speed);
			animator.SetInteger ("moveState", 4);
		}

		//Shooting
		if (Input.GetKey(KeyCode.LeftShift))
		{
				animator.SetBool ("Shot", true);
		}
			
	}
}