using UnityEngine;
using System.Collections;

public class HPBox : MonoBehaviour {

	void OnTriggerEnter (Collider col){
		col.gameObject.GetComponent<Damage>().hitPoints = col.gameObject.GetComponent<Damage>().maxHitpoints;
		Destroy (gameObject);
	}
}
