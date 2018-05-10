using UnityEngine;
using System.Collections.Generic;

public static class EventMethods
{
	public delegate void Methods();
	public static Dictionary<int, Methods> yesMethods = new Dictionary<int, Methods>();
	public static Dictionary<int, Methods> noMethods = new Dictionary<int, Methods>();

	public static void InitializeDictionnaries()
	{
		if (yesMethods.Count == 0)
		{
			yesMethods.Add(3, YesEvent);
			noMethods.Add(3, NoEvent);
		}
	}

	public static Methods GetYesMethod(int eventId)
	{
		return yesMethods[eventId] ?? null;
	}

	public static Methods GetNoMethod(int eventId)
	{
		return noMethods[eventId] ?? null;
	}

	private static void YesEvent()
	{
		Debug.Log("Yes");
	}

	private static void NoEvent()
	{
		Debug.Log("No");
	}
}
