using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant_Eyes : MonoBehaviour {

	public List<GameObject> eyes;
	private bool[] objectInRangeByEye;
	private float[] distancePerEye;
	public LayerMask layers;

	// Use this for initialization
	void Start () {
		objectInRangeByEye = new bool[eyes.Count];
		distancePerEye = new float[eyes.Count];
		for (int i = 0; i < eyes.Count; i++) {
			objectInRangeByEye [i] = false;
			distancePerEye [i] = 0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < eyes.Count; i++) {
			RaycastHit hit;
			//Debug.DrawLine (eyes [i].transform.position, eyes [i].transform.forward, Color.white);
			if (Physics.Raycast (eyes [i].transform.position, eyes [i].transform.forward, out hit, Mathf.Infinity, layers.value)) {
				//Debug.Log (hit.point);
				//Debug.DrawLine (eyes [i].transform.position, eyes [i].transform.forward * hit.distance, Color.yellow); //WHY is this off?
				objectInRangeByEye [i] = true;
				distancePerEye [i] = hit.distance;
			} else {
				objectInRangeByEye [i] = false;
				distancePerEye [i] = 0f;
			}
		}
	}

	public float[] GetEyeDistances() {
		return distancePerEye;
	}
}
