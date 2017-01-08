using UnityEngine;
using System.Collections;

public class AreaDamage : MonoBehaviour {

	[Header("Variables")]
	public float radius;
	public float damage;

	[Header("Timers")]
	public float tellTime;
	public float duration;
	public float destructionOffset;

	[Header("Particulas")]
	public ParticleSystem explosion;
	public ParticleSystem fuego;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnAreaDamage(radius, tellTime, duration, destructionOffset));
	}

	public IEnumerator SpawnAreaDamage (float r, float tTime, float eTime, float dTime){
		
		Vector3 newScale = new Vector3 (2*r, 2*r, 1f);
		transform.localScale = newScale;

		GetComponent<SpriteRenderer> ().enabled = true;

		yield return new WaitForSecondsRealtime (tTime);

		GetComponent<SphereCollider> ().enabled = true;
		explosion.Emit(10);
		fuego.Play();

		yield return new WaitForSecondsRealtime (eTime);

		fuego.loop = false;
		GetComponent<SphereCollider> ().enabled = false;
		GetComponent<SpriteRenderer> ().enabled = false;


		yield return new WaitForSecondsRealtime (dTime);

		Destroy(gameObject);
	}

	void OnTriggerStay (Collider col){
		if (col.gameObject.GetComponent<Damage>().hitPoints > 0) {
			col.gameObject.GetComponent<Damage>().hitPoints -= damage;
			col.gameObject.GetComponent<Damage>().particula.Emit(1);
		}
	}
}
