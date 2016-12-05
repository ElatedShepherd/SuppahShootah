using UnityEngine;
using System.Collections;

public class PlayStepSound : MonoBehaviour {

	void PlayFootStep () {

		GetComponent<AudioSource>().Play();
	
	}

}
