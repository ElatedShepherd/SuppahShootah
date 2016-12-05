using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	Vector3 offset;

	public Transform toFollow;


	private Vector3 cameraInPos;
	private bool isShaking = false;

	public float interpolationSpeed = 5;

	[Header ("Shake")]
	public float _amplitude = 0.1f;
	public float _duration = 0.1f;

	// Use this for initialization
	void Start () {
		offset = transform.position - toFollow.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, toFollow.position + offset, interpolationSpeed * Time.deltaTime);
		//Camera shake
		if (isShaking) {
			transform.localPosition = transform.position + UnityEngine.Random.insideUnitSphere * _amplitude;
		}
	}


	//Función Camera Shake
	public void Shake () {
		isShaking = true;
		CancelInvoke();
		Invoke ("StopShaking", _duration);
	}

	public void StopShaking() {
		isShaking = false;
	}
}
