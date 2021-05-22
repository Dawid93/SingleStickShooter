using System;
using System.CodeDom;
using UnityEngine;

public class SpellController : MonoBehaviour
{
	public event Action<Timer> StartCooldown;
	public event Action FinishCooldown;
	
	public bool IsAvailable { get; private set; }
	public BaseSpellData SpellData { get; private set; }

	[SerializeField] private BaseSpellData spellData;
	
	private Timer timer;
	
	private void StartCountdown()
	{
		timer = new Timer(spellData.CoolDownTime, HandleTimerStop);
		StartCooldown?.Invoke(timer);
	}

	private void HandleTimerStop()
	{
		timer = null;
		SetAsAvailable();
		FinishCooldown?.Invoke();
	}


	public void UseSpell()
	{
		if (IsAvailable)
		{
			IsAvailable = false;
			PrepareSpell();
		}
	}

	protected virtual void PrepareSpell()
	{
	}

	private void SetAsAvailable()
	{
		IsAvailable = true;
	}
}