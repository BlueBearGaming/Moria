using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public float health = 100f;                         // How much health the player has left.
	public float resetAfterDeathTime = 5f;              // How much time from the player dying to the level reseting.
	public AudioClip deathClip;                         // The sound effect of the player dying.


	private Animator anim;                              // Reference to the animator component.
	private LastPlayerSighting lastPlayerSighting;      // Reference to the LastPlayerSighting script.
	private float timer;                                // A timer for counting to the reset of the level once the player is dead.
	private bool playerDead;                            // A bool to show if the player is dead or not.


	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent<Animator>();
		lastPlayerSighting = GameObject.FindGameObjectWithTag("Player").GetComponent<LastPlayerSighting>();
	}


	void Update ()
	{
		// If health is less than or equal to 0...
		if(health <= 0f)
		{
			// @todo do stuff
		}
	}

	public void TakeDamage (float amount)
	{
		// Decrement the player's health by amount.
		health -= amount;
	}
}