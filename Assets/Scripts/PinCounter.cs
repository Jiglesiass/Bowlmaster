using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour 
{
	[HideInInspector]
	public int lastStandingCount = -1;

	private PinSetter pinSetter;
	private Text standingPinsText;
	private CameraController cameraController;
	private GameManager gameManager;

	private float lastChangeTime;
	private bool ballExitedBox;
	private int lastPinsSettled = 10;
	private int pinFall;

	private void Awake()
	{
		GetReferences();
	}

	private void Update()
	{
		if (ballExitedBox)
		{
			standingPinsText.text = (lastPinsSettled - CountStanding()).ToString();
			standingPinsText.color = Color.red;
			CheckStanding();
		}
	}

	private int CountStanding()
	{
		int count = 0;

		foreach (Pin pin in FindObjectsOfType<Pin>())
		{
			if (pin)
			{
				if (pin.IsStanding()) { count++; }
			}
		}

		return count;
	}

	private void CheckStanding()
	{
		int currentCount = CountStanding();
		if (currentCount != lastStandingCount)
		{
			lastStandingCount = currentCount;
			lastChangeTime = Time.time;
		}
		else if (Time.time - lastChangeTime >= 2.3f)
		{
			PinsHaveSettled();
		}
	}

	private void PinsHaveSettled()
	{
		pinFall = lastPinsSettled - lastStandingCount;
		lastPinsSettled = lastStandingCount;

		standingPinsText.color = Color.green;
		gameManager.Bowl(pinFall);

		lastStandingCount = -1;
		ballExitedBox = false;
		cameraController.SetReachedPins(false);
	}

	private void GetReferences()
	{
		standingPinsText = GameObject.Find("ScoreText").GetComponent<Text>();
		Assert.IsNotNull(standingPinsText, "ScoreText not found. Please, create it");

		cameraController = FindObjectOfType<CameraController>();
		Assert.IsNotNull(cameraController, "CameraController not found.");

		pinSetter = FindObjectOfType<PinSetter>();
		Assert.IsNotNull(pinSetter, "PinSetter not found");

		gameManager = FindObjectOfType<GameManager>();
		Assert.IsNotNull(gameManager, "GameManager not found");
	}

	public void BallExitedBox()
	{
		ballExitedBox = true;
	}
}

