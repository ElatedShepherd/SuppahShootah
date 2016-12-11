using UnityEngine;
using System.Collections;

public class PlayerAnim_Controller : MonoBehaviour {

	Animator animator;
	Camera mainCamera;

	Transform cam;
	Vector3 camForward;
	Vector3 move;
	Vector3 moveInput;

	float forwardAmount;
	float turnAmount;





	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
		mainCamera = FindObjectOfType<Camera> ();

		cam = Camera.main.transform;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 currentPosition = (transform.position);

		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		if (cam != null) {
			
			camForward = Vector3.Scale (cam.up, new Vector3 (1, 0, 1)).normalized;
			move = v * camForward + h * cam.right;

		} else {
		
			move = v * Vector3.forward + h * Vector3.right;
		
		}

		if (move.magnitude > 1) {
		
			move.Normalize ();
		
		}

		Move (move);

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

	void Move(Vector3 move){
	
		if (move.magnitude > 1) {
		
			move.Normalize ();
		
		}

		this.moveInput = move;

		ConvertMoveInput ();
		UpdateAnimator ();
	
	}

	void ConvertMoveInput (){

		Vector3 localMove = transform.InverseTransformDirection(moveInput);
		turnAmount = localMove.x;
		forwardAmount = localMove.z;
	}
	void UpdateAnimator (){

		animator.SetFloat("Speed Y", forwardAmount, 0.0001f, Time.deltaTime);
		animator.SetFloat("Speed X", turnAmount, 0.0001f, Time.deltaTime);
	}

}
