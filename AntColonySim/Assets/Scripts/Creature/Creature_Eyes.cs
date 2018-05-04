using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Eyes : MonoBehaviour {

	public List<GameObject> eyes;
	private bool[] objectInRangeByEye;
	private float[] distancePerEye;
	private string[] tagPerEye;
	public LayerMask layers;
	public float sightRange = 10;
	public float offset = 0.2f;

	// Use this for initialization
	void Start () {
		objectInRangeByEye = new bool[eyes.Count];
		distancePerEye = new float[eyes.Count];
		tagPerEye = new string[eyes.Count];
		for (int i = 0; i < eyes.Count; i++) {
			objectInRangeByEye [i] = false;
			distancePerEye [i] = 0f;
		}
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < eyes.Count; i++) {
			RaycastHit hit;
			if (Physics.Raycast (eyes [i].transform.position, eyes [i].transform.forward, out hit, sightRange, layers.value)) {
				Debug.DrawRay (eyes [i].transform.position, eyes [i].transform.forward * hit.distance, Color.yellow); //WHY is this off?
				objectInRangeByEye [i] = true;
				tagPerEye[i] = hit.collider.tag;
				distancePerEye [i] = hit.distance;
			} else {
				Debug.DrawRay (eyes [i].transform.position, eyes [i].transform.forward * sightRange, Color.white);
				objectInRangeByEye [i] = false;
				distancePerEye [i] = 0f;
				tagPerEye[i] = "Default";
			}
		}
	}

	public float[] GetEyeDistances() {
		return distancePerEye;
	}

	public List<Symbol> GetStimuli() {
		List<Symbol> symbols = new List<Symbol> ();
		if (distancePerEye [0] > 0) {
			symbols.Add (new Symbol ("RightEye"+tagPerEye[0], (sightRange - distancePerEye [0] + offset)/(sightRange  + offset)));
		}
		if (distancePerEye [1] > 0) {
			symbols.Add (new Symbol ("LeftEye"+tagPerEye[1], (sightRange - distancePerEye [1]  + offset)/(sightRange  + offset)));
		}
		return symbols;
	}
}
