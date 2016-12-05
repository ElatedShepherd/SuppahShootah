using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighlightButtonSound : MonoBehaviour {

	public AudioClip clip;

	void OnMouseEnter () {

				GetComponent<AudioSource>().Play();
	}
}

