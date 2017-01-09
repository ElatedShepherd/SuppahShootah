using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
	
	public bool onDeath;
	public bool onContact;
	public bool onTimer;
	public float timer;

	[Space(3)]
	public bool exploded;

	public GameObject Aoe;

	// Update is called once per frame
	void Update () {
		if(onDeath && !exploded) {
			if(GetComponent<Damage>().hitPoints <= 0){
				exploded = true;	
				Aoe.GetComponent<AreaDamage>().Explode();
			}
		}
	}
	void OnCollisionEnter (){
		if(onContact){
			exploded = true;	
			Aoe.GetComponent<AreaDamage>().Explode();
		}
	}
}
