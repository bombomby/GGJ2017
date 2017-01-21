using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

    public Vector2 Height;

    public class Platform
    {
        public Transform Prefab;

    }

    public class Bonus
    {
        public Transform Prefab;
    }

	// Use this for initialization
	void Start () {
		
	}

    float timePast = 0.0f;

	// Update is called once per frame
	void Update () {

        timePast += Time.deltaTime;

        if (timePast > 5.0f)
        {
            timePast = 0.0f;

                        

        }

	}
}
