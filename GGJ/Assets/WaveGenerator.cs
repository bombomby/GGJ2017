using Assets;
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

    EdgeCollider2D waveCollider;

    public Vector2 WaveScale = new Vector2(1, 1);
    public float Speed = 1.0f;

    List<Vector2> points = new List<Vector2>();

    WaveCollection WaveCollection = new WaveCollection();

    // Use this for initialization
    void Awake () {
        waveCollider = GetComponent<EdgeCollider2D>();

        AddWave(WaveCollection.Waves[0]);

        for (int i = 0; i < 1024; ++i)
        {
            UpdateWave(1 / 60.0f);
        }
        //waveCollider.points = GenerateWaves(1024, WaveScale);
    }

    public float Height = 0.0f;
    public float Length = 0.0f;

    void UpdateWave(float time)
    {
        float step = time / WaveScale.x;
        float value = 0.0f;

        waves.ForEach(wave =>
        {
            wave.X += step;
            value += wave.Function(wave.X);
        });

        Height = value * WaveScale.y;
        Length += time * Speed;

        points.Add(new Vector2(-Length, Height));
    }


	// Update is called once per frame
	void FixedUpdate () {

        
        waveCollider.points = points.ToArray();

        transform.position = transform.position + new Vector3(Time.deltaTime * Speed, 0.0f, 0.0f);
    }
}
