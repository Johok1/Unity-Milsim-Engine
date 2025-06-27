using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunADSController : MonoBehaviour
{
   
    public PlayerData playerData;
    public PlayerGunData playerGunData;

    void Update()
    {
        Cursor.visible = false;
       
        AimDownSight();
        ZoomInSight();

        FixCamera();
        LockZAxisRotation();
    }

    private void AimDownSight(){
        if(IsAimInput()){
            this.playerData.animator.SetTrigger("AimToggle");
        }
    }

    private bool IsAimInput(){
        return Input.GetKeyDown(KeyCode.Mouse1);
    }

   
    private void ZoomInSight(){
        if(this.playerGunData.GetAiming()){
           if(Input.GetKeyDown(KeyCode.Q)){
                if(!this.playerGunData.GetZoomed()){
                    LookCloser(this.playerData.aimCamera);
                    this.playerGunData.SetZoomed(true);
                }else{
                    LookNormal(this.playerData.aimCamera);
                    this.playerGunData.SetZoomed(false);
                }
                
            }
        }
    }

    private void LookCloser(Camera camera){
        camera.fieldOfView = 15f; 
        this.playerData.mouseSensitivity = this.playerData.mouseSensitivity/4; 
    }

    private void LookNormal(Camera camera){
        camera.fieldOfView = 75f; 
        this.playerData.mouseSensitivity  = this.playerData.mouseSensitivity*4; 
    }

    private void FixCamera(){
        this.playerData.playerCamera.transform.position = this.playerData.returnPosition.position;
        this.playerData.playerCamera.fieldOfView = 100f; 
    }

    private void LockZAxisRotation()
    {
        Vector3 rotation = this.playerData.playerCamera.transform.eulerAngles;
        rotation.z = 0;
        this.playerData.playerCamera.transform.eulerAngles = rotation;

    }    

   
}
