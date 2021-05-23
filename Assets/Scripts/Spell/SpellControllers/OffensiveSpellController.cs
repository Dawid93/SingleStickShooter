using ObjectPool;
using UnityEngine;

public class OffensiveSpellController : BaseSpellController
{
	protected override void PrepareSpell(Vector3 spawnPos, Quaternion rotation)
	{
		base.PrepareSpell(spawnPos, rotation);
		ObjectPooler.Instance.GetFromPool(Consts.OffensiveSpellTag, spawnPos, rotation, null);
	}
}