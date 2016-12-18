using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	public float moveSpeed;
	public float rotationSpeed;
	public float damage;

	private GameObject player;

	GameObject target;

	private Vector3 dir;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player");

	}

	// Update is called once per frame
	void FixedUpdate () {
		dir = target.transform.position - transform.position;
		dir = dir.normalized * moveSpeed;
		//rb.velocity = dir;
		Quaternion rotation = Quaternion.LookRotation (dir);
		transform.rotation = Quaternion.Lerp (transform.rotation, rotation, rotationSpeed);
	}
}