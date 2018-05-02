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

	private int count;
	private int waitTime = 100;
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
		List<State> rewards = new List<State> ();
		List<State> punishments = new List<State> ();

		Sigma.AddRange (new string[] {"EPSILON","LeftEye","RightEye","Hungry","Starving","Eating","Dead"}); //Load Sigma
		Delta.AddRange (new string[] {"EPSILON","MoveForward","MoveBackwards","TurnLeft","TurnRight","HeadContractX","HeadContractY","HeadContractZ","HeadExtendY","HeadExtendZ",}); //Load Delta

		State s0 = new State ("0"); //Default
		State s1 = new State ("1"); //
		states.Add (s0);
		states.Add (s1);

		Transition transition0_1 = new Transition (s0, s1, "a", Delta);
		Transition transition1_0 = new Transition (s1, s0, Symbol.Epsilon.GetName (), Delta);
		Transition transition0_0 = new Transition (s0, s0, Symbol.Epsilon.GetName (), Delta);
		List<Symbol> output0_1 = new List<Symbol> {new Symbol("EPSILON",0.0f),new Symbol("A",1.0f) };
		List<Symbol> output1_0 = new List<Symbol> {new Symbol("EPSILON",1.0f),new Symbol("A",0.0f) };
		transition0_1.GetOutputDistribution ().SetDistribution (output0_1);
		transition1_0.GetOutputDistribution ().SetDistribution (output1_0);
		transition0_0.getExpectations ().SetConfidence (100);
		transition0_1.getExpectations ().SetConfidence (100);
		transition1_0.getExpectations ().SetConfidence (100);
		s0.AddTransition (transition0_1);
		s1.AddTransition (transition1_0);
		s0.AddTransition (transition0_0);

		model = new Model (Sigma,Delta,states,s0,rewards,punishments);
	}
	
	// Update is called once per frame
	void Update () {
		HandleDebug ();
		if (count >= waitTime) {
			HandleOutput (model.TakeInput (GetStimuli ()));
		} else {
			count++;
		}
		//RandomWalk ();

	}

	public void Die() {
		//DO THINGS FOR DEATH
		Debug.Log("Dead");
	}

	public void HandleOutput(Symbol output) {
		Debug.Log ("Output: "+output.GetName ()+" Strength: "+output.GetValue());
		switch (output.GetName ()) {
			case "MoveForward":
				legs.MoveForward ();
				break;
			case "TurnLeft":
				legs.TurnLeft (20*output.GetValue());
				break;
			case "TurnRight":
				legs.TurnRight (20*output.GetValue());
				break;
			case "HeadContractX":
				headMuscle.ContractX (5);
				break;
			case "HeadExtendX":
				headMuscle.ExtendX (5);
				break;
			case "HeadContractY":
				headMuscle.ContractY (5);
				break;
			case "HeadExtendY":
				headMuscle.ExtendY (5);
				break;
			case "HeadContractZ":
				headMuscle.ContractZ (5);
				break;
			case "HeadExtendZ":
				headMuscle.ExtendZ (5);
				break;
			case "MoveBackwards":
				legs.MoveBackwards();
				break;
			case "EPSILON":
				count = 0;
				break;
		}
	}

	List<Symbol> GetStimuli() {
		List<Symbol> stimuli = new List<Symbol> ();
		stimuli.AddRange (eyes.GetStimuli ());
		stimuli.AddRange (stomach.GetStimuli ());
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
		if (Input.GetKeyDown (KeyCode.Return)) {
			HandleOutput(model.TakeInput(GetStimuli()));
		}
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
