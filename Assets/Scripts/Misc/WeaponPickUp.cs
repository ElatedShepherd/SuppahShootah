using UnityEngine;
using System.Collections;

public class WeaponPickUp : MonoBehaviour {

	public Shooter s;
	PUController puC;

	public int weaponID;
	public float weaponTime;
	public float currentTime = 0;

	public bool picked;
	bool changed = false;
	int oldWeapon;

	// Use this for initialization
	void Start () {
		puC = GameObject.Find("Wave Manager").GetComponent<PUController>();
		s = GameObject.Find ("Shooter").GetComponent<Shooter>();
		oldWeapon = s.Arma;
	}
	
	// Update is called once per frame
	void Update () {
		if (picked){
			currentTime += Time.deltaTime;
			if (!changed) {
				ChangeWeapon (weaponID);
				GetComponent<MeshRenderer> ().enabled = false;
			 }
		}

		if (currentTime >= weaponTime) {
			ChangeWeapon (oldWeapon);
			Destroy (gameObject);
		}
	}

	void ChangeWeapon (int arma){
		s.Arma = arma;
		changed = true;
	}

	void OnTriggerEnter (Collider col){
		if (!picked) {
			picked = true;
			puC.activeBox = false;
		}
	}
}
