using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [Header("Raycast data")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float raycastLength;
    [SerializeField] private LayerMask hitMask;
    
    public Vector3 GetNewRotation()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hit, raycastLength, hitMask))
        {
            var hitPos = hit.point;
            return new Vector3(hitPos.x, transform.position.y, hitPos.z);
        }
        return Vector3.zero;
    }
}
