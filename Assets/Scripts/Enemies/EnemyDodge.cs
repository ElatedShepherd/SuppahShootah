using UnityEngine;
using System.Collections;

public class EnemyDodge : MonoBehaviour {

	public float dodgeCD;
	public float dodgeSpeed;
	public float dodgeLength; 
	public float dodgeAmount; 
	public GameObject player; 
	public LayerMask bulletLayer;
	public float rangeCheck; 

	float dodgeCDcurrent;
	float dodgeTime; 
	float dir;
	float dirDodge;

	void Start (){
		dodgeCDcurrent = dodgeCD;
		dodgeTime = dodgeLength; 
		player = GameObject.Find ("Player");
	}

	// Update is called once per frame
	void Update () {
		dodgeCDcurrent += Time.deltaTime; 

		if (dodgeTime < dodgeLength){
			transform.RotateAround(player.transform.position, Vector3.up ,  dir * dodgeSpeed * dodgeAmount * Time.deltaTime); 
			dodgeTime += Time.deltaTime; 
		}

		if (Physics.CheckSphere (transform.position, rangeCheck, bulletLayer.value) && dodgeCDcurrent >= dodgeCD){
			dodgeTime = 0; 
			dodgeCDcurrent = 0; 
			dir = Mathf.Sign(Random.Range (-1,1));
		}
	}
		
	void OnDrawGizmos(){
		//warning debug
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, rangeCheck);
	}
}