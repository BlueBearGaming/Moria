using UnityEngine;
using System.Collections;

public class LightManager : MonoBehaviour {

	public float intensityRate = 0.001F;
	public float ambientIntensity = 3;
	public bool lightOn = false;

	private float initialIntensity;
	private Light light;
	private Light ambientLight;
	private ParticleSystem torchFire;

	// Use this for initialization
	void Awake () {
		light = GetComponent<Light>();
		initialIntensity = light.intensity;
		ambientLight = GameObject.FindGameObjectWithTag ("AmbientPlayerLight").GetComponent<Light>(); // @todo find Lights in children
		torchFire = GetComponentInChildren<ParticleSystem> ();
	}

	void Start(){
		if (lightOn) {
			lightsOn ();
		} else {
			lightsOut ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (light.intensity <= 0) {
			lightsOut ();
		} else {
			light.intensity -= intensityRate;
		}
		if (light.intensity < 2F && ambientLight.intensity < ambientIntensity) {
			ambientLight.intensity += intensityRate;
		}

		if (Input.GetKeyUp (KeyCode.L)) {
			if (lightOn) {
				lightsOut ();
			} else {
				lightsOn ();
			}
		}
	}

	public float GetIntensity() {
		return light.intensity;
	}

	void lightsOut() {
		light.intensity = 0;
		ambientLight.intensity = ambientIntensity;
		if (torchFire) {
			torchFire.Stop ();
		}
		lightOn = false;
	}

	void lightsOn() {
		light.intensity = initialIntensity;
		ambientLight.intensity = 0;
		if (torchFire) {
			torchFire.Play ();
		}
		lightOn = true;
	}
}
