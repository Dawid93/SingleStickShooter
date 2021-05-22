using System;

public interface IDamageable
{ 
	event Action Dead;
	
	float Health { get; }

	void SetHealth(float health);
	void TakeDamage(float damage);
}