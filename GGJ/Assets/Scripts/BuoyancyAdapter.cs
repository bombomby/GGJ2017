using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(BuoyancyEffector2D))]
public class BuoyancyAdapter : MonoBehaviour
{
	public WaveGenerator m_waveGenerator;

	private BuoyancyEffector2D m_buoyancyEffector;

	// Use this for initialization
	void Start()
	{
		m_buoyancyEffector = gameObject.GetComponent<BuoyancyEffector2D>();
	}

	// Update is called once per frame
	void Update()
	{
		int pointCnt = m_waveGenerator.Points.Count;
		m_buoyancyEffector.surfaceLevel = m_waveGenerator.Points[pointCnt - 1].y + 10;
	}
}