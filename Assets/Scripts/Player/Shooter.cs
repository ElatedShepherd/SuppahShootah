﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Shooter : MonoBehaviour {

	public Rigidbody player;
	public float angleMoveMin;

	[Range(0,1)]
	public int Arma; 

	[Serializable]
	public class Weapon { 
		public string name;
		public GameObject bullet;
		public int bulletAmount;
		public float bulletSpeed;
		public float cadencia;
		[Space (5)]
		public float anguloDisparoMax;
		public float anguloIncremento;
		public float anguloDecrease;
		public float angleDecreaseRate;
	}

	[Header ("Armas")]
	public List<Weapon> WeaponList = new List<Weapon>();


	[Header ("Indicador")]
	public Image image1;
	public Image image2;

	private  Weapon currentWeapon;
	private float anguloDisparo = 0;
	private float myTime;
	private float spreadTime;
	private float angleTime;
	private float colorAngulo;

	private CameraFollow mainCamera;
	private ParticleSystem humo;

	// Use this for initialization
	void Start () {

		mainCamera = FindObjectOfType<CameraFollow> ();
		humo = FindObjectOfType<ParticleSystem> ();
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
				if (anguloDisparo > angleMoveMin) {
					if (angleTime >= currentWeapon.angleDecreaseRate) {
						anguloDisparo -= currentWeapon.anguloDecrease;
						angleTime = 0;
					}
				}
			} else { 
				if (anguloDisparo > 0) {
					if (angleTime >= currentWeapon.angleDecreaseRate) {
						anguloDisparo -= currentWeapon.anguloDecrease;
						angleTime = 0;
					}
				}
			}
		}

		//Si nos movemos setteamos el ángulo al minimo establecido
		if (player.velocity.magnitude > 0 && anguloDisparo < angleMoveMin) {
			anguloDisparo = angleMoveMin;
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