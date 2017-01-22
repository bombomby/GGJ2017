using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
	public GameFlowManager m_flowManager;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == m_flowManager.m_playerPink)
		{
			m_flowManager.KillMrPink();
		}

		if (other.gameObject == m_flowManager.m_playerYellow)
		{
			m_flowManager.KillMrYellow();
		}
	}
}
