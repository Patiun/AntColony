using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour {

	public float foodValue;
	private float maxFood;
	public bool scaling;

	// Use this for initialization
	void Start () {
		maxFood = foodValue;
	}
	
	// Update is called once per frame
	void Update () {
		if (foodValue <= 0) {
			Destroy (this.gameObject);
		}

		if (scaling) {
			this.transform.localScale = new Vector3 (foodValue / maxFood, foodValue / maxFood, foodValue / maxFood);
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
