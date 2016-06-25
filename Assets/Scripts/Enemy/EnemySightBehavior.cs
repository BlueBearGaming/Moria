using UnityEngine;
using System.Collections;

public class EnemySightBehavior : MonoBehaviour {

	public float fieldOfViewAngle = 110f;
	public float visionDistance = 10;
	public float minimumVisionRange = 10;
	public float testDistance = 0;

	private Vector3 lastViewedPosition;
	private GameObject player;

	// Use this for initialization
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {

		if (IsPlayerVisible ()) {
			// update last sight position
			LastPlayerSighting lastSighting = player.GetComponent<LastPlayerSighting> ();
			lastSighting.position = player.transform.position;
		}
	}

	public bool IsPlayerVisible()
	{
		bool isVisible = false;
		Vector3 playerPosition = player.transform.position;
		Vector3 skeletonPosition = gameObject.transform.position;

		Vector3 direction = playerPosition - skeletonPosition;
		float angle = Vector3.Angle(direction, transform.forward);	
		float distance = Vector3.Distance (playerPosition, skeletonPosition);

		testDistance = distance;

		// if the player is in view angle and in distance vision range
		if((minimumVisionRange >= distance) || (distance <= visionDistance && angle < fieldOfViewAngle * 0.5f)) {
			isVisible = true;
		}

		return isVisible;
	}
}
