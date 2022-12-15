using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticManager : MonoBehaviour
{
	private static StaticManager instance;

	private StaticManager() { }

	public static StaticManager Instance
	{
		get
		{
			if (null == instance)
			{
				instance = new StaticManager();
			}
			return instance;
		}
	}
}
