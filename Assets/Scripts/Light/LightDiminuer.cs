using UnityEngine;
using System.Collections;
using System;

public class LightDiminuer : MonoBehaviour {

	public float intensityRate = 0.001F;

	public float ambientIntensity = 3;

	private GameObject player;
	private Light playerLight;
	private Light ambientPlayerLight;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");

		playerLight = GameObject.FindGameObjectWithTag ("PlayerLight").GetComponent<Light>();
		playerLight.intensity = 5;
		playerLight.range = 15;

		ambientPlayerLight = GameObject.FindGameObjectWithTag ("AmbientPlayerLight").GetComponent<Light>();
		ambientPlayerLight.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerLight.intensity == 0) {
			ambientPlayerLight.intensity = ambientIntensity;
		} else {
			Vector3 playerPosition = player.transform.position;

			float noiseX = playerPosition.x + Mathf.PerlinNoise (0, 2);
			float noiseY = playerPosition.y + Mathf.PerlinNoise (0, 2);
			float noiseZ = playerPosition.z + Mathf.PerlinNoise (0, 2);

			playerLight.transform.position = new Vector3(noiseX, noiseY, noiseZ);
			playerLight.intensity = playerLight.intensity - intensityRate;
		}
	}
}
