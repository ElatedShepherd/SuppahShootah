using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Damage : MonoBehaviour {


	public bool isPlayer;
	public bool isEnemy = false;
	[Header("Enemigo")]
	public bool isClone;
	public float despawnTime = 15;
	[Header("General")]
	public float hitPoints; 
	public float maxHitpoints;

	[Space(3)]
	public LayerMask[] damageLayers;

	[Header("Referencias")]
	public WaveController wc;
	public GameObject player;
	public ParticleSystem particula;
	public Image hpBar; 

	void Update () {
				
		if (isPlayer){
			hpBar.fillAmount = hitPoints/maxHitpoints;
		}

		if (hitPoints <= 0){
			
			if (isEnemy){
				if (!GetComponent<DropBox>().dropped){
					GetComponent<DropBox>().dropped = true;
					GetComponent<DropBox>().Drop();
				}
				StartCoroutine(WaitAndDestroy(despawnTime));
			}
			else if (isPlayer)
				SceneManager.LoadScene("Lose");
			else
				Destroy(gameObject);
		}
	}

	void OnCollisionEnter (Collision col){
		for (int i = 0; i < damageLayers.Length; i++){
			if (1<<col.gameObject.layer == damageLayers[i].value){
				if (isPlayer){
					if (col.gameObject.GetComponent<AreaDamage>() != null){
						particula.Emit(10);
						hitPoints -= col.gameObject.GetComponent<AreaDamage>().damage;
					}
					else {
						hitPoints -= 1;
						particula.Emit(10);
					}
				}
				else {
					if (col.gameObject.GetComponent<AreaDamage>() != null){
						particula.Emit(10);
						hitPoints -= col.gameObject.GetComponent<AreaDamage>().damage;
					}
					else {
						hitPoints -= player.GetComponentInChildren<Shooter>().currentWeapon.bulletDamage;
						particula.Emit(10);
					}
				}
			}
		}		
	}

	IEnumerator WaitAndDestroy (float s){
		if (!isClone)
			wc.enemiesKilled++;
		
		GetComponent<Animator>().SetBool("isDead", true);
		GetComponent<CapsuleCollider>().enabled = false;
		GetComponent<ZombieController>().enabled = false;
		this.enabled = false;
		yield return new WaitForSeconds(s);
		Destroy(gameObject);
	}
}
