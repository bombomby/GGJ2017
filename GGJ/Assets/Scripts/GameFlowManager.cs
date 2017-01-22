using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class GameFlowManager : MonoBehaviour
{
	public enum GameState
	{
		GS_MainMenu,
		GS_Play,
		GS_Death,
		GS_Credits
	}

	public GameObject m_playerPink;
	public GameObject m_playerYellow;
	public GameObject m_boat;

	private bool m_isPinkAlive;
	private bool m_isYellowAlive;

	private GameState m_gameState;

	public GameObject m_imageToKillOnPlay;

	public GameObject m_scoreToDisplay;
	public GameObject m_finalScoreToDisplay;
	private Text m_scoreText;
	private Text m_finalScoreText;

	public float m_score = 0.0f;

	// Use this for initialization
	void Start ()
	{
		if (m_playerPink == null || m_playerYellow == null || m_boat == null)
		{
			Debug.LogError("Players or Boat are not set in the main script!!");
		}

		InitCharactersAndBoat();
		
		m_gameState = GameState.GS_MainMenu;

		//ensure the UI is setup when launching the game
		m_imageToKillOnPlay.SetActive(true);
		m_scoreToDisplay.SetActive(false);
		m_finalScoreToDisplay.SetActive(false);

		m_scoreText = m_scoreToDisplay.GetComponent<Text>();
		m_finalScoreText = m_finalScoreToDisplay.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (m_gameState)
		{
			case GameState.GS_MainMenu:		HandleMainMenuFlow();		break;
			case GameState.GS_Play:			HandlePlayFlow();           break;
			case GameState.GS_Death:		HandleDeathFlow();			break;
			case GameState.GS_Credits:		HandleCreditsFlow();		break;
			default:
				break;
		}
	}

	public void KillMrPink()
	{
		if (m_gameState != GameState.GS_Play)
			return;

		m_playerPink.SetActive(false);
		m_isPinkAlive = false;

		if (m_isYellowAlive == false)
		{
			TransitionFromPlayToDeath();
		}
	}

	public void KillMrYellow()
	{
		if (m_gameState != GameState.GS_Play)
			return;

		m_playerYellow.SetActive(false);
		m_isYellowAlive = false;

		if (m_isPinkAlive == false)
		{
			TransitionFromPlayToDeath();
		}
	}

	private void HandleMainMenuFlow()
	{
		// Go to Play directly
		if (IsUserInput())
		{
			m_imageToKillOnPlay.SetActive(false);
			m_gameState = GameState.GS_Play;
			m_scoreToDisplay.SetActive(true);

			// Play sound here
		}
	}

	private void HandlePlayFlow()
	{
		// handle the timer/score
		m_score += Time.deltaTime;
		m_scoreText.text = "Score:" + m_score.ToString();
	}

	private void HandleDeathFlow()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			ResetGameAfterDeath();
		}
	}

	private void HandleCreditsFlow()
	{
		
	}

	private void TransitionFromPlayToDeath()
	{
		m_gameState = GameState.GS_Death;
		m_finalScoreToDisplay.SetActive(true);
		m_scoreToDisplay.SetActive(false);
		m_finalScoreText.text = "Game Over!\n\nMr Pink and Mr Yellow died like heroes!\n\nThey survived " + m_score.ToString() + " seconds!";
	}

	private bool IsUserInput()
	{
		return Input.anyKeyDown || (Mathf.Abs(CrossPlatformInputManager.GetAxis("Horizontal1")) > 0.1f) || (Mathf.Abs(CrossPlatformInputManager.GetAxis("Vertical1")) > 0.1f)
								|| (Mathf.Abs(CrossPlatformInputManager.GetAxis("Horizontal2")) > 0.1f) || (Mathf.Abs(CrossPlatformInputManager.GetAxis("Vertical2")) > 0.1f);
	}

	private void ResetGameAfterDeath()
	{
		m_score = 0.0f;
		m_finalScoreToDisplay.SetActive(false);

		m_imageToKillOnPlay.SetActive(true);
		m_gameState = GameState.GS_MainMenu;

		InitCharactersAndBoat();
	}

	private void InitCharactersAndBoat()
	{
		m_isPinkAlive = true;
		m_isYellowAlive = true;

		m_playerPink.SetActive(true);
		m_playerYellow.SetActive(true);
		m_boat.SetActive(true);

		m_playerPink.transform.localPosition = new Vector3(-1.15f, 2.0f, 0.0f);
		m_playerYellow.transform.localPosition = new Vector3(1.4f, 2.0f, 0.0f);
		m_boat.transform.position = new Vector3(-1.5f, 0.75f, 0.0f);
	}
}
