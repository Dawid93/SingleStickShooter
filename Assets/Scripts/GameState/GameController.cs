using System;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private IInitializable[] initializables;

	private void Awake()
	{
		initializables = FindObjectsOfType<MonoBehaviour>().OfType<IInitializable>().ToArray();
	}
}