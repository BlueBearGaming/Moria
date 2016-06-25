using UnityEngine;
using System.Collections;

public class EnemySightBehavior : MonoBehaviour {

	public float fieldOfViewAngle = 110f;

	public float visionDistance = 10;

	protected Vector3 lastViewedPosition;

	// Use this for initialization
	void Awake()
	{
		visionDistance = 10;
	}
	
	// Update is called once per frame
	void Update () {


		if (IsPlayerVisible ()) {
			Debug.Log ("VISIBLE 0==D");
		}

		//Debug.Log ("-----------------------------------");
	}


	bool IsPlayerVisible()
	{
		bool isVisible = false;
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		Vector3 playerPosition = player.transform.position;
		Vector3 skeletonPosition = gameObject.transform.position;

		Vector3 direction = playerPosition - skeletonPosition;
		float angle = Vector3.Angle(direction, transform.forward);	
		float distance = Vector3.Distance (playerPosition, skeletonPosition);

		float test = player.transform.localEulerAngles.y - gameObject.transform.localEulerAngles.y; 

		// if the player is in view angle and in distance vision range
		if(distance <= visionDistance && angle < fieldOfViewAngle * 0.5f) {
			isVisible = true;
		}

		return isVisible;
	}
}
