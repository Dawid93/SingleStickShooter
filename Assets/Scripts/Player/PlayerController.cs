using System;
using UnityEngine;

namespace Player
{
	public class PlayerController : MonoBehaviour, IInitializable
	{
		public event Action PlayerDead;
		
		[SerializeField] private PlayerRotation playerRotation;
		[SerializeField] private PlayerShoot playerShoot;
		[SerializeField] private PlayerSpell playerSpell;
		[SerializeField] private UnitHealth playerHealth;

		private Vector3 newRotation;
		private DifficultySettings currentDifficultySettings;
		private bool isGameStarted;

		public void Initialize()
		{
			GameController.GameStateChange += HandleGameStateChanged;
			currentDifficultySettings = DifficultyController.Instance.CurrentDifficultySettings;
			playerHealth.SetHealth(currentDifficultySettings.PlayerHealth);
			playerHealth.Dead += HandleDead;
		}

		private void HandleGameStateChanged(GameStates state)
		{
			switch (state)
			{
				case GameStates.GameStart:
					playerHealth.SetHealth(currentDifficultySettings.PlayerHealth);
					isGameStarted = true;
					break;
				case GameStates.GameOver:
					isGameStarted = false;
					break;
			}
		}

		private void HandleDead()
		{
			PlayerDead?.Invoke();
		}

		private void FixedUpdate()
		{
			newRotation = playerRotation.GetNewRotation();
		}

		private void Update()
		{
			if (!isGameStarted)
				return;
			
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