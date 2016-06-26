using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	public float attackDistance = 1;
	public bool attacking;
	public float attackDuration = .7f;

	private GameObject player;
	private PlayerHealth playerHealth;
	private EnemySightBehavior enemySight;
	private float attackStartedTime;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		enemySight = GetComponent<EnemySightBehavior> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (enemySight.IsPlayerVisible () && isPlayerAttackable ()) {
			if (attacking == false) {
				attackStartedTime = Time.time;
			}
			attacking = true;
		}

		if ((Time.time - attackStartedTime) > attackDuration) {
			if (attacking == true) {
				hit (playerHealth);
			}
			attacking = false;
		}
	}
		
	public void hit(PlayerHealth playerHealth)
	{
		var damage = Random.Range(10, 20);

		playerHealth.TakeDamage(damage);
	}

	public bool isPlayerAttackable()
	{
		float distance = Vector3.Distance (transform.position, player.transform.position);

		return (attackDistance >= distance && !playerHealth.isDead());
	}

	public bool isAttacking()
	{
		return attacking != false;
	}
}
