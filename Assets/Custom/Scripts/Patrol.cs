using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {
	public List <Transform> points;
	private int destPoint = 0;
	private NavMeshAgent agent;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		points.Add (transform);
		agent = GetComponent<NavMeshAgent> ();
		agent.autoBraking = false;
		GotoNextPoint ();
	}

	void GotoNextPoint() {
		if (points.Count == 0) {
			return;
		}

		agent.destination = points [destPoint].position;
		if (animator) {
			animator.SetFloat ("Walk", agent.speed);
		}
		destPoint = (destPoint + 1) % points.Count;

	}

	// Update is called once per frame
	void Update () {
		if (!agent.pathPending && agent.remainingDistance < 0.5f) {
			GotoNextPoint ();
		}
	}
}