using UnityEngine;
using System.Collections;
using System;

public class LightDiminuer : MonoBehaviour {

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
			playerLight.intensity = playerLight.intensity - intensityRate;
		}
	}
}
