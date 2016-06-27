using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

    private GameObject gameSuccess;

    void Awake()
    {
        gameSuccess = GameObject.Find("GameSuccess");
    }

    void OnTriggerEnter(Collider other)
    {
        gameSuccess.SetActive(true);
    }
}
