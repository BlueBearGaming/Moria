using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class EnnemyHearing : MonoBehaviour 
{
	// radius of the hearing sphere
	public float hearingRadius = 10;

	public Vector3 lastHeard;
	SoundEmitter[] soundEmitters;

	void Start()
	{
		this.soundEmitters = FindObjectsOfType(typeof(SoundEmitter)) as SoundEmitter[];
	}

	void Awake()
	{

	}

	void Update()
	{
		foreach (SoundEmitter soundEmitter in this.soundEmitters) {
			if (soundEmitter.isActive() && soundEmitter.isInHearingRangeOf(this)) {
				this.lastHeard = soundEmitter.transform.position;
				Debug.Log("I heard you little chicky");
			}
		}
	}

	#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(this.transform.position, this.hearingRadius);
	}
	#endif
}
