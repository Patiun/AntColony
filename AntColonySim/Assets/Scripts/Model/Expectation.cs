using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expectation{

	private List<Transition> otherTransitions;
	private List<float> expectancy;
	private float confidence;

	public Expectation() {
		otherTransitions = new List<Transition>();
		expectancy = new List<float> ();
		confidence = 0.1f;
	}

	public bool DoesExpectancyExistWith(Transition other) {
		return otherTransitions.Contains (other);
	}

	public void CreateExpectancyWith(Transition other) {
		expectancy.Add (Model.parameters [0]);
		otherTransitions.Add (other);
	}

	public void WeakenExpectencyWith(Transition other) {
		if (DoesExpectancyExistWith(other)) {
			int index = otherTransitions.IndexOf (other);
			float change = -1*Model.parameters[0]*expectancy [index];
			expectancy [index] += change;
			MultiplyConfidence (1 - Model.parameters[1] * Mathf.Abs(change));
		}
	}

	public void StrengthenExpectencyWith(Transition other) {
		if (DoesExpectancyExistWith(other)) {
			int index = otherTransitions.IndexOf (other);
			float change = Model.parameters[0]*(1-expectancy [index]);
			expectancy [index] += change;
			MultiplyConfidence (1 - Model.parameters[1] * Mathf.Abs(change));
		}
	}

	public void MultiplyConfidence(float amount) {
		confidence *= amount;
	}

	public void AddToConfidence(float amount) {
		confidence += amount;
	}

	public float GetConfidence(){
		return confidence;
	}

	public float GetExpectencyWith(Transition other) {
		if (DoesExpectancyExistWith (other)) {
			int index = otherTransitions.IndexOf (other);
			return expectancy [index];
		} else {
			return -1f;
		}
	}
}
