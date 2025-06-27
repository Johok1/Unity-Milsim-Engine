using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastService : Service
{
    public bool isRayHitObjectOfType<T>(Vector3 position, Vector3 directionToTarget, float range, Color color)
    {
        RaycastHit hit;
        var isRaycastHitCollider = Physics.Raycast(position, directionToTarget, out hit, range);

        UnityEngine.Debug.DrawRay(position, directionToTarget * range, color, 1);

        if (isRaycastHitCollider)
        {
            //If ray interact with collider get point on collider
            if (hit.collider.gameObject.transform.GetComponent<T>() != null)
            {
                return true;
            }
        }
        return false;
    }

    public Vector3 CastRayAtPoint(Ray ray)
    {
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            //If ray interact with collider get point on collider
            targetPoint = hit.point;
        }
        else
        {
            //gets a point 100 units along the ray
            targetPoint = ray.GetPoint(100);
        }
        return targetPoint;

    }
}
