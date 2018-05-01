using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour {

	public float foodValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (foodValue <= 0) {
			Destroy (this.gameObject);
		}
	}

	public float Consume(float amt) {
		if (amt >= foodValue) {
			foodValue = 0;
			return foodValue;
		} else {
			foodValue -= amt;
			return amt;
		}
	}

	public float GetFoodValue() {
		return foodValue;
	}
}
