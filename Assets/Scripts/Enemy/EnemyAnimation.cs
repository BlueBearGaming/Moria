using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour
{
	private NavMeshAgent nav;               // Reference to the nav mesh agent.
	private Animator anim;                  // Reference to the Animator.

	void Awake ()
	{
		nav = GetComponentInParent<NavMeshAgent>();
		anim = GetComponent<Animator>();
	}


	void Update () 
	{
		// Calculate the parameters that need to be passed to the animator component.
		NavAnimSetup();
	}


	void NavAnimSetup ()
	{
		// Otherwise the speed is a projection of desired velocity on to the forward vector...
		float speed = Vector3.Project(nav.velocity, transform.forward).magnitude;
		anim.SetFloat ("Speed", speed / nav.speed);
	}
}