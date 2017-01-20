using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

    float WaveFunction(float x)
    {
        return Mathf.Sin(20.0f * Mathf.PI * x);
    }

    Vector2[] GenerateWaves(int count, Vector2 scale)
    {
        Vector2[] waves = new Vector2[count];

        for (int i = 0; i < count; ++i)
        {
            float x = (float)i / count;
            waves[i] = new Vector2(scale.x * x, scale.y * WaveFunction(x));
        }

        return waves;
    }

    EdgeCollider2D waveCollider;

    public Vector2 WaveScale = new Vector2(1, 1);

    // Use this for initialization
    void Awake () {
        int count = 2048;
        waveCollider = GetComponent<EdgeCollider2D>();
        waveCollider.points = GenerateWaves(count, WaveScale);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(waveCollider.pointCount.ToString());
     
	}
}
