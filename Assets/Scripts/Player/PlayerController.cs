using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10.0F;
	public float speedRotation;

	private Rigidbody myRigidbody;
	private Camera mainCamera;

	private Animator animator;


	// Use this for initialization
	void Start ()
	{
		myRigidbody = GetComponent<Rigidbody> ();
		mainCamera = FindObjectOfType<Camera> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void FixedUpdate () 
	{

		//Movimiento

		float moveHorizontal = speed * Input.GetAxisRaw ("Horizontal");
		float moveVertical = speed * Input.GetAxisRaw ("Vertical");

		Vector3 currentPosition = (myRigidbody.position);

		myRigidbody.velocity = new Vector3 (moveHorizontal, 0, moveVertical);

		//Control de animaciones

		animator.SetFloat ("Speed", moveVertical);

		//Rotación

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