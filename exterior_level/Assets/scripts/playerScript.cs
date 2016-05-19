using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

	//variables
	public int health;
	public int ammo;
	public bool keyCard;

	public GameObject healthGUI;
	public Sprite[] healthImage;

	bool vulnerable;
	float bufferTime;

	// Use this for initialization
	void Start () {

		health = 7;
		ammo = 20;
		keyCard = false;
		vulnerable = true;
		bufferTime = 0.0f;
	
	}
	
	// Update is called once per frame
	void Update () {



		//buffer for enemy hits
		if (vulnerable == false) {

			bufferTime += Time.deltaTime;

			if (bufferTime >= 2.0f) {

				bufferTime = 0.0f;
				vulnerable = true;

			}

		}
	
	}

	//check for collision with a trigger collider
	void OnTriggerEnter (Collider other) {

		//restore health
		if (other.gameObject.tag == "HealthPickup") {

			health = 7;

		}

		//restore ammo
		if (other.gameObject.tag == "AmmoPickup") {

			ammo += 10;

		}
			
		//pickup keyCard
		if (other.gameObject.tag == "KeyCard") {

			Destroy (other.gameObject);

		}

		//hit by enemy. decrement health
		if (other.gameObject.tag == "Enemy" && vulnerable == true) {

			health -= 1;
			vulnerable = false;

		}

	}
}
