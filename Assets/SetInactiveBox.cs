using UnityEngine;
using System.Collections;

public class SetInactiveBox : MonoBehaviour {

	public GameObject Box;

	void SetInactive () {
	
		Box.SetActive (false);

	}
}
