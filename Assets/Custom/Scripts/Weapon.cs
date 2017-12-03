using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public GameObject projectile;
	public float speed;
	public float timeBetweenShots;
	private float lastShotTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Shoot ();	
	}

	void Shoot() {
		if(Input.GetAxis("Fire1") == 1) {
			if (lastShotTime + timeBetweenShots <= Time.time) {
				// Create the Bullet from the Bullet Prefab

				GameObject bullet = (GameObject)Instantiate (projectile, transform.position, Camera.main.transform.rotation);

				// Add velocity to the bullet
				bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * speed;
				lastShotTime = Time.time;
			}
		}

	}
}
