using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant_Legs : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	private int count;
	private float lockOut;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			MoveForward ();
		}

		if (Input.GetKey (KeyCode.A)) {
			TurnLeft (1);
		}

		if (Input.GetKey (KeyCode.D)) {
			TurnRight (1);
		}

		if (count >= lockOut) {
			rb.velocity = transform.right * 0;
		} else {
			count++;
		}
	}

	public void MoveForward() {
		rb.velocity = transform.right * -1 * speed;
		lockOut = 10;
		count = 0;
	}

	void Turn(float amt){
		transform.RotateAround (transform.position, transform.up, amt);
	}

	public void TurnLeft(float amt){
		Turn (-1 * amt);
	}

	public void TurnRight(float amt){
		Turn (amt);
	}
}
