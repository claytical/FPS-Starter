using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.GetComponent<Eater>() != null) {
			Destroy (gameObject);
		}
	}
}
