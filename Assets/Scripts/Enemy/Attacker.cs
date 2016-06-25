using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	public float attackDistance = 1;
	public bool attacking;
	public float attackDuration = 1;

	private GameObject player;
	private EnemySightBehavior enemySight;
	private float attackStartedDate;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemySight = GetComponent<EnemySightBehavior> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (enemySight.IsPlayerVisible () && isPlayerAttackable ()) {
			attacking = true;
			attackStartedDate = Time.time;

			// TODO launch attack animation
		} else {
			attacking = false;
		}

		if ((Time.time - attackStartedDate) > attackDuration) {
			attacking = false;

			// TODO stop attack animation
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
