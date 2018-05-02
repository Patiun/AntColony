using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Brain : MonoBehaviour {
	
	public Creature_Eyes eyes;
	public Creature_Legs legs;
	public Creature_Stomach stomach;
	public Creature_Mouth mouth;
	public Creature_Muscle headMuscle;

	private Model model;

	// Use this for initialization
	void Start () {
		eyes = GetComponentInChildren<Creature_Eyes> ();
		legs = GetComponentInChildren<Creature_Legs> ();
		stomach = GetComponentInChildren<Creature_Stomach> ();
		mouth = GetComponentInChildren<Creature_Mouth> ();

		BuildModel ();
	}

	private void BuildModel() {
		List<string> Sigma = new List<string> ();
		List<string> Delta = new List<string> ();
		List<State> states = new List<State> ();

		Sigma.AddRange (new string[] {"","a"}); //Load Sigma
		Delta.AddRange (new string[] {"","A"}); //Load Delta

		State s0 = new State ("0");
		State s1 = new State ("1");
		states.Add (s0);
		states.Add (s1);

		Transition transition0_1 = new Transition (s0, s1, "a", Delta);
		Transition transition1_0 = new Transition (s1, s0, Symbol.Epsilon.GetName (), Delta);
		List<Symbol> output0_1 = new List<Symbol> {new Symbol("",0.0f),new Symbol("A",1.0f) };
		List<Symbol> output1_0 = new List<Symbol> {new Symbol("",1.0f),new Symbol("A",0.0f) };
		transition0_1.GetOutputDistribution ().SetDistribution (output0_1);
		transition1_0.GetOutputDistribution ().SetDistribution (output1_0);
		s0.AddTransition (transition0_1);
		s1.AddTransition (transition1_0);

		model = new Model (Sigma,Delta,states,states[0]);
	}
	
	// Update is called once per frame
	void Update () {
		HandleDebug ();

		RandomWalk ();

		HandleOutput(model.TakeInput(new List<Symbol>()));
	}

	public void Die() {
		//DO THINGS FOR DEATH
		Debug.Log("Dead");
	}

	public void HandleOutput(Symbol output) {
		Debug.Log ("Output: "+output.GetName ()+" Streangth: "+output.GetValue());
	}

	List<Symbol> GetStimuli() {
		List<Symbol> stimuli = new List<Symbol> ();
		//string[] names = new string[1];
		//float[] strengths = new float[1];
		stimuli.Add(new Symbol("a",1.0f));
		return stimuli;
	}

	public void RandomWalk() {
		int rand = Random.Range (0, 10);
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
		case 9:
			legs.MoveBackwards();
			break;
		}
		if (stomach.starving) {
			Die ();
		}
	}

	public void HandleDebug() {
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
	}
}
