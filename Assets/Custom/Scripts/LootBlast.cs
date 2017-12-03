using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBlast : MonoBehaviour {
	public GameObject loot;
	public int amountOfLootToDrop;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < amountOfLootToDrop; i++) {
			GameObject go = (GameObject) Instantiate (loot, transform);
			if (go.GetComponent<Rigidbody> () != null) {
				go.transform.position = go.transform.position + Vector3.up;
				go.GetComponent<Rigidbody> ().AddExplosionForce (10f, transform.position,5f,5f);
			}
		}
	}
	
}
