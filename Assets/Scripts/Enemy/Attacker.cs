using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	public float attackDistance = 1;
	public bool attacking;
	public float attackDuration = 5;

	private GameObject player;
	private EnemySightBehavior enemySight;
	public float attackStartedTime;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemySight = GetComponent<EnemySightBehavior> ();
		attackDuration = 5;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (enemySight.IsPlayerVisible () && isPlayerAttackable ()) {

			if (attacking == false) {
				attackStartedTime = Time.time;
			}
			attacking = true;
		} else {
			attacking = false;
		}

		if (attacking && (Time.time - attackStartedTime) > attackDuration) {
			attacking = false;
		}
	}

	public bool isPlayerAttackable()
	{
		float distance = Vector3.Distance (transform.position, player.transform.position);

		return attackDistance >= distance;
	}

	public bool isAttacking()
	{
		return attacking != false;
	}
}
