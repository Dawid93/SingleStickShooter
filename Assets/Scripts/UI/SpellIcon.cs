using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

public class SpellIcon : MonoBehaviour
{
	[SerializeField] private Image spellIcon;
	[SerializeField] private Image spellIconFill;

	private SpellController spellController;
	private Timer currentTimer;

	public void SetSpellController(SpellController spellController)
	{
		this.spellController = spellController;
		this.spellController.StartCooldown += HandleStartCooldownCountdown;
		this.spellController.FinishCooldown += HandleStopCountdown;
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

	public void SetImage(Sprite icon)
	{
		spellIcon.sprite = icon;
		spellIconFill.sprite = icon;
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