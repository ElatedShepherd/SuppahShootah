using UnityEngine;
using System.Collections;

public class SetInRange : MonoBehaviour {

	public Animator anim;

	void OnTriggerStay(Collider col) {

		anim.SetBool ("inRange", true);

	}

	void OnTriggerExit() {

		anim.SetBool ("inRange", false);

	}

}
