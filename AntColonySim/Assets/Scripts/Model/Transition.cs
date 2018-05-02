using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Transition {

	private State startState, endState;
	private string symbolName;
	private OutputDistribution distribution; //Better name
	private Expectation expecations;
	private bool isTemporary;
	private bool conditioned;

	public Transition(State startState, State endState,string symbolName, List<string> Delta) {
		this.startState = startState;
		this.endState = endState;
		this.symbolName = symbolName;

		distribution = new OutputDistribution (Delta);
		expecations = new Expectation ();
	}

	public State GetStartState() {
		return startState;
	}

	public State GetEndState() {
		return endState;
	}

	public string GetSymbolName() {
		return symbolName;
	}

	public OutputDistribution GetOutputDistribution() {
		return distribution;
	}

	public void AddToConfidence(float amount) {
		expecations.AddToConfidence (amount);
	}

	public float GetConfidence() {
		return expecations.GetConfidence ();
	}

	public Expectation getExpectations() {
		return expecations;
	}

	public void SetTemporary(bool status) {
		isTemporary = status;
	}

	public bool IsTemporary() {
		return isTemporary;
	}

	public void SetDistribution(OutputDistribution distribution) {
		this.distribution = distribution;
	}

	public void SetConfidence(float amt) {
		expecations.SetConfidence (amt);
	}

	public override string ToString() {
		return startState.GetName () + " -> " + endState.GetName ();
	}

}

