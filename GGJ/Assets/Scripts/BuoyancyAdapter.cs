using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(BuoyancyEffector2D))]
public class BuoyancyAdapter : MonoBehaviour
{
	public WaveGenerator m_waveGenerator;

	private BuoyancyEffector2D m_buoyancyEffector;

    public GameObject Boat;

	// Use this for initialization
	void Start()
	{
		m_buoyancyEffector = gameObject.GetComponent<BuoyancyEffector2D>();
	}

    int waterLayerMask = 1 << 4;

	// Update is called once per frame
	void Update()
	{
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Boat.transform.position.x, Boat.transform.position.y + 100.0f), Vector2.down, 200.0f, waterLayerMask);
        if (hit.collider != null)
        {
            m_buoyancyEffector.surfaceLevel = hit.point.y;
        }


    }
}