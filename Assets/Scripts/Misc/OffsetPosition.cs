using UnityEngine;
using System.Collections;

public class OffsetPosition : MonoBehaviour {

	public Vector3 offset;
	public Transform refObject;

	void FixedUpdate () {
		Vector3 origin = refObject.position;
		Vector3 newPos = origin + offset;
		transform.position =  newPos; 
	
	}
}
