using UnityEngine;
using System.Collections;

public class GotoTarget : MonoBehaviour {

	public float lightReduce = 1F;
	public float turnRate = 10;

	private NavMeshAgent agent;
	private EnemyHearing enemyHearing;
	private EnemySightBehavior enemySightBehavior;
	private GameObject player;
	private Attacker attacker;
	private LightDiminuer lightDiminuer;
	private Light playerLight;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		enemyHearing = GetComponent<EnemyHearing> ();
		enemySightBehavior = GetComponent<EnemySightBehavior> ();
		attacker = GetComponent<Attacker> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		lightDiminuer = GameObject.FindGameObjectWithTag ("MainLight").GetComponent<LightDiminuer>();
		playerLight = GameObject.FindGameObjectWithTag ("PlayerLight").GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (attacker.isAttacking()) {
			return;
		}

		if (enemySightBehavior.IsPlayerVisible()) {
			Move ();
			return;
		}
		// Cas si player vu récemment, va en direction de la dernière position connue du joueur

		if (enemyHearing.heard) {
			enemyHearing.heard = false;
			Move ();
		}
	}

	void Move()
	{
		Vector3 position;

		if (lightDiminuer.isLightOn ()) {
			RotateToPlayer ();

			float distanceFromPlayer = Vector3.Distance (transform.position, player.transform.position);
			float distance = distanceFromPlayer - (playerLight.intensity / lightReduce);
		
			position = Vector3.MoveTowards (transform.position, player.transform.position, distance);
		} else {
			position = player.transform.position;
		}
		agent.SetDestination (position);


	}

	void RotateToPlayer()
	{
		Vector3 targetDir = player.transform.position - transform.position;
		float step = agent.angularSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);
	}
}
