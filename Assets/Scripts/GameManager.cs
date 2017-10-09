using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour 
{
	private List<int> bowls = new List<int>();

	private PinSetter pinsSetter;
	private Ball ball;

	private void Awake()
	{
		pinsSetter = FindObjectOfType<PinSetter>();
		Assert.IsNotNull(pinsSetter, "PinSetter not found");

		ball = FindObjectOfType<Ball>();
		Assert.IsNotNull(ball, "Ball not found.");
	}

	public void Bowl(int pinFall)
	{
		bowls.Add(pinFall);
		ActionMaster.Action nextAction = ActionMaster.NextAction(bowls);
		pinsSetter.HandleAction(nextAction);
		ball.ResetBall();
	}
}
