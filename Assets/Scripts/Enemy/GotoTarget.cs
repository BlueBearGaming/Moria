using UnityEngine;
using System.Collections;

public class GotoTarget : MonoBehaviour {

	public float lightReduce = 1F;
	public float maximumLightIntensity = 4;
	public float walkSpeedModifier = 0.2f;

	private NavMeshAgent agent;
	private EnemyHearing enemyHearing;
	private EnemySightBehavior enemySightBehavior;
	private GameObject player;
	private Attacker attacker;
	private LightManager lightManager;
	private Light playerLight;
    private float initialRunSpeed;

	// Use this for initialization
	void Awake () {
		agent = GetComponent<NavMeshAgent> ();
		enemyHearing = GetComponent<EnemyHearing> ();
		enemySightBehavior = GetComponent<EnemySightBehavior> ();
		attacker = GetComponent<Attacker> ();
		player = GameObject.FindGameObjectWithTag ("Player");

		GameObject playerLightObject = GameObject.FindGameObjectWithTag ("PlayerLight");
		playerLight = playerLightObject.GetComponent<Light> ();
		lightManager = playerLightObject.GetComponent<LightManager> ();
	}

    void Start()
    {
        initialRunSpeed = agent.speed;
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
		float speed = initialRunSpeed;

		if (lightManager.lightOn && lightManager.GetIntensity() > maximumLightIntensity) {
			RotateToPlayer ();

			float distanceFromPlayer = Vector3.Distance (transform.position, player.transform.position);
			float distance = distanceFromPlayer - (playerLight.intensity / lightReduce);
		
			position = Vector3.MoveTowards (transform.position, player.transform.position, distance);
		} else {
			position = player.transform.position;
		}

		// if a skeleton is not alerted, it will only walk
		if (attacker.state != Attacker.State.Alerted) {
			speed *= walkSpeedModifier;
		}
		agent.speed = speed;
		agent.SetDestination (position);
	}

	void RotateToPlayer()
	{
		Vector3 targetDir = player.transform.position - transform.position;
		float step = agent.angularSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		transform.rotation = Quaternion.LookRotation(newDir);
	}
}
