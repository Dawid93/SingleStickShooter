using System;
using UnityEngine;

namespace Player
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private PlayerRotation playerRotation;
		[SerializeField] private PlayerShoot playerShoot;
		[SerializeField] private UnitHealth playerHealth;

		private Vector3 newRotation;
		private DifficultySettings currentDifficultySettings;

		private void Awake()
		{
			currentDifficultySettings = DifficultyController.Instance.CurrentDifficultySettings;
			playerHealth.SetHealth(currentDifficultySettings.PlayerHealth);
		}

		private void FixedUpdate()
		{
			newRotation = playerRotation.GetNewRotation();
		}

		private void Update()
		{
			transform.LookAt(newRotation);
			
			if(Input.GetMouseButtonDown(0))
				playerShoot.Shoot();
		}
	}
}