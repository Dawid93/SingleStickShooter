using System;
using UnityEngine;

public class SpellController : MonoBehaviour
{
	public event Action<Timer> StartCooldown;
	public event Action FinishCooldown;
	public event Action SpellUse;
	
	public bool IsAvailable { get; private set; }
	public BaseSpellData SpellData { get; private set; }

	[SerializeField] private BaseSpellData spellData;
	
	private Timer timer;

	private void Start()
	{
		StartCountdown();
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
	
	public void UseSpell()
	{
		if (!IsAvailable) 
			return;
		
		IsAvailable = false;
		PrepareSpell();
		SpellUse?.Invoke();
	}

	protected virtual void PrepareSpell()
	{
	}
}