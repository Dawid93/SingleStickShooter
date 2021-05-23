using UnityEngine;
public class UnitMove : MonoBehaviour
{
	private float defaultSpeed;
	private float currentSpeed;
	
	public void SetDefaultSpeed(float defaultSpeed)
	{
		this.defaultSpeed = defaultSpeed;
		currentSpeed = defaultSpeed;
	}

	public void ChangeSpeed(float factorModifier)
	{
		currentSpeed = currentSpeed * factorModifier;
	}

	public void ResetSpeed()
	{
		currentSpeed = defaultSpeed;
	}
	
	public void MoveForward(float deltaTime)
	{
		transform.position += transform.forward * (currentSpeed * deltaTime);
	}
}