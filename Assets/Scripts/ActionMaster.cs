using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{
	public enum Action { Tidy, Reset, EndTurnReset, EndTurnHold, EndGame, Hold };

	public static Action NextAction (List<int> pinFalls)
	{
		int bowl = pinFalls.Count;
		int lastScore = pinFalls[bowl - 1];
		int previousScore = 0;
		if (pinFalls.Count > 1) { previousScore = pinFalls[bowl - 2]; }
			
		if (lastScore < 0 || lastScore > 10) { throw new UnityException("Invalid pin number. Muest be between 1 and 10."); }

		if (bowl >= 21 || (bowl == 20 && (previousScore + lastScore < 10)))
		{
			return Action.EndGame;
		}

		if (bowl == 20 && previousScore == 10)
		{
			if (lastScore < 10 && lastScore > 0)
			{
				return Action.Tidy;
			}
			else if (lastScore == 0)
			{
				return Action.Hold;
			}
		}

		if (bowl == 20 && previousScore + lastScore >= 10)
		{
			return Action.Reset;
		}

		if (lastScore == 10)
		{
			if (bowl >= 19)
			{
				return Action.Reset;
			}
			else if (bowl % 2 == 0)
			{
				return Action.EndTurnReset;
			}
			else
			{
				bowl += 2;
				return Action.EndTurnReset;
			}
		}

		if (bowl % 2 != 0)
		{
			if (lastScore == 0)
			{
				return Action.Hold;
			}
			else
			{
				return Action.Tidy;
			}
		}

		if (bowl % 2 == 0)
		{
			if (previousScore + lastScore == 0)
			{
				return Action.EndTurnHold;
			}
			else
			{
				return Action.EndTurnReset;
			}
		}


		throw new UnityException("Not sure what to return!");
	}
}
