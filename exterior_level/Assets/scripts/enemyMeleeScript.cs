using UnityEngine;
using System.Collections;

public class enemyMeleeScript : MonoBehaviour {

	//variables
	public Transform myTarget;
	public float attackDistance;
	public float hitRate;
	private float hitTime = 0.0f;

	public float enemyHealth, minHealth, maxHealth;

	//collision function
	void OnTriggerEnter(Collider other){

		if (other.tag == "PlayerBullet") {

			enemyHealth--;

			Destroy (other.gameObject);

		}

	}

	// Use this for initialization
	void Start () {

		enemyHealth = Random.Range (minHealth, maxHealth);

		myTarget = GameObject.FindWithTag ("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () {

		float dist = Vector3.Distance (myTarget.position, transform.position);

		if (dist <= attackDistance) {

			if(Time.time > hitTime){

				transform.LookAt (myTarget);


				hitTime = Time.time + hitRate;

			}

		}

		//kill enemy
		if (enemyHealth <= 0.0f){

			Destroy (gameObject);

		}
	
	}
}
