using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcEntity : Entity
{
  public NpcGunController npcGunController;

  public GunSettings gunSettings;

  public NpcMovementController npcMovementController;

  void Start(){
     npcGunController.npcGunData.gun.GetComponentInChildren<Gun>().SetGunSettings(gunSettings);
  }

   public override bool CompareTo(Entity entity){
      if(entity is PlayerEntity){
         return false; 
      }else if (entity is NpcEntity){
         return true; 
      }else{
         return false; 
      }
   }


}
