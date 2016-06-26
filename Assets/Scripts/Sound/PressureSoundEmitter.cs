using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SoundEmitter))] 
public class PressureSoundEmitter: MonoBehaviour 
{
	public SoundEmitter soundEmitter;

	// Use this for initialization
	void Awake()
	{
		this.soundEmitter = GetComponent<SoundEmitter>();
	}

	public void OnCollisionEnter(Collision collision) 
	{
		this.soundEmitter.activate();
	}
}
