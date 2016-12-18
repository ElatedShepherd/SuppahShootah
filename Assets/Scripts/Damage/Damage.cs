using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	
	public float hitPoints; 
	public bool isEnemy = false;
	[Space(3)]
	public LayerMask[] damageLayers;

	[Header("Referencias")]
	public WaveController wc;
	public GameObject player;


	void Update () {
		

		if (hitPoints <= 0){
			
			if (isEnemy){
				wc.enemiesKilled++;
				GetComponent<Animator>().SetBool("isDead", true);
				GetComponent<CapsuleCollider>().enabled = false;
				GetComponent<ZombieController>().enabled = false;
				this.enabled = false;
			}

			Destroy(gameObject);
		}
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.GetComponent<AreaDamage>() != null)
			hitPoints -= col.gameObject.GetComponent<AreaDamage>().damage;
		else
			hitPoints -= player.GetComponentInChildren<Shooter>().currentWeapon.bulletDamage;
	}

}
