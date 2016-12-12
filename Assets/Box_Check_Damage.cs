using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Box_Check_Damage : MonoBehaviour {

 
	void OnTriggerEnter(Collider col) {
		
		SceneManager.LoadScene("Lose");
	}
}
