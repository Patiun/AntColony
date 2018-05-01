using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Brain : MonoBehaviour {
	
	public Creature_Eyes eyes;
	public Creature_Legs legs;
	public Creature_Stomach stomach;
	public Creature_Mouth mouth;
	public Creature_Muscle headMuscle;

	// Use this for initialization
	void Start () {
		eyes = GetComponentInChildren<Creature_Eyes> ();
		legs = GetComponentInChildren<Creature_Legs> ();
		stomach = GetComponentInChildren<Creature_Stomach> ();
		mouth = GetComponentInChildren<Creature_Mouth> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug
		if (Input.GetKey (KeyCode.W)) {
			legs.MoveForward ();
		}
		if (Input.GetKey (KeyCode.S)) {
			legs.MoveBackwards ();
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
		if (Input.GetKeyDown (KeyCode.F)) {
			stomach.AddFood (1);
		}

		/*int rand = Random.Range (0, 9);
		switch (rand) {
		case 0:
			legs.MoveForward ();
			break;
		case 1:
			legs.TurnLeft (15);
			break;
		case 2:
			legs.TurnRight (15);
			break;
		case 3:
			headMuscle.ContractX (5);
			break;
		case 4:
			headMuscle.ExtendX (5);
			break;
		case 5:
			headMuscle.ContractY (5);
			break;
		case 6:
			headMuscle.ExtendY (5);
			break;
		case 7:
			headMuscle.ContractZ (5);
			break;
		case 8:
			headMuscle.ExtendZ (5);
			break;
		}*/
	}

	void GetStimuli() {
		string[] symbols = new string[1];
		float[] strengths = new float[1];
	}
}
