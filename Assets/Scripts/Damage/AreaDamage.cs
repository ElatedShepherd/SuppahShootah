using UnityEngine;
using System.Collections;

public class AreaDamage : MonoBehaviour {

	[Header("Indicator Variables")]
	public GameObject splashIndicator;
	public float radius;

	[Header("Timers")]
	public float tellTime;
	public float duration;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator SpawnAreaDamage (GameObject gb, float r, float tTime, float eTime){
		
		Vector3 newScale = new Vector3 (2*r, 2*r, 1f);
		gb.transform.Rotate (-90, 0, 0);
		gb.transform.localScale = newScale;
		gb.GetComponent<SpriteRenderer> ().enabled = true;

		yield return new WaitForSecondsRealtime (tTime);

		gb.GetComponent<CapsuleCollider> ().enabled = true;

		yield return new WaitForSecondsRealtime (eTime);




	}
}
