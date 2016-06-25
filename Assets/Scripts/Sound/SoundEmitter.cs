using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(AudioSource))] 
public class SoundEmitter: MonoBehaviour 
{
	public AudioClip audioClip;
	public float intensity = 5;
	public bool oneShot = true;

	private float activatedAt;
	private AudioSource audioSource;

	// Use this for initialization
	public void Start()
	{
		this.audioSource = GetComponent<AudioSource>();
		this.audioSource.clip = this.audioClip;
	}

	// Update is called once per frame
	public void Update()
	{
		if (!this.isPlaying ()) {
			this.deActivate();
		}
	}

	public void activate() 
	{
		if (!this.isPlaying()) {
			if (this.oneShot) {
				this.audioSource.PlayOneShot(this.audioClip);
			} else {
				this.audioSource.Play();
			}
		}
	}

	public void deActivate()
	{
		this.audioSource.Stop();
	}
		
	public bool isPlaying()
	{
		return this.audioSource.isPlaying;
	}

	public bool isInHearingRangeOf(EnemyHearing ennemyHearing)
	{
		var distance = Vector3.Distance(ennemyHearing.transform.position, this.transform.position);
		if (distance < (this.intensity + ennemyHearing.hearingRadius)) {
			return true;
		}

		return false;
	}
		
	#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(this.transform.position, this.intensity);
	}
	#endif
}
