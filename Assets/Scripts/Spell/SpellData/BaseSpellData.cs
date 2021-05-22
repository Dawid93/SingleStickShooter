using UnityEngine;

public abstract class BaseSpellData : ScriptableObject
{
	public SpellTypes SpellType => spellType;
	public Sprite SpellImage => spellImage;
	public Color BackgroundImageColor => backgroundImageColor;
	public Color FillImageColor => fillImageColor;
	public float CoolDownTime => coolDownTime;
	public float MoveSpeed => moveSpeed;

	
	[SerializeField] protected SpellTypes spellType = SpellTypes.Offensive;
	[Header("UI Section")]
	[SerializeField] private Sprite spellImage;
	[SerializeField] private Color backgroundImageColor;
	[SerializeField] private Color fillImageColor;
	
	[Header("Values")]
	[SerializeField] private float moveSpeed;
	[SerializeField] private float coolDownTime;
}