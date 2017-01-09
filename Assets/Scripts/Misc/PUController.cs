using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PUController : MonoBehaviour {

	public Transform[] Spawners;
	public GameObject[] WeaponBoxes;

	public bool activeBox = false;

	public float SpawnRatio;
	float currentTime;
	[Space(5)]
	public GameObject UICanvas;
	public Image icon;
	public Image timeline;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < Spawners.Length; i++)
			Spawners[i].gameObject.GetComponent<MeshRenderer>().enabled = false;

		currentTime = SpawnRatio * 0.75f;
	}
	
	// Update is called once per frame
	void Update () {
		if(!activeBox)
		currentTime += Time.deltaTime;

		if (currentTime >= SpawnRatio && !activeBox)
			SpawnBox();
	}

	void SpawnBox (){
		activeBox = true;

		int e;
		int s;
		e = Random.Range (0, WeaponBoxes.Length);
		s = Random.Range (0, Spawners.Length);

		GameObject wp = WeaponBoxes[e];
		Transform t = Spawners[s];

		GameObject a;
		a = (GameObject)Instantiate (wp, t.position, t.rotation);
		a.GetComponent<WeaponPickUp>().timerCanvas = UICanvas;
		a.GetComponent<WeaponPickUp>().icon = icon;
		a.GetComponent<WeaponPickUp>().timeline = timeline;

		currentTime = 0;
	}
}
