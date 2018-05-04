using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour {

	public GameObject creaturePrefab;
	public float variance;
	public Transform spawnCenter;
	public Model model;
	public int generationNumber;

	public void NextGeneration(Model previousModel) {
		GameObject newCreature = Instantiate (creaturePrefab);
		newCreature.transform.position = spawnCenter.position + new Vector3 (Random.Range (0, variance), 0, Random.Range (0, variance));
		newCreature.GetComponent<Creature_Brain> ().PassModel (previousModel);
		generationNumber += 1;
		Debug.Log ("[ALERT] New Generation! Number of generations: " + generationNumber);
	}
}
