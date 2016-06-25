using UnityEngine;
using System.Collections;
using System;

public class LightDiminuer : MonoBehaviour {

	public float intensityRate = 0.001F;

	public float ambientIntensity = 3;

	private Light[] lights;

	private int frameCount = 0;

	private Light playerLight;

	private Light ambientPlayerLight;

	// Use this for initialization
	void Awake () {
		lights = FindObjectsOfType(typeof(Light)) as Light[];

		playerLight = GameObject.FindGameObjectWithTag ("PlayerLight").GetComponent<Light>();
		ambientPlayerLight = GameObject.FindGameObjectWithTag ("AmbientPlayerLight").GetComponent<Light>();

		playerLight.intensity = 5;
		playerLight.range = 15;

		ambientPlayerLight.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerLight.intensity == 0) {
			ambientPlayerLight.intensity = ambientIntensity;
		} else {
			playerLight.intensity = playerLight.intensity - intensityRate;
			//playerLight.transform.position = new Vector3(Mathf.PerlinNoise(0, 1) * 5, Mathf.PerlinNoise(0, 1), Mathf.PerlinNoise(0, 1) * 5);
		}
	}
}
