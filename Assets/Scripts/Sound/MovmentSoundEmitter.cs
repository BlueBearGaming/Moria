using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SoundEmitter))] 
public class MovmentSoundEmitter : MonoBehaviour 
{
	public SoundEmitter soundEmitter;
	public Vector3 previousPosition;

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
