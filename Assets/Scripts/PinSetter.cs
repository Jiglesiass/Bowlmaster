using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PinSetter : MonoBehaviour 
{
	public GameObject pinsPrefab;

	private Animator anim;
	private List<Pin> standingPins = new List<Pin>();

	private void Awake()
	{
		anim = GetComponent<Animator>();
		Assert.IsNotNull(anim, "PinSetter Animator not found.");
	}

	public void HandleAction (ActionMaster.Action _action)
	{
		if (_action == ActionMaster.Action.Tidy)
		{
			anim.SetTrigger("tidy");
		}
		else if (_action == ActionMaster.Action.EndTurnReset || _action == ActionMaster.Action.Reset)
		{
			anim.SetTrigger("reset");
		}
	}

	public void RaisePins()
	{
		UpdatePinList();

		standingPins.ForEach(delegate (Pin pin)
		{
			pin.Raise();
		});
		standingPins.Clear();
	}

	public void LowerPins()
	{
		UpdatePinList();

		standingPins.ForEach(delegate (Pin pin)
		{
			pin.Lower();
		});
		standingPins.Clear();
	}

	public void RenewPins()
	{
		GameObject newPins = Instantiate(pinsPrefab);
		newPins.transform.Translate(0, 30f, 0);
	}

	private void UpdatePinList()
	{
		foreach (Pin pin in FindObjectsOfType<Pin>())
		{
			standingPins.Add(pin);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		bool isPin = (other.GetComponentInParent<Pin>());

		if (isPin)
		{
			Destroy(other.transform.parent.gameObject);
		}
	}
}
