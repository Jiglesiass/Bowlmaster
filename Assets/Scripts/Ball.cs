using UnityEngine;

public class Ball : MonoBehaviour 
{
	[HideInInspector]
	public bool inPlay;

	[SerializeField]
	private Vector3 launchVelocity;
	private Vector3 initialPos;
	private Rigidbody rig;
	private AudioSource audioSource;

	private void Awake()
	{
		rig = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}

	private void Start()
	{
		rig.useGravity = false;
		initialPos = transform.position;
	}

	public void Launch(Vector3 velocity)
	{
		inPlay = true;
		rig.velocity = velocity;
		rig.useGravity = true;
		audioSource.Play();
	}

	public void ResetBall()
	{
		rig.velocity = Vector3.zero;
		rig.angularVelocity = Vector3.zero;
		rig.useGravity = false;
		transform.position = initialPos;
		transform.rotation = Quaternion.identity;
		inPlay = false;
	}
}
