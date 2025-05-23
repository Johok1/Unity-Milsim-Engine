using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSettings : MonoBehaviour
{
  
  public float reloadTime = 600f;
  public float bulletPrefabLifeTime = 5f;
  public float spreadOverTimeModifier = 0f;
  public float clipSize = 120.0f;
  public float shootingDelay = 2f;
  public float spreadIntensity = 0.1f;

  public float recoilX = 0.02f;

  public float recoilY = -1f;

  public float recoilMultiplierX = 1f;
  public float recoilMultiplierY = 1f; 
  public float shakeIntensity = 0.1f; 

}
