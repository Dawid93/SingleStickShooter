using ObjectPool;
using UnityEngine;

public class SlowdownSpellController : BaseSpellController
{
	protected override void PrepareSpell(Vector3 spawnPoint, Quaternion rotation)
	{
		base.PrepareSpell(spawnPoint, rotation);
		ObjectPooler.Instance.GetFromPool(Consts.SlowdownSpellTag, spawnPoint, rotation, null);
	}
}