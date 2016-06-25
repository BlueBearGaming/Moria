using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	public float attackDistance = 1;
	public bool attacking;

	private GameObject player;
	private EnemySightBehavior enemySight;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemySight = GetComponent<EnemySightBehavior> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (enemySight.IsPlayerVisible () && isPlayerAttackable()) {
			attacking = true;

			// TODO launch attack animation
		}

	}

	public bool isPlayerAttackable()
	{
		float distance = Vector3.Distance (transform.position, player.transform.position);

		return attackDistance >= distance && !isAttacking();
	}

	public bool isAttacking()
	{
		return attacking != false;
	}
}
