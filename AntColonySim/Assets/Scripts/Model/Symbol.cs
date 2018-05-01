using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Symbol {

	public static Symbol Epsilon = new Symbol (" ", 0.0f);

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
		
}
