using UnityEngine;
using System.Collections;

public class GotoTarget : MonoBehaviour {

	private NavMeshAgent agent;
	private EnemyHearing enemyHearing;
	private EnemySightBehavior enemySightBehavior;
	private GameObject player;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		enemyHearing = GetComponent<EnemyHearing> ();
		enemySightBehavior = GetComponent<EnemySightBehavior> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (enemySightBehavior.IsPlayerVisible()) {
			agent.SetDestination (player.transform.position);
			return;
		}
		// Cas si player vu récemment, va en direction de la dernière position connue du joueur

		if (enemyHearing.heard) {
			enemyHearing.heard = false;
			agent.SetDestination (enemyHearing.lastHeard);
		}
	}
}
