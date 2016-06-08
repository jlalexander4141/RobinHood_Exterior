using UnityEngine;
using System.Collections;

public class enemyRangedScript : MonoBehaviour {

	//variables
	public Transform myTarget;
	public float attackDistance;
	public Rigidbody bullet;
	public Transform firePoint;
	public float fireRate;
	public float maxForce;
	private float fireTime = 0.0f;

	public float turretHealth, minHealth, maxHealth;

	//collision function
	void OnTriggerEnter(Collider other){

		if (other.tag == "PlayerBullet") {

			turretHealth--;

			Destroy (other.gameObject);

		}

	}

	// Use this for initialization
	void Start () {

		turretHealth = Random.Range (minHealth, maxHealth);

		myTarget = GameObject.FindWithTag ("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () {

		float dist = Vector3.Distance (myTarget.position, transform.position);

		if (dist <= attackDistance) {

			transform.LookAt (myTarget);

			if(Time.time > fireTime){

				Rigidbody tempBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Rigidbody;

				tempBullet.velocity = transform.forward * maxForce;

				fireTime = Time.time + fireRate;

			}
				
		}

		//kill enemy
		if (turretHealth <= 0.0f){

			Destroy (gameObject);

		}
	
	}
}
