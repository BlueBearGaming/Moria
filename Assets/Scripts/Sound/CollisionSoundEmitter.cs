using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SoundEmitter), typeof(BoxCollider))] 
public class CollisionSoundEmitter: MonoBehaviour 
{
	public BoxCollider collider;
	public SoundEmitter soundEmitter;

	void Start()
	{
		this.collider = GetComponent<BoxCollider>();
		this.soundEmitter = GetComponent<SoundEmitter>();
		this.soundEmitter.setOneShot(true);
	}

	public void OnCollisionEnter(Collision collision) 
	{
		this.soundEmitter.activate();
		Debug.Log("CRACK");
	}
}
