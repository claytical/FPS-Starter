using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eater : MonoBehaviour {
	public GameObject loot;
	private Player player;

	void Start() {
		player = (Player)FindObjectOfType (typeof(Player));
			
	}
	private void DropLoot() {
		Instantiate (loot,transform.localPosition, transform.rotation);
		if (player.peopleHit) {
			player.peopleHit.text = (int.Parse (player.peopleHit.text) + 1).ToString ();
		}
			Destroy (gameObject);
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.GetComponent<Bullet> () != null) {
			DropLoot ();
			Destroy (other.gameObject);
		}
	}


}
