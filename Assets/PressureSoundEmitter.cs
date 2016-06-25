using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PressureSoundEmitter: MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip audioClip;
	public float soundRadius = 10;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}
		if (collision.relativeVelocity.magnitude > 2) {
			GetComponent<AudioSource> ().PlayOneShot(this.audioClip);
		}
	}

	#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(this.transform.position, this.soundRadius);
	}
	#endif
}
