using UnityEngine;
using System.Collections;
using System;

public class LightDiminuer : MonoBehaviour {

	public float intensity = 15;
	public float intensityRate = 0.001F;
	public float ambientIntensity = 3;
	public float torchNoiseRange = 1;
	public bool lightOn = false;

	private Light playerLight;
	private Light ambientPlayerLight;

	// Use this for initialization
	void Awake () {
		// Disable debug light
		GameObject.FindGameObjectWithTag ("DebugLight").SetActive(false);

		playerLight = GameObject.FindGameObjectWithTag ("PlayerLight").GetComponent<Light>();
		playerLight.intensity = 0;
		playerLight.range = 15;

		ambientPlayerLight = GameObject.FindGameObjectWithTag ("AmbientPlayerLight").GetComponent<Light>();
		ambientPlayerLight.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerLight.intensity == 0) {
			lightOn = false;
			ambientPlayerLight.intensity = ambientIntensity;
		} else {
			playerLight.intensity -= intensityRate;
		}
		if (playerLight.intensity < 2F && ambientPlayerLight.intensity < ambientIntensity) {
			ambientPlayerLight.intensity += intensityRate;
		}

		if (Input.GetKey (KeyCode.L) && !lightOn) {
			lightOn = true;
			playerLight.intensity = intensity;
			GameObject.Find ("HelperText").SetActive(false);
			GameObject.Find ("MainTitle").SetActive(false);
		}
	}

	public bool isLightOn() 
	{
		return lightOn;
	}
}
