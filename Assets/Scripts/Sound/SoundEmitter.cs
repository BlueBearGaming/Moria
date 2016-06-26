using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
[RequireComponent(typeof(AudioSource))] 
public class SoundEmitter: MonoBehaviour 
{
	protected AudioClip audioClip;
	protected bool oneShot = false;
	private float activatedAt;
	private AudioSource audioSource;

	// Use this for initialization
	public void Awake()
	{
		this.audioSource = GetComponent<AudioSource>();
		this.audioClip = this.audioSource.clip;
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
		if (distance < (this.getIntensity() + ennemyHearing.hearingRadius)) {
			return true;
		}

		return false;
	}

	public float getIntensity()
	{
		return this.audioSource.volume * 5;
	}

	public void setOneShot(bool oneShot)
	{
		this.oneShot = oneShot;
	}
		
	#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(this.transform.position, this.getIntensity());
	}
	#endif
}
