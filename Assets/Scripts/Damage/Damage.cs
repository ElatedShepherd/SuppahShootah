using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	
	public float hitPoints; 
	public bool isEnemy = false;
	[Space(3)]
	public LayerMask[] damageLayers;

	[Header("Referencias")]
	public WaveController wc;



	void Update () {
		

		if (hitPoints <= 0){
			
			if (isEnemy)
				wc.enemiesKilled++;

			Destroy(gameObject);
		}
	}

	void OnCollisionEnter (Collision col){
		for (int i = 0; i < damageLayers.Length; i++) {
			if (1 << col.gameObject.layer == damageLayers [i].value) {
				if (col.gameObject.GetComponent<Shooter> () != null)
					hitPoints -= col.gameObject.GetComponent<Shooter> ().currentWeapon.damage;
				if (col.gameObject.GetComponent<AreaDamage> () != null)
					hitPoints -= col.gameObject.GetComponent<AreaDamage> ().damage;
			}
		}
	}

}
