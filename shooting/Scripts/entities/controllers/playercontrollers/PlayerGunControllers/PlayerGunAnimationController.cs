using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunAnimationController : MonoBehaviour
{
    public PlayerData playerData;
    public PlayerGunData playerGunData;

   
    //Animation Event Trigger for aiming
    public void ToggleAimDown(){
        TranslateCameraToADS();
        this.playerGunData.SetAiming(true); 
    }

    //Animation Event Trigger for ending aiming
    public void ToggleAimUp(){
        TranslateCameraToSight();
        this.playerGunData.SetAiming(false);
    }

    private void TranslateCameraToADS(){
        this.playerData.playerCamera.gameObject.SetActive(false);
        this.playerData.aimCamera.gameObject.SetActive(true);   
    }

    private void TranslateCameraToSight(){
        this.playerData.playerCamera.gameObject.SetActive(true);
        this.playerData.aimCamera.gameObject.SetActive(false);
    }
}
