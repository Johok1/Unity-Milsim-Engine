using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunRotationController : MonoBehaviour
{

    public PlayerData playerData;
    public PlayerGunData playerGunData;

    void Update()
    {
        UpdateTargetRotation(this.playerData.mouseSensitivity);
        ApplyTargetRotation();
    }

    
    private void ApplyTargetRotation(){
 
        this.playerData.playerCamera.transform.Rotate(this.playerGunData.GetTargetRotation());
           
    }

    private void UpdateTargetRotation(float mouseSensitivity){
        
        
        RotatePlayerByRotationTarget(Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime);

        float yRotation = GetInvertedMouseYInput();

        Vector3 targetRotation = this.playerGunData.GetTargetRotation();

        targetRotation.x = yRotation;

        this.playerGunData.SetTargetRotation(targetRotation);
    }

    private void RotatePlayerByRotationTarget(float target){
        this.playerData.player.transform.Rotate(Vector3.up * target );
    }

    private float GetInvertedMouseYInput(){
        float mouseY = Input.GetAxis("Mouse Y") * this.playerData.mouseSensitivity * Time.deltaTime;

        float yRotation = -mouseY;

        return yRotation;
    }
}
