using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

    class WaveItem
    {
        public Func<float, float> Function;
        public float X = 0.0f;
    }

    List<WaveItem> waves = new List<WaveItem>();

    public void AddWave(Func<float, float> wave)
    {
        waves.Add(new WaveItem() { Function = wave });
    }

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
    public float Speed = 1.0f;

    List<Vector2> points = new List<Vector2>();

    // Use this for initialization
    void Awake () {
        waveCollider = GetComponent<EdgeCollider2D>();
        //waveCollider.points = GenerateWaves(1024, WaveScale);
    }

    public float Height = 0.0f;
    public float Length = 0.0f;

    void UpdateWave(float step)
    {
        float value = 0.0f;

        waves.ForEach(wave =>
        {
            wave.X += step;
            value += wave.Function(wave.X);
        });

        Height += value;
    }




	// Update is called once per frame
	void FixedUpdate () {
        UpdateWave(Time.deltaTime);
        Length += Time.deltaTime;

        points.Add(new Vector2(-Length, Height));
        waveCollider.points = points.ToArray();

        transform.position = transform.position + new Vector3(Time.deltaTime * Speed, 0.0f, 0.0f);
    }
}
