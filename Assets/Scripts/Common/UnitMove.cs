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

	public void UseVelocity()
	{
		rBody.velocity = transform.forward * currentSpeed;
	}

	public void ResetVelocity()
	{
		rBody.velocity = Vector3.zero;
	}
}