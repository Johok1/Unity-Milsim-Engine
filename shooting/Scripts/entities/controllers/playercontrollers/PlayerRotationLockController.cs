using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationLockController : MonoBehaviour
{
   
    void Update()
    {
        LockZAxisRotation();

        LockXAxisRotation();
    }

    private void LockZAxisRotation()
    {
        Vector3 rotation = gameObject.transform.eulerAngles;
        rotation.z = 0;
        gameObject.transform.eulerAngles = rotation;

    }
    
    private void LockXAxisRotation()
    {
        Vector3 rotation = gameObject.transform.eulerAngles;
        rotation.x = 0;
        gameObject.transform.eulerAngles = rotation;

    }

    private void ClampXAxisRotation(float max)
    {
        Vector3 rotation = gameObject.transform.eulerAngles;
        rotation.x = Mathf.Clamp(rotation.x,0f,max);
        gameObject.transform.eulerAngles = rotation;

    }

}
