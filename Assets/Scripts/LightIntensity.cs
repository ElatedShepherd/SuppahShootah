using UnityEngine;
using System.Collections;

public class LightIntensity : MonoBehaviour {

	public Light luz;

	public float lerpSpeed = 15f;
	private float intensidadA;
	private float intensidadActual;
	private float intensidadLerp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		intensidadActual = intensidadLerp;
		intensidadLerp = Mathf.Lerp (intensidadActual, intensidadA, Time.deltaTime * lerpSpeed);

		if (intensidadA - intensidadActual < 0.1) {
			intensidadA = Random.Range (2.2f, 3.2f);
			lerpSpeed = Random.Range (5f, 6f);
		}

		luz.intensity = intensidadLerp;

	}
}
