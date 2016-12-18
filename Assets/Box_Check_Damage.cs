using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Box_Check_Damage : MonoBehaviour {

 
	void OnTriggerEnter(Collider col) {
		col.gameObject.GetComponent<Damage>().hitPoints -= 1;
		col.gameObject.GetComponent<Damage>().particula.Emit(1);
	}
}
