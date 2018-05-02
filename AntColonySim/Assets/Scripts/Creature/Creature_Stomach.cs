using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Stomach : MonoBehaviour {

	public float maxStorage;
	public float food;
	public float hungerPercentage;
	public float metabolismRate; //food consumed per second
	public bool hungry;
	public bool starving;

	private float starvingStrength = 1.0f;
	public float hungerStrength;

	// Use this for initialization
	void Start () {
		food = maxStorage;
		hungry = false;
		starving = false;
	}
	
	// Update is called once per frame
	void Update () {
		ConsumeFood (metabolismRate * Time.deltaTime);

		if (food != 0 && food <= maxStorage * hungerPercentage) {
			hungry = true;
			hungerStrength = (1 - food / maxStorage) / 1;
			//Debug.Log("Hungry" + hungerStrength);
		} else {
			hungry = false;
		}
	}

	public float GetNeededFood() {
		return maxStorage - food;
	}

	public float GetMaxFood() {
		return maxStorage;
	}

	public void AddFood(float amt){
		if (food + amt >= maxStorage) {
			food = maxStorage;
		} else {
			food += amt;
			starving = false;
		}
	}

	public void ConsumeFood(float amt) {
		if (food - amt <= 0) {
			food = 0;
			Starve ();
		} else {
			food -= amt;
			starving = false;
		}
	}

	private void Starve() {
		starving = true;
		//Debug.Log ("Starving");
	}

	public float GetInputStrength() { //Returns the input symbol strength for starving or hungry
		if (starving) {
			return starvingStrength;
		} else if (hungry) {
			return hungerStrength;
		} else {
			return 0.0f;
		}
	}

	public List<Symbol> GetStimuli() {
		List<Symbol> symbols = new List<Symbol> ();
		if (hungry) {
			symbols.Add (new Symbol ("Hunger", hungerStrength));
		} else if (starving) {
			symbols.Add (new Symbol ("Starving", starvingStrength));
		}
		return symbols;
	}
}
