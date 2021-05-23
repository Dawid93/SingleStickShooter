using UnityEngine;
public class UnitMove : MonoBehaviour
{
	private float defaultSpeed;
	private float currentSpeed;
	private Rigidbody rBody;
	
	public void SetDefaultSpeed(float defaultSpeed)
	{
		this.defaultSpeed = defaultSpeed;
		currentSpeed = defaultSpeed;
	}

	public void SetRigidbody(Rigidbody rBody)
	{
		this.rBody = rBody;
	}

	public void ChangeSpeed(float factorModifier)
	{
		currentSpeed = currentSpeed * factorModifier;
	}

	public void ResetSpeed()
	{
		currentSpeed = defaultSpeed;
	}
	
	public void MoveTransformForward(float deltaTime)
	{
		transform.position += transform.forward * (currentSpeed * deltaTime);
	}

	public void MoveRigidbodyForward(float deltaTime)
	{
		var step = transform.forward * (currentSpeed * deltaTime);
		rBody.MovePosition(rBody.position + step);
	}
}