using UnityEngine;
using System.Collections;
//NEED THIS FOR UI MANIPULATION
using UnityEngine.UI;

public class playerScript : MonoBehaviour {

	//variables
	public GameObject healthBar;
	public Sprite[] healthImage;
	public int health;

	public GameObject ammoBar;
	public Sprite[] ammoImage;
	public int ammo;
	public Rigidbody bullet;
	public Transform firePoint;

	public GameObject inventory;
	public Sprite[] inventoryImage;
	public bool keyCard;
	public int keyCardNum;

	bool vulnerable;
	float bufferTime;

	// Use this for initialization
	void Start () {

		health = 7;
		ammo = 20;
		keyCard = false;
		keyCardNum = 0;
		vulnerable = true;
		bufferTime = 0.0f;
	
	}
	
	// Update is called once per frame
	void Update () {

		//firing
		if(Input.GetButtonDown("Fire1"))	{

			//subtract from bulletCount
			if(ammo > 0)
			{
				//test
				Debug.Log ("player fires...");
				Rigidbody tempBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Rigidbody;
				tempBullet.velocity = transform.forward * 30;
				ammo -= 1;

				//update the ammo GUI image
				ammoBar.GetComponent<Image>().sprite = ammoImage[ammo];

			}

		}

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
			//test
			Debug.Log("refilled health...");
			//update the health GUI
			healthBar.GetComponent<Image>().sprite = healthImage[health];

		}

		//restore ammo
		if (other.gameObject.tag == "AmmoPickup" && ammo < 30) {

			ammo += 10;
			if (ammo >= 30) {

				ammo = 30;

			}
			//test
			Debug.Log("got 10 ammo...");
			//update the ammo GUI
			ammoBar.GetComponent<Image>().sprite = ammoImage[ammo];

		}
			
		//pickup keyCard
		if (other.gameObject.tag == "KeyCard" && keyCard == false) {

			keyCardNum = 1;
			//test
			Debug.Log("got the KeyCard...");
			//update the ammo GUI
			inventory.GetComponent<Image>().sprite = inventoryImage[keyCardNum];
			Destroy (other.gameObject);
			keyCard = true;

		}

		//hit by enemy. decrement health
		if (other.gameObject.tag == "Enemy" && vulnerable == true) {

			health -= 1;
			//update the health GUI
			healthBar.GetComponent<Image>().sprite = healthImage[health];
			//vulnerable = false;

			Debug.Log("got hit...");

		}

		if (other.tag == "EnemyBullet") {

			health -= 1;
			//update the health GUI
			healthBar.GetComponent<Image>().sprite = healthImage[health];

			Debug.Log("got hit...");

		}

	}
}
