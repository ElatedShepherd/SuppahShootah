using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WaveController : MonoBehaviour {
	
	public GameObject player;
	public float restTime;
	public int enemiesKilled;


	public int currentWave = 0;
	int maxEnemies;
	int spawnedEnemies = 0;
	public float spawnTime = 0;

	public string nextScene;


	[Serializable]
	public class EnemyComp {
		public GameObject enemyPrefab;
		public int amount;
		public int spawned;
	}

	[Serializable]
	public class Wave {
		public float spawnDelay;
		public List <EnemyComp> Composition = new List <EnemyComp>();
		public Transform[] Spawners;
	}		
	public List <Wave> Waves = new List<Wave>();

	// Use this for initialization
	void Start () {
		maxEnemies = GetAllEnemiesInWave(Waves[currentWave]);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentWave > Waves.Count - 1) {
			SceneManager.LoadScene (nextScene);
		} else {
			spawnTime += Time.deltaTime;

			if (spawnedEnemies < maxEnemies) {
				if (spawnTime >= Waves [currentWave].spawnDelay) {
					Transform t = GetRandomSpawner (Waves [currentWave]);
					SpawnRandomEnemyInComp (Waves [currentWave].Composition, t);
					spawnTime = 0;
				}
			}

			if (enemiesKilled >= maxEnemies) {
				if (spawnTime >= restTime && currentWave < Waves.Count) {
					currentWave++;
					spawnedEnemies = 0;
					enemiesKilled = 0;
					maxEnemies = GetAllEnemiesInWave (Waves [currentWave]);
					spawnTime = 0;
				}
			}
		}

			
	}

	int GetAllEnemiesInWave (Wave w){
		int sum = 0;
		for (int i = 0; i < w.Composition.Count; i++){
			sum += w.Composition[i].amount;
		}
		return sum;
	}

	void SpawnRandomEnemyInComp (List<EnemyComp> comp, Transform spawner) {
		int e;
		do {
			e = UnityEngine.Random.Range (0, comp.Count);
		} while (comp[e].spawned == comp[e].amount);

		GameObject enemy = comp[e].enemyPrefab;

		GameObject a;
		a = (GameObject)Instantiate (enemy, spawner.position, spawner.rotation);
		a.GetComponent<EnemyCoreController>().player = player;
		a.GetComponent<Damage>().wc = this;

		comp[e].spawned ++;
		spawnedEnemies ++;
	}

	Transform GetRandomSpawner (Wave w){
		Transform t;
		int s = UnityEngine.Random.Range (0, w.Spawners.Length);
		t = w.Spawners[s];

		return t;
	}
}
