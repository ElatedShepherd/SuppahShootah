using UnityEngine;
using System.Collections;

public class VisualPlayer : MonoBehaviour {

	public Transform follow;
	public float interpolationSpeed;
	public Rigidbody myRigidbody;
	private Camera mainCamera;

	// Use this for initialization
	void Start () {

		mainCamera = FindObjectOfType<Camera> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 currentPosition = (myRigidbody.position);

		transform.position = Vector3.Lerp(transform.position, follow.position, interpolationSpeed * Time.deltaTime);

		Ray cameraRay = mainCamera.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
		float rayLenght;

		if (groundPlane.Raycast (cameraRay, out rayLenght)) 
		{
			Vector3 pointToLook = cameraRay.GetPoint (rayLenght);
			Debug.DrawLine (cameraRay.origin, pointToLook, Color.red);
			Debug.DrawLine (currentPosition, pointToLook, Color.red);

			transform.LookAt (new Vector3 (pointToLook.x, transform.position.y, pointToLook.z));
		}
	
	}
}
