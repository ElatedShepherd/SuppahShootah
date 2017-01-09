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

	void OnTriggerStay (Collider col){
		if (col.gameObject.GetComponent<Damage>().hitPoints > 0) {
			col.gameObject.GetComponent<Damage>().hitPoints -= damage;
			col.gameObject.GetComponent<Damage>().particula.Emit(1);
		}
	}

	public void Explode (){
		StartCoroutine (SpawnAreaDamage(radius, tellTime, duration, destructionOffset));
	}

	IEnumerator SpawnAreaDamage (float r, float tTime, float eTime, float dTime){
		Vector3 newScale = new Vector3 (2*r, 2*r, 1f);
		transform.localScale = newScale;
		GetComponent<SpriteRenderer> ().enabled = true;

		yield return new WaitForSecondsRealtime (tTime);
		explosion.Play();
		GetComponent<SphereCollider> ().enabled = true;
		fuego.Play();

		yield return new WaitForSecondsRealtime (eTime);
		fuego.loop = false;
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<SphereCollider> ().enabled = false;

		yield return new WaitForSecondsRealtime (dTime);
		Destroy(gameObject);
	}
}
