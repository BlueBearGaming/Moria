using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject SkeletonPrefab;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Return)) {
			GameObject ske = Instantiate (SkeletonPrefab, transform.position, Quaternion.identity) as GameObject;
			ske.transform.SetParent (transform);
		}
	
	}
}
