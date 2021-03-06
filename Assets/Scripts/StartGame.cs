﻿using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	
	private bool started = false;

	// Use this for initialization
	void Start ()
    {
        GameObject.Find("GameOver").SetActive(false);
        GameObject.Find("GameSuccess").SetActive(false);

        // Disable debug light
        GameObject debugLight = GameObject.FindGameObjectWithTag("DebugLight");
        if (debugLight)
        {
            debugLight.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (!started && Input.GetKeyUp (KeyCode.L)) {
			started = true;
			GameObject.Find ("HelperText").SetActive(false);
			GameObject.Find ("MainTitle").SetActive(false);
		}
	}
}
