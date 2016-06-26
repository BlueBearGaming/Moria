using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	private BoxCollider endGameCollider;

	// Use this for initialization
	void Start () {
		endGameCollider = GetComponent<BoxCollider> ();
	}
	
	void OnCollisionEnter(Collision collision) {		
		Debug.Log ("CONGRATS");
	}
}
