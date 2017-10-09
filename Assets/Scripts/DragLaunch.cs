using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour 
{
	public float straightLaunchForce = 100f;

	private Ball ball;
	private float dragTime;
	private bool dragStarted;
	private Vector2 mouseInitPos;

	private void Awake()
	{
		ball = GetComponent<Ball>();
	}

	private void Update()
	{
		if (dragStarted)
		{
			dragTime += Time.deltaTime;
		}
	}

	public void DragStart()
	{
		if (ball.inPlay) { return; }

		dragStarted = true;
		mouseInitPos = Input.mousePosition;
	}

	public void DragEnd()
	{
		if (ball.inPlay) { return; }

		Vector2 mouseEndPos = Input.mousePosition;
		float launchXVelocity = mouseEndPos.x - mouseInitPos.x;
		float launchYVelocity = mouseEndPos.y - mouseInitPos.y;
		Vector3 velocity = new Vector3(launchXVelocity, 0, launchYVelocity) / dragTime;

		ball.Launch(velocity);
		dragStarted = false;
		dragTime = 0;
	}

	public void StraightLaunch()
	{
		ball.Launch(Vector3.forward * straightLaunchForce);
	}

	public void MoveStart(float xAmount)
	{
		if ( ! ball.inPlay)
		{
			transform.Translate(xAmount, 0, 0);
		}
	}
}
