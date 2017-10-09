using UnityEngine;
using UnityEngine.Assertions;

public class LaneBox : MonoBehaviour
{
	private PinCounter pinCounter;

	private void Awake()
	{
		pinCounter = FindObjectOfType<PinCounter>();
		Assert.IsNotNull(pinCounter, "PinCounter not found.");
	}
	private void OnTriggerExit(Collider other)
	{
		Ball ball = other.GetComponent<Ball>();

		if (ball)
		{
			pinCounter.BallExitedBox();
		}
	}
}
