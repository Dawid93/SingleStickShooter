public interface IDamageable
{
	float MaxHealth { get; }

	void SetHealth(float health);
	void TakeDamage(float damage);
	void Kill();
}