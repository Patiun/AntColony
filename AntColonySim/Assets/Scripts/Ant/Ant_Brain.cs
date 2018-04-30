using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant_Brain : MonoBehaviour {

	public Ant_Eyes eyes;
	public Ant_Legs legs;
	public Ant_Antenae antenae;
	public Ant_Exoskeleton skin;
	public Ant_Mouth mouth;

	// Use this for initialization
	void Start () {
		eyes = GetComponentInChildren<Ant_Eyes> ();
		legs = GetComponentInChildren<Ant_Legs> ();
		antenae = GetComponentInChildren<Ant_Antenae> ();
		skin = GetComponent<Ant_Exoskeleton> ();
		mouth = GetComponentInChildren<Ant_Mouth> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Two Eye System:
		float[] dists = eyes.GetEyeDistances();
		if (dists [0] != 0f && dists [1] != 0f) {
			if (dists [0] > dists [1]) {
				legs.TurnRight (0.8f);
			} else {
				legs.TurnLeft (0.8f);
			}
			legs.MoveForward ();
		} else {
			if (dists [1] > 0) {
				legs.TurnLeft (0.8f);
				legs.MoveForward ();
			} else if (dists [0] > 0) {
				legs.TurnRight (0.8f);
				legs.MoveForward ();
			}
		}
	}
}
