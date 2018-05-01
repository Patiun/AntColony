using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model {

	public List<string> Sigma;
	public List<string> Delta;
	public List<State> states;
	public State curState, lastState;
	public Symbol curOutput, lastOutput, curSymbol, lastSymbol;
	public List<Symbol> curInput;
	public List<Symbol> lastInput;
	public static float[] parameters = new float[] {0.05f,0.05f,0.2f,0.1f,1.0f,0.5f,0.9f,0.5f}; //alpha,beta,gamma,zeta,eta,kappa,nu,tau
	public float timeSinceLastInput = 0f;
	public float lastTime = 0f;

	public Model(List<string> Sigma, List<string> Delta, List<State> states, State startingState) {
		this.Sigma = Sigma;
		this.Delta = Delta;
		this.states = states;
		curState = startingState;
		lastState = startingState;
		lastOutput = Symbol.Epsilon;
		curOutput = Symbol.Epsilon;
		curSymbol = Symbol.Epsilon;
		lastSymbol = Symbol.Epsilon;
		curInput = new List<Symbol> ();
		lastInput = new List<Symbol> ();

		OutputDistribution p = new OutputDistribution (Delta);
		Debug.Log (p.GetChanceFor ("A"));
		p.UpdateSymbolProbability ("A", 0.5f);
		Debug.Log (p.GetChanceFor ("A"));

		lastTime = Time.time;
		timeSinceLastInput = Time.time - lastTime;
	}

	private bool InSigma(Symbol a) {
		return Sigma.Contains (a.GetName ());
	}

	private bool InDelta(Symbol o) {
		return Delta.Contains (o.GetName ());
	}

	public Symbol GetOutput() {
		return null;
	}

	public void TakeInput(List<Symbol> inputs) {
		timeSinceLastInput = Time.time - lastTime;
		lastTime = Time.time;
		Debug.Log (timeSinceLastInput);
		lastInput = curInput;
		curInput = inputs;
		if (timeSinceLastInput >= parameters [7]) {

		} else {

		}
	}

	public void CreateTransitions() {

	}

	public void UpdateExpectations() {

	}

	public void ApplyConditioning() {

	}

	public void UpdateConditioning() {

	}

	public void ApplyReward() {

	}

	public void ApplyPunishment() {

	}
}
