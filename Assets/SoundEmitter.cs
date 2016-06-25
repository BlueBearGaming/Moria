using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SoundEmitter: MonoBehaviour 
{
	public AudioSource audioSource;
	public AudioClip audioClip;

	public bool active = false;
	public float intensity = 20;

	private GameObject sphere;

	// Use this for initialization
	public void Start() 
	{
		audioSource = GetComponent<AudioSource>();
		sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
	}

	// Update is called once per frame
	public void Update() 
	{
		if (this.isActive()) {
			if (this.sphere.transform.localScale.x < this.intensity) {
				this.sphere.transform.localScale += new Vector3 (1, 1, 1);
			} else {
				this.deActivate();
			}
		}
	}

	public void activate() 
	{
		this.active = true;
		this.audioSource.PlayOneShot(this.audioClip);
	}

	public void deActivate()
	{
		this.active = false;
		this.sphere.transform.localScale = new Vector3 (0, 0, 0);
	}

	public bool isActive()
	{
		return this.active;
	}

	public bool isInHearingRangeOf(EnnemyHearing ennemyHearing)
	{
		var distance = Vector3.Distance(ennemyHearing.transform.position, this.transform.position);
		if (distance < this.intensity + ennemyHearing.hearingRadius) {
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
