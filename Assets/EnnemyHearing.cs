using UnityEngine;
using System.Collections;

public class EnnemyHearing : MonoBehaviour 
{
	// radius of the hearing sphere
	public float hearingRadius = 10;

	public Vector3 lastHeard;
	public float intensity;
	SoundEmitter[] soundEmitters;

	void Start()
	{
		soundEmitters = GetComponents<SoundEmitter>();
	}

	void Awake()
	{

	}

	void Update()
	{
		foreach (SoundEmitter soundEmitter in soundEmitters) {
			if (soundEmitter.isActive() && soundEmitter.isInHearingRangeOf(this)) {
				lastHeard = soundEmitter.transform.position;
			}
		}
	}
}
