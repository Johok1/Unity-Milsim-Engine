using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcGunController : MonoBehaviour
{

    public NpcData npcData; 
    
    public NpcGunData npcGunData; 

    public NpcGunTargetingData npcGunTargetingData;

    
    
    public void Start(){
        this.npcData.animator.SetTrigger("AimToggle");
    }

    

    public void SetFireAtWill(bool fireAtWill){
        this.npcGunData.fireAtWill = fireAtWill; 
    }

    
    public void Update()
    {
        ReloadIfEmpty();
       
        if(IsLineOfSightAtDirection(this.npcGunTargetingData.targetDirection)){
            
           RequestShot();
           FireIfReady();
    
        } 
    }



    private void FireIfReady(){
        if (GetComponentInChildren<Gun>().isShotReady() && this.npcGunData.fireAtWill)
            {       
                
                GetComponentInChildren<Gun>().FireWeapon(this.npcGunTargetingData.targetDirection);
                this.npcData.shockwaveSource.Play();
            }
    }

    private void RequestShot(){
         GetComponentInChildren<Gun>().isRequestingShot = true;
    }

    private void ReloadIfEmpty(){
        if (GetComponentInChildren<Gun>().IsClipEmpty())
        {
            GetComponentInChildren<Gun>().Reload();
        }
    }

   

    public bool IsLineOfSight()
    {
        Vector3 directionToTarget = ServiceManager.physicsService.GetPositionCameraPointing(this.npcData.aiCamera)-
        this.npcGunData.gun.transform.position;
       
        return ServiceManager.raycastService.
        isRayHitObjectOfType<PlayerEntity>(this.npcData.aiCamera.transform.position, 
        directionToTarget, 10000, Color.green);
    }

    public bool IsLineOfSightAtDirection(Vector3 direction)
    {  
        return ServiceManager.raycastService.
        isRayHitObjectOfType<PlayerEntity>(this.npcData.aiCamera.transform.position, 
        direction, 10000, Color.red);
    }

   

}



/*
    private void FindTarget(int maxAttempts, int attempts, bool lineOfSightFound, Vector3 direction)
    {
        while (attempts < maxAttempts && !lineOfSightFound)
            {
            if (IsLineOfSightAtDirection(direction))
            {
                
                    shootingDirection = direction;
                //  shootingDirection.y += 0.1f;
                    isLineOfSight = true;
                    isUniqueDirection = true; 
                    break;
            }
            else
            {
                
                    Vector3 randomOffset = new Vector3(
                        UnityEngine.Random.Range(-0.02f, 0.02f), 
                        UnityEngine.Random.Range(-0.04f, 0.04f), 
                        UnityEngine.Random.Range(0,0)  
                    );

                    direction += randomOffset; 
                    direction.Normalize();    
                    attempts++;
                    isLineOfSight = false; 
            }
            }
        //yield return new WaitForSeconds(0.001f);
    }
*/