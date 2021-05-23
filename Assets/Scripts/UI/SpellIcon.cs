using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

public class SpellIcon : MonoBehaviour
{
	[SerializeField] private Image spellIcon;
	[SerializeField] private Image spellIconFill;

	private BaseSpellController baseSpellController;
	private Timer currentTimer;

	public void SetSpellController(BaseSpellController baseSpellController)
	{
		this.baseSpellController = baseSpellController;
		this.baseSpellController.StartCooldown += HandleStartCooldownCountdown;
		this.baseSpellController.FinishCooldown += HandleStopCountdown;
		this.baseSpellController.SpellUse += HandleBaseSpellUse;
	}

	public void SetImage(Sprite icon)
	{
		spellIcon.sprite = icon;
		spellIconFill.sprite = icon;
	}

	private void HandleStartCooldownCountdown(Timer timer)
	{
		currentTimer = timer;
		currentTimer.TimerUpdate += HandleTimerUpdate;
	}

	private void HandleStopCountdown()
	{
		currentTimer.TimerUpdate -= HandleTimerUpdate;
		SetFill(1);
		currentTimer = null;
	}

	private void HandleTimerUpdate()
	{
		SetFill(currentTimer.GetNormalizedTime());
	}

	private void HandleBaseSpellUse()
	{
		SetFill(0);
	}

	public void SetColor(Color background, Color fill)
	{
		spellIcon.color = background;
		spellIconFill.color = fill;
	}

	public void SetFill(float fill)
	{
		spellIconFill.fillAmount = fill;
	}
}