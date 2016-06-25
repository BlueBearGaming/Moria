using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SoundEmitter))] 
public class MovementSoundEmitter : MonoBehaviour 
{
	public Vector3 previousPosition;

	private SoundEmitter soundEmitter;

	// Use this for initialization
	void Start() 
	{
		this.previousPosition = this.transform.position;
		this.soundEmitter = GetComponent<SoundEmitter>();
	}
	
	// Update is called once per frame
	void Update() {
		if (this.previousPosition != this.transform.position) {
			this.soundEmitter.activate();
		}

		this.previousPosition = this.transform.position;
	}
}
