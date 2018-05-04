using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreatureController : MonoBehaviour {

	public GameObject creaturePrefab;
	public float variance;
	public Transform spawnCenter;
	public Model model;
	public int generationNumber;
	public bool freshLoad;
	public string fileLocation;

	public void NextGeneration(Model previousModel) {
		GameObject newCreature = Instantiate (creaturePrefab);
		newCreature.transform.position = spawnCenter.position + new Vector3 (Random.Range (-variance, variance), 0, Random.Range (-variance, variance));
		newCreature.GetComponent<Creature_Brain> ().PassModel (previousModel);
		generationNumber += 1;
		Debug.Log ("[ALERT] New Generation! Number of generations: " + generationNumber);
		//SerializedObject saved = new SerializedObject (previousModel);
	}
}
