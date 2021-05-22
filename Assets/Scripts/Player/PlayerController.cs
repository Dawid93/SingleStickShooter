using System;
using UnityEngine;

namespace Player
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private PlayerRotation playerRotation;
		[SerializeField] private PlayerShoot playerShoot;
		[SerializeField] private PlayerSpell playerSpell;
		[SerializeField] private UnitHealth playerHealth;

		private Vector3 newRotation;
		private DifficultySettings currentDifficultySettings;

		private void Awake()
		{
			currentDifficultySettings = DifficultyController.Instance.CurrentDifficultySettings;
			playerHealth.SetHealth(currentDifficultySettings.PlayerHealth);
			playerHealth.Dead += HandleDead;
		}

		private void HandleDead()
		{
			Debug.Log("Game Over");
		}

		private void FixedUpdate()
		{
			newRotation = playerRotation.GetNewRotation();
		}

		private void Update()
		{
			transform.LookAt(newRotation);
			
			if (Input.GetMouseButtonDown(0))
				playerShoot.Shoot();
			if (Input.GetKeyDown(KeyCode.Alpha1))
				playerSpell.UseFirstSpell();
			if (Input.GetKeyDown(KeyCode.Alpha2))
				playerSpell.UseSecondSpell();
		}
	}
}