using System;
using UnityEngine;

public abstract class BaseSpellController : MonoBehaviour, IInitializable
{
	public event Action<Timer> StartCooldown;
	public event Action FinishCooldown;
	public event Action SpellUse;
	
	public bool IsAvailable { get; private set; }
	public BaseSpellData SpellData => spellData;

	[SerializeField] private BaseSpellData spellData;
	
	private Timer timer;

	public void Initialize()
	{
		GameController.GameStateChange += HandleGameStateChanged;
	}

	private void HandleGameStateChanged(GameStates state)
	{
		switch (state)
		{
			case GameStates.GameStart:
				StartCountdown();
				break;
			case GameStates.GameOver:
				timer?.StopTimer();
				break;
		}
	}

	private void StartCountdown()
	{
		timer = new Timer(spellData.CoolDownTime, HandleTimerStop);
		StartCooldown?.Invoke(timer);
	}

	private void HandleTimerStop()
	{
		timer = null;
		IsAvailable = true;
		FinishCooldown?.Invoke();
	}
	
	public void UseSpell(Vector3 spawnPoint, Quaternion rotation)
	{
		if (!IsAvailable) 
			return;
		
		IsAvailable = false;
		PrepareSpell(spawnPoint, rotation);
		SpellUse?.Invoke();
		StartCountdown();
	}

	protected virtual void PrepareSpell(Vector3 spawnPoint, Quaternion rotation)
	{
	}
}