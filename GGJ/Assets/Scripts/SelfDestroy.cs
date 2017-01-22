using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {

    public float LifeTime = 60.0f;

	// Use this for initialization
	void Start () {
        // destroy after 10 seconds
        Destroy(gameObject, LifeTime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
