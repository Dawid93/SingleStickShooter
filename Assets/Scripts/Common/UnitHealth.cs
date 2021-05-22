using System;
using UnityEngine;

public class UnitHealth : MonoBehaviour, IDamageable
{
	public event Action Dead;
	
	public float Health { get; private set; }

	public void SetHealth(float health)
	{
		Health = health;
	}

	public void TakeDamage(float damage)
	{
		Health -= damage;

		if (Health <= 0)
			Dead?.Invoke();
	}
}