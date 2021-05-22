using System;
using UnityEngine;

namespace Player
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private PlayerRotation playerRotation;
		[SerializeField] private PlayerShoot playerShoot;

		private Vector3 newRotation;
		private void FixedUpdate()
		{
			newRotation = playerRotation.GetNewRotation();
		}

		private void Update()
		{
			transform.LookAt(newRotation);
			
			if(Input.GetMouseButtonDown(0))
				playerShoot.Shoot();
		}
	}
}