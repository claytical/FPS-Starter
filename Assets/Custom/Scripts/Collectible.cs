using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			Player player = other.gameObject.GetComponent<Player> ();
			if (player.collectedItems) {
				player.collectedItems.text = (int.Parse (player.collectedItems.text) + 1).ToString ();
			}
			Destroy (gameObject);
			Debug.Log ("Collected item");
		}
	}
}
