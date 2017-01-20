using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

    float WaveFunction(float x)
    {
        return Mathf.Sin(20.0f * Mathf.PI * x);
    }

<<<<<<< .mine
    float WaveFunction_001(float x)
    {
        return (float)(-System.Math.Cos(3 * x * System.Math.PI) * System.Math.Sin(x * System.Math.PI));
    }

    float WaveFunction_002(float x)
    {
        return (float)(System.Math.Sin(System.Math.PI * x * 10) * System.Math.Sin(x * System.Math.PI) * System.Math.Sin(System.Math.PI * (x - 1.0)));
    }

    float WaveFunction_003(float x)
    {
        return (float)(System.Math.Sin(x * System.Math.PI) / 7);
    }

    float WaveFunction_004(float x)
    {
        return (float)(System.Math.Cos(2 * System.Math.PI * x));
    }

    Vector2[] GenerateWaves(int count)
||||||| .r8

    Vector2[] GenerateWaves(int count)
=======
    Vector2[] GenerateWaves(int count, Vector2 scale)
>>>>>>> .r11
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
