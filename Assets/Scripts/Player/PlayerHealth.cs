using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	private float health = 100f;                         // How much health the player has left.
	public float resetAfterDeathTime = 5f;              // How much time from the player dying to the level reseting.
	public AudioClip deathClip;                         // The sound effect of the player dying.
	public Text lifeBar;
	private GameObject gameOver;
	private bool dead = false;

	private Animator anim;                              // Reference to the animator component.
	private LastPlayerSighting lastPlayerSighting;      // Reference to the LastPlayerSighting script.
	private float timer;                                // A timer for counting to the reset of the level once the player is dead.
	private bool playerDead;                            // A bool to show if the player is dead or not.

	void Awake ()
	{
		// Setting up the references.
		anim = transform.parent.gameObject.GetComponent<Animator>();
		lastPlayerSighting = GameObject.FindGameObjectWithTag("Player").GetComponent<LastPlayerSighting>();
		gameOver = GameObject.Find ("GameOver");
	}
		
	void Update ()
	{
		if (!isDead ()) {
			lifeBar.text = health.ToString ("0");
		}
	}

	public void TakeDamage (float amount)
	{
		if (health <= 0f) {
			health = 0;
			if (!isDead ()) {
				die ();
			}

			return;
		}

		// Decrement the player's health by amount.
		health -= amount;
		if (health <= 0f) {
			health = 0;
		}
	}
		
	public void die()
	{
		dead = true;
		health = 0;
		gameOver.SetActive (true);
		anim.SetTrigger ("Dead");
	}

	public bool isDead()
	{
		return dead;
	}

}