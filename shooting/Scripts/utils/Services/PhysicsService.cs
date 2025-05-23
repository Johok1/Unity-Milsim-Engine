using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsService : Service
{
    public Vector3 GetDirectionFromTransformPosition(Transform from, Transform to)
    {
        //get the direction and normalize to 1 
        Vector3 direction = (to.position - from.position).normalized;
        return direction;
    }

    public Quaternion QuaternionFromTwoTransforms(Transform from, Transform to)
    {
        // Compute the direction from "from" to "to"
        Vector3 direction = (to.position - from.position).normalized;


        if (direction == Vector3.zero)
        {
            return from.rotation; // No rotation needed if positions are identical
        }

        // Compute the target rotation to look at the "to" position
        return Quaternion.LookRotation(direction, Vector3.up);
    }

    public Quaternion QuaternionFromTransformDirection(Transform from, Vector3 direction)
{
    // Normalize the direction vector
    Vector3 normalizedDirection = direction.normalized;
    

    // Handle the case where the direction is zero
    if (normalizedDirection == Vector3.zero)
    {
        return from.rotation; // No rotation needed
    }

    // Compute the target rotation to look in the specified direction
    return Quaternion.LookRotation(normalizedDirection, Vector3.up);
}


    public Vector3 CalculateRandomVectorAtDirection(Vector3 direction, float range, float modifier)
    {

        float spreadX = UnityEngine.Random.Range(-range, range) * modifier;
        float spreadY = UnityEngine.Random.Range(-range, range) * modifier;

        return direction + new Vector3(spreadX, spreadY, 0);
    }

    public Quaternion GetRandomShakeQuaternion(float shakeIntensity)
    {
        //Generate random floats
        float randomX = UnityEngine.Random.Range(-1f, 1f);
        float randomY = UnityEngine.Random.Range(-1f, 1f);

        //Scale random shake effect by spread intensity
        Quaternion shakeRotation = Quaternion.Euler(randomX * shakeIntensity, randomY * shakeIntensity, 0);
        return shakeRotation;
    }

    public Quaternion GetRandomShakeQuaternionPointed(float x, float y, float shakeIntensityX, float shakeIntensityY)
    {
        //Generate random floats
        float randomX = UnityEngine.Random.Range(0, x);
        float randomY = UnityEngine.Random.Range(0, y);

        //Scale random shake effect by spread intensity
        Quaternion shakeRotation = Quaternion.Euler(randomX * shakeIntensityX, randomY * shakeIntensityY, 0);
        return shakeRotation;
    }

    public Vector3 GetDirectionToVector3(Vector3 start, Vector3 destination)
    {
        return destination - start;
    }

    public Vector3 GetPositionCameraPointing(Camera playerCamera)
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        Vector3 targetPoint = ServiceManager.raycastService.CastRayAtPoint(ray);

        return targetPoint;
    }

}
