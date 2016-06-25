using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PressureSoundEmitter: MonoBehaviour {

	public SoundEmitter soundEmitter;

	public void OnCollisionEnter(Collision collision) 
	{
		this.soundEmitter.activate();
	}
}
