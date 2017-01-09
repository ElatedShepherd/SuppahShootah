using UnityEngine;
using System.Collections;

public class Divider : MonoBehaviour {

	public GameObject spawn;
	public int number;
	GameObject player;

	public bool spawned;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Damage>().hitPoints <= 0 && !spawned){
			spawned = true;
			SpawnEnemies();
		}
	}

	void SpawnEnemies (){
		player = GetComponent<Damage>().player;

		for (int i = 0; i < number; i++) {
		GameObject a;
		a = (GameObject)Instantiate (spawn, transform.position, transform.rotation);
		a.GetComponent<Damage>().wc = GetComponent<Damage>().wc;
		a.GetComponent<Damage>().isClone = true;
		a.GetComponent<Damage>().player = player;
		}
	}
}
