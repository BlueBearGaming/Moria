using UnityEngine;
using System.Collections;

public class EnemySightBehavior : MonoBehaviour {

	public float fieldOfViewAngle = 110f;
	public float minimumVisionRange = 3;
	public float lightVisionDistance = 5;
	public float darkVisionDistance = 5;

	private Vector3 lastViewedPosition;
	private GameObject player;
	private LightManager lightManager;
	private float distanceToPlayer;
	private Vector3 directionToPlayer;
	private float currentVisionDistance;
	private Light playerLight;

	// Use this for initialization
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		lightManager = GameObject.FindGameObjectWithTag ("PlayerLight").GetComponent <LightManager> ();
	}

	void Start ()
	{
		UpdateRange ();
	}

	// Update is called once per frame
	void Update () {
		UpdateRange ();

		if (IsPlayerVisible ()) {
			// update last sight position
			LastPlayerSighting lastSighting = player.GetComponent<LastPlayerSighting> ();
			lastSighting.position = player.transform.position;
		}
	}

	public bool IsPlayerVisible()
	{
		bool isVisible = false;
		float angle = Vector3.Angle(directionToPlayer, transform.forward);	
		// if the player is too close, no matter the angle nor the light, the player is detected
		bool isPlayerTooClose = minimumVisionRange >= distanceToPlayer;
		// if the player is in vision range, it is visible
		bool isPlayerInVisionRange = distanceToPlayer <= currentVisionDistance && (angle < (fieldOfViewAngle * 0.5f));

		// if the player is in view angle and in distance vision range
		if(isPlayerTooClose || isPlayerInVisionRange) {
			isVisible = true;
		}

		return isVisible;
	}

	void UpdateRange ()
	{
		Vector3 playerPosition = player.transform.position;
		Vector3 skeletonPosition = gameObject.transform.position;
		distanceToPlayer = Vector3.Distance (playerPosition, skeletonPosition);
		directionToPlayer = playerPosition - skeletonPosition;

		if (lightManager.lightOn) {
			// if the light is on, the skeletons sight is increased
			currentVisionDistance = lightVisionDistance;
		} else {
			// if the light is on, the skeletons sight is decreased
			currentVisionDistance = darkVisionDistance;
		}
	}
}
