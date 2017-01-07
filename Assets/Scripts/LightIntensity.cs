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

		if (Mathf.Abs(intensidadA - intensidadActual) < 0.1f) {
			intensidadA = Random.Range (4f, 8f);
			lerpSpeed = Random.Range (0.6f, 1.2f);
		}

		luz.intensity = intensidadLerp;

	}
}
