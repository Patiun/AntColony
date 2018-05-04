using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Mouth : MonoBehaviour {

	public List<string> consumableTags;
	public float consumptionSpeed;

	private Creature_Brain brain;
	private GameObject objectBeingEaten;

	// Use this for initialization
	void Start () {
		brain = GetComponentInParent<Creature_Brain> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Eat(Consumable food) {
		float amount = consumptionSpeed * Time.deltaTime;
		food.Consume (amount);
		brain.stomach.AddFood (amount); //Inately connects to the Stomach
	}

	void OnTriggerEnter(Collider col) {
		if (consumableTags.Contains (col.tag)) {
			GameObject other = col.gameObject;
			Consumable food = other.GetComponent<Consumable> ();
			if (food != null) {
				objectBeingEaten = other;
				Eat (food);
			}
		}
	}
	void OnTriggerStay(Collider col) {
		if (col.gameObject == objectBeingEaten) {
			Consumable food = objectBeingEaten.GetComponent<Consumable> ();
			if (food != null) {
				Eat (food);
			}
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject == objectBeingEaten) {
			objectBeingEaten = null;
		}
	}

	public List<Symbol> GetStimuli() {
		List<Symbol> symbols = new List<Symbol> ();
		if (objectBeingEaten != null) {
			symbols.Add (new Symbol ("Eating", 1 - brain.stomach.GetNeededFood () / brain.stomach.GetMaxFood ()));
		}
		return symbols;
	}
}
