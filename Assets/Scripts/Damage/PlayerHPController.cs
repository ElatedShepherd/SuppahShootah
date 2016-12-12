using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHPController : MonoBehaviour {
	
	public float hitPoints; 
	public LayerMask[] damageLayers;

	void Update () {

		if (hitPoints <= 0){
			SceneManager.LoadScene("Lose");

		}
	}

	void OnCollisionEnter (Collision col){
		for (int i = 0; i < damageLayers.Length; i++) {
			if (1 << col.gameObject.layer == damageLayers [i].value)
				hitPoints--;
		}
	}
}