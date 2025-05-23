using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunRecoilController : MonoBehaviour
{
   
    public PlayerData playerData;
    public PlayerGunData playerGunData;
   
    void Update()
    {

        UpdateRecoilFromGun();
        ApplyRecoil();
    }

    private void UpdateRecoilFromGun(){
        Quaternion targetRecoil = GetComponentInChildren<Gun>().recoil; 
        targetRecoil.z = 0;    

        Vector3 targetRotation = this.playerGunData.GetTargetRotation();
        
        Vector3 recoil = new Vector3(targetRotation.x + targetRecoil.eulerAngles.x,
        targetRotation.y+targetRecoil.eulerAngles.y,0);

        this.playerGunData.SetRecoil(recoil);
    }

    private void ApplyRecoil(){
        if(GetComponentInChildren<Gun>().isRequestingShot){
            Vector3 recoil = this.playerGunData.GetRecoil();

            Vector3 recoilHorizontal = new Vector3(0, recoil.y,0);
            this.playerData.player.transform.Rotate(recoilHorizontal);

            Vector3 recoilVertical = new Vector3(recoil.x, 0, 0);
            this.playerData.playerCamera.transform.Rotate(recoilVertical);
        }

    }
}
