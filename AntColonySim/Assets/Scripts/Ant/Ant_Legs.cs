using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant_Legs : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			Debug.Log ('!');
			rb.velocity = transform.right * -1 * speed;
		} else {
			rb.velocity = transform.right * 0;
		}
	}
}
