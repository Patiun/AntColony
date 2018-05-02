using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputDistribution {

	private List<Symbol> symbols;

	public OutputDistribution (List<string> Delta) {
		symbols = new List<Symbol> ();
		foreach (string name in Delta) {
			float weight = 0.0f;
			if (name == Symbol.Epsilon.GetName ()) {
				weight = Model.parameters[4];
			} else {
				weight = (1 - Model.parameters[4]) / (Delta.Count - 1);
			}
			Symbol s = new Symbol (name, weight);
			symbols.Add (s);
		}
	}

	public Symbol GetOutputSymbol(float strength) {
		float rand = Random.Range (0.0f, 1.0f);
		float window = 0.0f;
		foreach (Symbol symbol in symbols) {
			window += symbol.GetValue ();
			if (rand <= window) {
				return new Symbol (symbol.GetName (), strength);
			}
		}
		return null;
	}

	public void UpdateSymbolProbability(string name,float change) {
		foreach (Symbol s in symbols) {
			float weight = 0.0f;
			if (name == s.GetName()) {
				weight = (s.GetValue () + change) / (1 + change);
			} else {
				weight = s.GetValue () / (1 + change);
			}
			s.SetValue (weight);
		}
	}

	public void UpdateSymbolProbabilityForAllBut(string name,float change) {
		foreach (Symbol s in symbols) {
			float weight = 0.0f;
			if (name == s.GetName()) {
				weight = (s.GetValue ()) / (1 + change);
			} else {
				weight = (s.GetValue ()+change/symbols.Count) / (1 + change);
			}
			s.SetValue (weight);
		}
	}

	public float GetChanceFor(string symbol) {
		foreach (Symbol s in symbols) {
			if (s.GetName () == symbol) {
				return s.GetValue ();
			}
		}
		return -1.0f;
	}

	public void SetDistribution(List<Symbol> input) {
		symbols = input;
	}

}
