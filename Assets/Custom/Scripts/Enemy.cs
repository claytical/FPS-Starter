using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	public bool followsYou;
	public GameObject whatIFollow;
	public float speedAtWhichIStalk;
	public float raycastDistance;
	public float timeUntilRaycastReset;
	private float raycastTimer;
	public bool showDebugRaycastLine;
	private bool sawYou;

	// Use this for initialization
	void Start () {
		sawYou = false;
		raycastTimer = Time.time;
	}

	public void StopFollowing() {
		followsYou = false;
		whatIFollow.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		//		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		//the model is facing right, otherwise this would be forward
			if (showDebugRaycastLine) {
				Debug.DrawRay (transform.position, transform.right * -raycastDistance, Color.green);
			}

			if (!sawYou) {
				transform.rotation = Quaternion.Euler (0f, 45 * Mathf.Sin (Time.time * 2f), 0f);
			}

			if (followsYou) {
				if (Vector3.Distance (transform.position, whatIFollow.transform.position) >= 1) {
					transform.position = Vector3.MoveTowards (transform.position, whatIFollow.transform.position, Time.deltaTime * speedAtWhichIStalk);
					transform.LookAt (whatIFollow.transform);
				}
			}

			if (Time.time >= raycastTimer) {
				sawYou = false;
			}

			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.right * -raycastDistance, out hit)) {
				if (sawYou == false) {
					raycastTimer = timeUntilRaycastReset + Time.time;
					//SEES YOU, DO SOMETHING
				}

			}	
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Touched " + other.gameObject.name);
			//run game over routine
		}
	}

}