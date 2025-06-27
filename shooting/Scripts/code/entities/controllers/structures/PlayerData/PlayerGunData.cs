using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunData : MonoBehaviour
{

    public GameObject gun;

    public Transform bulletSpawn;

    private bool aiming = false; 

    private bool zoomed = false;

    private Vector3 targetRotation;  
 
    private Vector3 recoil; 

    public Vector3 GetTargetRotation()
    {
        return targetRotation;
    }

    public void SetTargetRotation(Vector3 value)
    {
        targetRotation = value;
    }

    public Vector3 GetRecoil()
    {
        return recoil;
    }

    public void SetRecoil(Vector3 value)
    {
        recoil = value;
    }

    public bool GetAiming()
    {
        return aiming;
    }

    public bool GetZoomed()
    {
        return zoomed;
    }

    public void SetAiming(bool value)
    {
        aiming = value;
    }

    public void SetZoomed(bool value)
    {
        zoomed = value;
    } 

}
