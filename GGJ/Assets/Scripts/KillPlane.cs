using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
	public GameFlowManager m_flowManager;
	public float m_deathPlane = -100.0f;

	void Start()
	{

	}

	void Update()
	{
		if (m_flowManager.m_playerPink.transform.localPosition.y <= m_deathPlane)
		{
			if (m_flowManager.IsPinkAlive())
				m_flowManager.KillMrPink();
		}

		if (m_flowManager.m_playerYellow.transform.localPosition.y <= m_deathPlane)
		{
			if (m_flowManager.IsYellowAlive())
				m_flowManager.KillMrYellow();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//if (other.gameObject == m_flowManager.m_playerPink)
		//{
		//	m_flowManager.KillMrPink();
		//}
		//
		//if (other.gameObject == m_flowManager.m_playerYellow)
		//{
		//	m_flowManager.KillMrYellow();
		//}
	}
}
