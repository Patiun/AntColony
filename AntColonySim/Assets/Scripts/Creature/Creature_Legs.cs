using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Legs : MonoBehaviour {

	private Rigidbody rb;
	private int count;
	private int lockOut;

	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponentInParent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (count >= lockOut) {
			rb.velocity = transform.right * 0;
		} else {
			count++;
		}
	}

	public void MoveForward() {
		rb.velocity = transform.forward * speed;
		lockOut = 10;
		count = 0;
	}

	public void MoveBackwards() {
		rb.velocity = transform.forward * -0.5f * speed; //Moves slower backwards
		lockOut = 10;
		count = 0;
	}

	void Turn(float amt){
		transform.parent.RotateAround (transform.position, transform.up, amt);

	}

	public void TurnLeft(float amt){
		Turn (-1 * amt);
	}

	public void TurnRight(float amt){
		Turn (amt);
	}
}
