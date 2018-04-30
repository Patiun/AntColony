using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Muscle : MonoBehaviour {

	public Vector3 maxExtension;
	public Vector3 maxContraction;
	public Vector3 startRotation;

	// Use this for initialization
	void Start () {
		startRotation = transform.localRotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ContractX(float amt) {
		Vector3 mod = transform.localRotation.eulerAngles;
		float delta = mod.x + amt;
		if (delta < 0) {
			delta = 360 + delta;
		}
		if ((delta <= 360 && delta >= 360 - maxContraction.x) || (delta >= 0 && delta <= maxContraction.x) || delta == startRotation.x) {
			mod.x += amt;
			Quaternion newRotation = Quaternion.Euler (mod);
			transform.localRotation = newRotation;
		}
	}

	public void ExtendX(float amt) {
		Vector3 mod = transform.localRotation.eulerAngles;
		float delta = mod.x - amt;
		if (delta < 0) {
			delta = 360 + delta;
		}
		if ((delta <= 360 && delta >= 360 - maxExtension.x) || (delta >= 0 && delta <= maxExtension.x) || delta == startRotation.x) {
			mod.x -= amt;
			Quaternion newRotation = Quaternion.Euler (mod);
			transform.localRotation = newRotation;
		}
	}

	public void ContractY(float amt) {
		Vector3 mod = transform.localRotation.eulerAngles;
		float delta = mod.y + amt;
		if (delta < 0) {
			delta = 360 + delta;
		}
		if ((delta <= 360 && delta >= 360 - maxContraction.y) || (delta >= 0 && delta <= maxContraction.y)  || delta == startRotation.y) {
			mod.y += amt;
			Quaternion newRotation = Quaternion.Euler (mod);
			transform.localRotation = newRotation;
		}
	}

	public void ExtendY(float amt) {
		Vector3 mod = transform.localRotation.eulerAngles;
		float delta = mod.y - amt;
		if (delta < 0) {
			delta = 360 + delta;
		}
		if ((delta <= 360 && delta >= 360 - maxExtension.y) || (delta >= 0 && delta <= maxExtension.y)  || delta == startRotation.y) {
			mod.y -= amt;
			Quaternion newRotation = Quaternion.Euler (mod);
			transform.localRotation = newRotation;
		}
	}

	public void ContractZ(float amt) {
		Vector3 mod = transform.localRotation.eulerAngles;
		float delta = mod.z + amt;
		if (delta < 0) {
			delta = 360 + delta;
		}
		if ((delta <= 360 && delta >= 360 - maxContraction.z) || (delta >= 0 && delta <= maxContraction.z)  || delta == startRotation.z) {
			mod.z += amt;
			Quaternion newRotation = Quaternion.Euler (mod);
			transform.localRotation = newRotation;
		}
	}

	public void ExtendZ(float amt) {
		Vector3 mod = transform.localRotation.eulerAngles;
		float delta = mod.z - amt;
		if (delta < 0) {
			delta = 360 + delta;
		}
		if ((delta <= 360 && delta >= 360 - maxExtension.z) || (delta >= 0 && delta <= maxExtension.z)  || delta == startRotation.z) {
			mod.z -= amt;
			Quaternion newRotation = Quaternion.Euler (mod);
			transform.localRotation = newRotation;
		}
	}

	public void Reset() {
		transform.localRotation = Quaternion.Euler(startRotation);
	}
}
