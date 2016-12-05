using UnityEngine;
using System.Collections;

public class LockRotation : MonoBehaviour {

	public float xFix;
	public float yFix;
	public float zFix;

	// Use this for initialization

	// Update is called once per frame
	void LateUpdate () {
		if (xFix != 0){
			Vector3 tmp = transform.eulerAngles;
			tmp.x  = xFix;
			transform.eulerAngles = tmp;
		}

		if (yFix != 0){
			Vector3 tmp = transform.eulerAngles;
			tmp.y  = yFix;
			transform.eulerAngles = tmp;
		}

		if (zFix != 0){
			Vector3 tmp = transform.eulerAngles;
			tmp.z  = zFix;
			transform.eulerAngles = tmp;
		}
	}
}
