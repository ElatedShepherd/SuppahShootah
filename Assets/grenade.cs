using UnityEngine;
using System.Collections;

public class grenade : MonoBehaviour {
	public float timer;
	public GameObject trail;

	void OnCollisionEnter (){
		StartCoroutine(WaitAndDestroy(timer));
	}

	IEnumerator WaitAndDestroy (float s){
		GetComponent<Rigidbody>().velocity = new Vector3 (0,0,0);
		GetComponent<CapsuleCollider>().enabled = false;
		GetComponent<MeshRenderer>().enabled = false;
		trail.SetActive(false);
		this.enabled = false;
		yield return new WaitForSeconds(s);
		Destroy(gameObject);
	}
}
