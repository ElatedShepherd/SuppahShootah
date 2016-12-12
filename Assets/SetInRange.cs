using UnityEngine;
using System.Collections;

public class SetInRange : MonoBehaviour {

	public Animator anim;

	void OnTriggerEnter(Collider col) {

		anim.SetBool ("inRange", true);

	}

	void SetInRangeOff() {

		anim.SetBool ("inRange", false);

	}

}
