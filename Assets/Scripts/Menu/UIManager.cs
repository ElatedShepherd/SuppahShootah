using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public void DisableBoolAnim (Animator anim) {
		anim.SetBool ("isDisplayed", false);
	}

	public void EnableBoolAnim (Animator anim) {
		anim.SetBool ("isDisplayed", true);
	}

	public void LoadScene (int level) {
		SceneManager.LoadScene (level, LoadSceneMode.Single);
	}

	public void PlaySound (AudioSource audio){
		audio.Play ();
	}
}
