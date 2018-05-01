using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousContact : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Creature") {
			col.gameObject.GetComponentInParent<Creature_Brain> ().Die ();
		}
	}
}
