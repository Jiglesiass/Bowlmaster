using UnityEngine;

public class Pin : MonoBehaviour 
{
	[SerializeField]
	private float distanceToRaise = 40f;
	private float standingThreshold = 15f;
	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	public bool IsStanding()
	{
		float rotX = Mathf.Abs(transform.rotation.eulerAngles.x);
		float rotZ = Mathf.Abs(transform.rotation.eulerAngles.z);

		return (rotX < standingThreshold && rotZ < standingThreshold);
	}

	public void Raise()
	{
		if (IsStanding())
		{
			rb.useGravity = false;
			transform.Translate(0f, distanceToRaise, 0f);
			transform.rotation = Quaternion.identity;

		}
	}

	public void Lower()
	{
		if (IsStanding())
		{
			transform.Translate(0f, -distanceToRaise, 0f);
			rb.useGravity = true;
		}
	}
}
