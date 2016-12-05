using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

	// Use this for initialization
	public LayerMask enemyLayer; 

	public float warningRange;
	public GameObject warningSign;
	//public string Nivel;

	public float deathRange;

	void Start () {
	}
		
	// Update is called once per frame
	void Update () {

		/*warning check
		if (Physics.CheckSphere (transform.position, warningRange, enemyLayer.value))
			warningSign.GetComponent<SpriteRenderer>().enabled = true;
		else
			warningSign.GetComponent<SpriteRenderer>().enabled = false;*/

		//death check
		if (Physics.CheckSphere (transform.position, deathRange, enemyLayer.value))
			SceneManager.LoadScene("Lose");
	}
			


	void OnDrawGizmos(){
		//warning debug
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, warningRange);

		//death debug
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, deathRange);
	}
}
