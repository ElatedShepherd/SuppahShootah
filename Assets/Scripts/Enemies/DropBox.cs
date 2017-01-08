using UnityEngine;
using System.Collections;

public class DropBox : MonoBehaviour {
	[Range (1,100)]
	public int chance;
	public GameObject Box;

	public bool dropped;

	public void Drop (){
		int a = Random.Range(0,100);
		GameObject bc;

		if (a <= chance)
			bc = (GameObject)Instantiate (Box, transform.position, transform.rotation);
	}
}
