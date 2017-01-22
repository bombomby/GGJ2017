using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {

    GameFlowManager Settings = null;
    public float SpeedScaler = 1.0f;
    
	// Use this for initialization
	void Start () {
        GameObject obj = GameObject.FindGameObjectWithTag("MainLoop");
        Settings = obj.GetComponent<GameFlowManager>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.position = transform.position - new Vector3(Time.deltaTime * Settings.Speed * SpeedScaler, 0.0f);
    }
}
