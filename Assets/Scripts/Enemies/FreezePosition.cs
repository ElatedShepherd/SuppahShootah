using UnityEngine;
using System.Collections;

public class FreezePosition : MonoBehaviour {

	public void FreezePositionY() {
		
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;

	}
}
