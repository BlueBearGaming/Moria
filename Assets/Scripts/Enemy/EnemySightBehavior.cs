using UnityEngine;
using System.Collections;

public class EnemySightBehavior : MonoBehaviour {

	public float fieldOfViewAngle = 130f;
	public float minimumDarkVisionRange = 3;
    public float minimumLightVisionRange = 6;
    public float lightVisionDistance = 25;
	public float darkVisionDistance = 7;

	private Vector3 lastViewedPosition;
	private GameObject player;
	private LightManager lightManager;
	private float distanceToPlayer;
	private Vector3 directionToPlayer;
	private Light playerLight;
    private bool playerVisible;

	// Use this for initialization
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		lightManager = GameObject.FindGameObjectWithTag ("PlayerLight").GetComponent <LightManager> ();
	}

	// Update is called once per frame
	void Update () {
        UpdateVisibility();

		if (IsPlayerVisible ()) {
			// update last sight position
			LastPlayerSighting lastSighting = player.GetComponent<LastPlayerSighting> ();
			lastSighting.position = player.transform.position;
		}
	}

	public bool IsPlayerVisible()
	{
        return playerVisible;
	}

	void UpdateVisibility ()
	{
		Vector3 playerPosition = player.transform.position;
		Vector3 skeletonPosition = transform.position;
		distanceToPlayer = Vector3.Distance (playerPosition, skeletonPosition);
		directionToPlayer = playerPosition - skeletonPosition;
        float currentVisionDistance = darkVisionDistance;
        float minimumVisionRange = minimumDarkVisionRange;

        // if the light is on, the skeletons sight is increased
        if (lightManager.lightOn) {
			currentVisionDistance = lightVisionDistance;
		}

        // If player too far, just skip the rest of the checks
        if (distanceToPlayer > currentVisionDistance)
        {
            playerVisible = false;
            return;
        }

        // If light is on, the light cast by the torch will be seen if too close
        if (lightManager.lightOn)
        {
            minimumVisionRange = minimumLightVisionRange;
        }
        
        float angle = Vector3.Angle(directionToPlayer, transform.forward);
        // if the player is too close, no matter the angle nor the light, the player is detected
        bool isPlayerTooClose = minimumVisionRange >= distanceToPlayer;
        // if the player is in vision range, it is visible
        bool isPlayerInVisionRange = distanceToPlayer <= currentVisionDistance && (angle < (fieldOfViewAngle * 0.5f));

        // if the player is not in view angle and not in minimum range, we don't need to check raycasting
        if (!isPlayerTooClose && !isPlayerInVisionRange)
        {
            playerVisible = false;
            return;
        }

        // If player is either close or in the vision range of the enemy
        RaycastHit hit;
        // ... and if a raycast towards the player hits something...
        if (Physics.Raycast(skeletonPosition + transform.up, directionToPlayer.normalized, out hit, currentVisionDistance))
        {
            // If the raycast hits the player then it's the ONLY condition where the player is visible
            if (hit.collider.gameObject == player.transform.parent.gameObject) // Collision caspule is in the ThirPersonController
            {
                playerVisible = true;
                return;
            }
        }

        // If no hit with raycasting
        playerVisible = false;
    }
}
