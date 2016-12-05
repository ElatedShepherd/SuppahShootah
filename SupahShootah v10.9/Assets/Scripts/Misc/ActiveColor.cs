using UnityEngine;
using System.Collections;

public class ActiveColor : MonoBehaviour {

	public Material active;
	public Material sleep;

	public bool isActive = false; 


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	
		if (isActive)
			GetComponent<MeshRenderer>().material = active;
		else
			GetComponent<MeshRenderer>().material = sleep;
	}
}
