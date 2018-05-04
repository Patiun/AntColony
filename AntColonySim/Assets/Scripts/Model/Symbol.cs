using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Symbol {

	public static Symbol Epsilon = new Symbol ("EPSILON", 1.0f);

	private string name;
	private float strength;

	public Symbol(string name, float strength) {
		this.name = name;
		this.strength = strength;
	}

	public float GetValue() {
		return strength;
	}

	public string GetName() {
		return name;
	}

	public void SetValue(float val) {
		strength = val;
	}

	public override string ToString ()
	{
		return name + ":" + strength;
	}
		
}
