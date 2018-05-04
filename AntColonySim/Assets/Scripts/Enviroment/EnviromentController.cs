using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentController : MonoBehaviour {

	public GameObject food;
	public float variance;

	public void NewFood() {
		GameObject newFood = Instantiate (food);
		newFood.transform.position = transform.position + new Vector3 (Random.Range (-variance, variance), 0, Random.Range (-variance, variance));
	}
}
