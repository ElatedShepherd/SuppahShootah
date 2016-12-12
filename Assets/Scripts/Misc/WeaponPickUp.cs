using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponPickUp : MonoBehaviour {

	public Shooter s;
	PUController puC;
	public GameObject timerCanvas;
	public Image icon;
	public Image timeline;

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
			if (!changed) {
				ChangeWeapon (weaponID);
				GetComponent<MeshRenderer> ().enabled = false;
				icon.sprite = s.WeaponList[weaponID].icon;
				timeline.fillAmount = 1;
				timerCanvas.SetActive(true);
			}
		
				currentTime += Time.deltaTime;

			if (timerCanvas)
				timeline.fillAmount = (weaponTime - currentTime) / weaponTime;

		}

		if (currentTime >= weaponTime) {
			ChangeWeapon (oldWeapon);
			timerCanvas.SetActive(false);
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
