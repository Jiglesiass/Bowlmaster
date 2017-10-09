using UnityEngine;

public class CameraController : MonoBehaviour 
{
	[SerializeField]
	private float  distanceToPins = 1780f;
	private Transform ball;
	private Vector3 offset;
	private bool reachedPins = false;

	private void Awake () 
	{
		ball = FindObjectOfType<Ball>().transform;
	}

	private void Start()
	{
		offset = transform.position - ball.position;
	}

	private void Update () 
	{
		if ( ! reachedPins)
		{
			transform.position = ball.position + offset;
			if (ball.position.z >= distanceToPins) { reachedPins = true; }
		}
	}

	public void SetReachedPins(bool value)
	{
		reachedPins = value;
	}
}
