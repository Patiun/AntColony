using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Brain : MonoBehaviour {
	
	public Creature_Eyes eyes;
	public Creature_Legs legs;
	public Creature_Muscle headMuscle;

	// Use this for initialization
	void Start () {
		eyes = GetComponentInChildren<Creature_Eyes> ();
		legs = GetComponentInChildren<Creature_Legs> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug
		if (Input.GetKey (KeyCode.W)) {
			legs.MoveForward ();
		}
		if (Input.GetKey (KeyCode.A)) {
			legs.TurnLeft (1);
		}
		if (Input.GetKey (KeyCode.D)) {
			legs.TurnRight (1);
		}
		if (Input.GetKey (KeyCode.K)) {
			headMuscle.ContractX (1);
		}
		if (Input.GetKey (KeyCode.I)) {
			headMuscle.ExtendX (1);
		}
		if (Input.GetKey (KeyCode.L)) {
			headMuscle.ContractY (1);
		}
		if (Input.GetKey (KeyCode.J)) {
			headMuscle.ExtendY (1);
		}
		if (Input.GetKey (KeyCode.U)) {
			headMuscle.ContractZ (1);
		}
		if (Input.GetKey (KeyCode.O)) {
			headMuscle.ExtendZ (1);
		}
	}

	void GetStimuli() {
		string[] symbols = new string[1];
		float[] strengths = new float[1];
	}
}
