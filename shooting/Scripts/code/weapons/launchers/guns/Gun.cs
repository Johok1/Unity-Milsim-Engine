using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour 
{
   

    public GameObject player, hold, gun, bulletPrefab;

    public Transform bulletSpawn;

   

    [HideInInspector]
    public bool bulletNotLaunched, isClipEmpty, isRequestingShot;

    [HideInInspector]
    public float bulletsLeft, reloadTimer;

    [HideInInspector]
    public Quaternion recoil;

    private float reloadTime,bulletPrefabLifeTime,spreadOverTimeModifier,clipSize,shootingDelay,
    spreadIntensity,recoilX, recoilY,recoilMultiplierX,recoilMultiplierY,shakeIntensity,triggerHeldTime = 1f;

    private bool allowReset = true;

    private GunSettings gunSettings;
    

    public void SetGunSettings(GunSettings gunSettings){

        this.gunSettings = gunSettings;
         reloadTime = gunSettings.reloadTime;

        bulletPrefabLifeTime = gunSettings.bulletPrefabLifeTime;
        spreadOverTimeModifier = gunSettings.spreadOverTimeModifier;
        clipSize = gunSettings.clipSize;
        shootingDelay = gunSettings.shootingDelay; 
        spreadIntensity = gunSettings.spreadIntensity; 
        recoilX = gunSettings.recoilX;
        recoilY = gunSettings.recoilY;
        recoilMultiplierX = gunSettings.recoilMultiplierX;
        recoilMultiplierY = gunSettings.recoilMultiplierY; 

        shakeIntensity = gunSettings.shakeIntensity; 
    }
  

    private void Awake()
    {
        bulletNotLaunched = true;
        bulletsLeft = clipSize;
        reloadTimer = reloadTime;

    }

    
    void Start(){
       Cursor.lockState = CursorLockMode.Locked;
       recoil = Quaternion.identity; 
    }


    public virtual bool isShotReady()
    {
        return bulletNotLaunched  && !isClipEmpty && isRequestingShot;
    }
 

    public bool IsClipEmpty()
    {
        return bulletsLeft <= 0;
    }

    private Quaternion CalculateRecoilRotation(float shakeIntensity, float recoilY, float recoilX, float recoilMultiplierY, 
    float recoilMultiplierX, Transform recoilingObject)
    {
         Quaternion shakeRotation = Quaternion.Euler(recoilX * recoilMultiplierX, recoilY * recoilMultiplierY ,0f );
        
       
         Quaternion targetRotation = shakeRotation;
         targetRotation *= ServiceManager.physicsService.GetRandomShakeQuaternion(shakeIntensity
         );
      
      return targetRotation;
    }

    public void UpdateRecoil(){
         recoil= this.CalculateRecoilRotation
        (this.shakeIntensity, this.recoilX, this.recoilY, this.recoilMultiplierX
        , this.recoilMultiplierY
        , this.hold.transform);
    }

    public void FireWeapon(Vector3 firingDirection)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position,
           Quaternion.Euler(firingDirection));

        Bullet bulletObj = bullet.GetComponent<Bullet>();

        bulletObj.SetBulletOriginEntity(this.player.GetComponent<Entity>());
        
        GameObject firedBullet = bulletObj.ApplyBulletImpact(bullet, firingDirection, bulletSpawn);


        
        SetBulletFired();

        UpdateRecoil();

        
       

        GameObjectGarbageCollector.Instance.AddToGarbageBin(firedBullet,bulletPrefabLifeTime);

        if (allowReset)
        {
            Invoke("ResetShot", shootingDelay);
            allowReset = false;
        }
    }

    private void SetBulletFired()
    {
        bulletsLeft--;
        bulletNotLaunched = false;
    }

  
    private void ResetShot()
    {
        bulletNotLaunched = true;
        allowReset = true;
    }

    public virtual void Reload()
    {
        reloadTimer--;
        print("reloading");
        if (reloadTimer <= 0)
        {
            reloadTimer = reloadTime;
            bulletsLeft = clipSize;
        }

    }

}
