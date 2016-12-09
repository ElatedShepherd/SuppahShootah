using UnityEngine;
using System.Collections;

public class PlayerAnim_Controller : MonoBehaviour {

	private Animator animator;
	private Camera mainCamera;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
		mainCamera = FindObjectOfType<Camera> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 currentPosition = (transform.position);

		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		print (v);

		animator.SetFloat ("Speed Y", v);
		animator.SetFloat ("Speed X", h);

		//Rotacion

		Ray cameraRay = mainCamera.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
		float rayLenght;

		if (groundPlane.Raycast (cameraRay, out rayLenght)) {
			Vector3 pointToLook = cameraRay.GetPoint (rayLenght);
			Debug.DrawLine (cameraRay.origin, pointToLook, Color.red);
			Debug.DrawLine (currentPosition, pointToLook, Color.red);

			transform.LookAt (new Vector3 (pointToLook.x, transform.position.y, pointToLook.z));
		}

	}
}
