using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SoundEmitter))] 
public class PressureSoundEmitter: MonoBehaviour 
{
	public SoundEmitter soundEmitter;

	// Use this for initialization
	void Start()
	{
		this.soundEmitter = GetComponent<SoundEmitter>();
	}

	public void OnCollisionEnter(Collision collision) 
	{
		this.soundEmitter.activate();
	}
}
