using UnityEngine;
public class UnitMove : MonoBehaviour
{
	public void MoveForward(float speed, float deltaTime)
	{
		transform.position += transform.forward * (speed * deltaTime);
	}
}