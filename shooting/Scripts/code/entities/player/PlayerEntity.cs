using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
  
  public PlayerGunController playerGunController;

  public GunSettings gunSettings;

  public PlayerMovementController playerMovementController;

  public PlayerGravityController playerGravityController;

  public PlayerRotationLockController playerRotationLockController; 


  void Start(){
      playerGunController.playerGunData.gun.GetComponentInChildren<Gun>().SetGunSettings(gunSettings);
  }

  public override bool CompareTo(Entity entity){
      if(entity is PlayerEntity){
         return true; 
      }else if (entity is NpcEntity){
         return false; 
      }else{
         return false; 
      }
  }

}
