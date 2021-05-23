using UnityEngine;

public class BaseMoveManager<T> : BaseManager<T> where T : IMoveable
{
	private void FixedUpdate()
	{
		if (!isGameStarted)
			return;
        
		foreach (var unit in units)
		{
			unit.Move();
		}
	}

	protected override void HandleGameOver()
	{
		base.HandleGameOver();
		foreach (var unit in units)
		{
			unit.StopMove();
		}
	}
}