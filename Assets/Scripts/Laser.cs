using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {

		lineRenderer = GetComponent<LineRenderer> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
		
			if (hit.collider) {
			
				lineRenderer.SetPosition (1, new Vector3 (0, 0, hit.distance));
			
			}
		} else {
		
			lineRenderer.SetPosition(1, new Vector3(0, 0, 5000));
				
		}
	
	}
}
