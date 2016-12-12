﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Shooter : MonoBehaviour {

	public Rigidbody player;

	[Header ("Arma Actual")]
	public int Arma; 

	[Serializable]
	public class Weapon { 
		public string name;
		public Sprite icon;
		public GameObject bullet;
		[Space (3)]
		public float damage;
		public int bulletAmount;
		public float bulletSpeed;
		public float cadencia;
		[Space (3)]
		public float anguloDisparoMax;
		public float anguloDisparoMin;
		public float anguloMoveMin;
		[Space (3)]
		public float anguloIncremento;
		public float anguloDecrease;
		public float angleDecreaseRate;

	}

	[Header ("Armas")]
	public List<Weapon> WeaponList = new List<Weapon>();


	[Header ("Indicador")]
	public Image image1;
	public Image image2;

	public  Weapon currentWeapon;
	private float anguloDisparo = 0;
	private float myTime;
	private float spreadTime;
	private float angleTime;
	private float colorAngulo;

	public CameraFollow mainCamera;
	public ParticleSystem humo;

	// Use this for initialization
	void Start () {
		currentWeapon = WeaponList [Arma];
	}

	// Update is called once per frame
	void Update () {

		currentWeapon = WeaponList [Arma];

		Debug.DrawRay (transform.position, Quaternion.Euler(new Vector3 (0, anguloDisparo, 0)) * transform.forward ,Color.blue);
		Debug.DrawRay (transform.position, Quaternion.Euler(new Vector3 (0, -anguloDisparo, 0)) * transform.forward ,Color.blue);

		//Ángulo "visible"
		colorAngulo = anguloDisparo / currentWeapon.anguloDisparoMax;

		image1.fillAmount = anguloDisparo / 360;
		image2.fillAmount = anguloDisparo / 360;

		image1.color = Color.Lerp(new Color(1, 0.92F, 0.16F, 0.7f), new Color(1, 0, 0, 0.7f), colorAngulo);
		image2.color = Color.Lerp(new Color(1, 0.92F, 0.16F, 0.7f), new Color(1, 0, 0, 0.7f), colorAngulo);

		myTime += Time.deltaTime;
		angleTime += Time.deltaTime;

		//Gestión del ángulo
		if (Input.GetButton ("Fire1")) {
			if (myTime >= currentWeapon.cadencia) {
				Fire (currentWeapon.bullet);
			}
		} 
		else {
			if (player.velocity.magnitude > 0) { 
				if (anguloDisparo > currentWeapon.anguloMoveMin) {
					if (angleTime >= currentWeapon.angleDecreaseRate) {
						anguloDisparo -= currentWeapon.anguloDecrease;
						angleTime = 0;
					}
				}
			} else { 
				if (anguloDisparo > currentWeapon.anguloDisparoMin) {
					if (angleTime >= currentWeapon.angleDecreaseRate) {
						anguloDisparo -= currentWeapon.anguloDecrease;
						angleTime = 0;
					}
				}
			}
		}

		//Si nos movemos setteamos el ángulo al minimo establecido
		if (player.velocity.magnitude > 0 && anguloDisparo < currentWeapon.anguloMoveMin) {
			anguloDisparo = currentWeapon.anguloMoveMin;
		}
	}

	//Función de disparo
	void Fire(GameObject pref) {

		for (int i = 0; i < currentWeapon.bulletAmount; i++) {
			float bulletAngle = UnityEngine.Random.Range (-anguloDisparo, anguloDisparo);
			GameObject cloneBullet;
			cloneBullet = (GameObject)Instantiate (pref, transform.position, transform.rotation);
			cloneBullet.transform.forward = Quaternion.Euler (new Vector3 (0, bulletAngle, 0)) * transform.forward;
			cloneBullet.GetComponent<Rigidbody> ().velocity = cloneBullet.transform.forward * currentWeapon.bulletSpeed;

			humo.Emit (10);
		}

		if (anguloDisparo < currentWeapon.anguloDisparoMax) {
			anguloDisparo += currentWeapon.anguloIncremento;
		}

		myTime = 0;

		GetComponent<AudioSource>().Play();
		mainCamera.Shake();
	}


}
