using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{

    public PlayerData playerData; 

    public PlayerGunData playerGunData;

  
    public void Update()
    {
        //gun logic
        SetIsRequestingShot();
        ReloadIfClipEmpty();
        FireOnReady();
                
    }


   

    

    private void SetIsRequestingShot(){
        GetComponentInChildren<Gun>().isRequestingShot = Input.GetKey(KeyCode.Mouse0);
    }    

    private void ReloadIfClipEmpty(){
        GetComponentInChildren<Gun>().isClipEmpty = GetComponentInChildren<Gun>().IsClipEmpty();
        if (GetComponentInChildren<Gun>().isClipEmpty)
        {
            GetComponentInChildren<Gun>().Reload();
        }
    }

    private void FireOnReady(){
        if (GetComponentInChildren<Gun>().isShotReady())
        {
            GetComponentInChildren<Gun>().FireWeapon(this.playerGunData.bulletSpawn.forward);
        }
    }    


    
}
