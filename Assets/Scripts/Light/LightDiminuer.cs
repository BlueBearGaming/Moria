using UnityEngine;
using System.Collections;
using System;

public class LightDiminuer : MonoBehaviour {

	public float intensity = 15;
	public float intensityRate = 0.001F;
	public float ambientIntensity = 3;
	public float torchNoiseRange = 1;

	private GameObject player;
	private Light playerLight;
	private Light ambientPlayerLight;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");

		playerLight = GameObject.FindGameObjectWithTag ("PlayerLight").GetComponent<Light>();
		playerLight.intensity = 0;
		playerLight.range = 15;

		ambientPlayerLight = GameObject.FindGameObjectWithTag ("AmbientPlayerLight").GetComponent<Light>();
		ambientPlayerLight.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerLight.intensity == 0) {
			ambientPlayerLight.intensity = ambientIntensity;
		} else {
			playerLight.intensity -= intensityRate;
		}
		if (playerLight.intensity < 2F && ambientPlayerLight.intensity < ambientIntensity) {
			ambientPlayerLight.intensity += intensityRate;
		}

		if (Input.GetKey (KeyCode.L)) {
			playerLight.intensity = intensity;
		}
	}
}
