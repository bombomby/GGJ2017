using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

    float WaveFunction(float x)
    {
        return 300.0f * Mathf.Sin(Mathf.PI * x / 180);
    }


    Vector2[] GenerateWaves(int count)
    {
        Vector2[] waves = new Vector2[count];

        for (int i = 0; i < count; ++i)
        {
            waves[i] = new Vector2(i - count / 2, WaveFunction(i));
        }

        return waves;
    }

    EdgeCollider2D waveCollider;

    // Use this for initialization
    void Start () {
        int width = (int)transform.localScale.x;
        waveCollider = GetComponent<EdgeCollider2D>();
        waveCollider.points = GenerateWaves(width);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(waveCollider.pointCount.ToString());
     
	}
}
