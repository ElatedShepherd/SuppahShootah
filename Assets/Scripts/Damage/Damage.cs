using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	
	public float hitPoints; 
	public bool isEnemy = false;

	public LayerMask proyectileLayer;

	public WaveController wc;



	void Update () {
				
		if (hitPoints <= 0){
			
			if (isEnemy)
				wc.enemiesKilled++;

			Destroy(gameObject);

		}
	}

	void OnCollisionEnter (Collision col){
		if (1<<col.gameObject.layer == proyectileLayer.value)
		hitPoints --;
	}

}
