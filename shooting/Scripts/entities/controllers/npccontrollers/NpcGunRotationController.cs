using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcGunRotationController : MonoBehaviour
{
    public NpcData npcData;

    public NpcGunData npcGunData;

    public NpcGunTargetingData npcGunTargetingData;
    
    void Update()
    {
        UpdateTargetDirection();
        LookAtDirection(this.npcGunTargetingData.targetDirection);
    }

     private void UpdateTargetDirection(){
        this.npcGunTargetingData.targetDirection = 
        this.npcGunTargetingData.target.transform.position - 
        this.npcGunData.bulletSpawn.transform.position;

    }
    


    private void LookAtDirection(Vector3 direction)
    {

        var targetRotation = ServiceManager.physicsService.
        QuaternionFromTransformDirection(this.npcData.aiObject.transform, direction);
       
        RotateEntityTowardsDirection(targetRotation);
        RotateGunTowardsDirection(targetRotation);
        RotateHeadTowardsDirection(targetRotation);
        RotateBulletspawnTowardsDirectionWithRecoil(targetRotation);

    
    }

    private void RotateEntityTowardsDirection(Quaternion targetRotation){
        this.npcData.aiObject.transform.rotation = Quaternion.Slerp(this.npcData.aiObject.transform.rotation, 
        targetRotation, Time.deltaTime );
    }

    private void RotateGunTowardsDirection(Quaternion targetRotation){
        this.npcGunData.gun.transform.rotation = Quaternion.Slerp(this.npcGunData.gun.transform.rotation, 
        targetRotation, Time.deltaTime);
    }

    private void RotateHeadTowardsDirection(Quaternion targetRotation){
        this.npcData.head.transform.rotation = Quaternion.Slerp(this.npcData.head.transform.rotation, 
        targetRotation, Time.deltaTime);
    }

    private void RotateBulletspawnTowardsDirectionWithRecoil(Quaternion targetRotation, float recoilRange = 1.2f){
       
        Vector3 randomVector = new Vector3(
            Random.Range(-recoilRange, recoilRange),
            Random.Range(-recoilRange, recoilRange),
            Random.Range(-10f, 10f)
        );

        Vector3 recoiledTargetRotation = new Vector3(targetRotation.eulerAngles.x + randomVector.x,
        targetRotation.eulerAngles.y + randomVector.y, targetRotation.eulerAngles.z +0f);

        this.npcGunData.bulletSpawn.transform.rotation =
         Quaternion.Slerp(this.npcGunData.bulletSpawn.transform.rotation,
        Quaternion.Euler(recoiledTargetRotation), Time.deltaTime * 100); 

    }
}
