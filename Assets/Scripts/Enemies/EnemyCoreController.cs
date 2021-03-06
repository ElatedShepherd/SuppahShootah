﻿using UnityEngine;
using System.Collections;

public class EnemyCoreController : MonoBehaviour {

	public float moveSpeed;

	public GameObject player;

	GameObject target;

	private Vector3 dir;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player");
		rb = GetComponent<Rigidbody>();

	}

	// Update is called once per frame
	void FixedUpdate () {
		dir = target.transform.position - transform.position;
		dir = dir.normalized * moveSpeed;
		rb.velocity = dir;
	}
}