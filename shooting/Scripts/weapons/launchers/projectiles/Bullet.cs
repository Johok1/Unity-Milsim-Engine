using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float damage = 1f;

    public float grains = 55f; 

    public float initialMuzzleVelocity = 991f;

    public float bulletCalliber = 5.56f; 

    public float barrelLength = 0.508f;

    public float timeInBarrel = 0.045f;

    private bool bulletAlive = false;

    private GameObject bullet;
    private Transform bulletSpawn;
    private Vector3 shootingDirection; 

    private Entity bulletOriginEntity; 

   void Start()
   {
        var trail = GetComponent<TrailRenderer>();
    if (trail != null)
    {
        trail.Clear();
        trail.emitting = true;
    }
   }
   

  public void SetBulletOriginEntity(Entity entity){
    this.bulletOriginEntity = entity; 
  }

   private void OnCollisionEnter(Collision collision)
   {
        if (collision.gameObject.CompareTag("Target"))
        {
           this.CreateBulletImpactEffect(collision);

           DamageTargetIfHit(collision);

           Destroy(gameObject);

           bulletAlive = false;
        }
   }



   public GameObject ApplyBulletImpact(GameObject bullet, Vector3 shootingDirection, Transform bulletSpawn)
   {
        this.bullet = bullet;
        this.shootingDirection = shootingDirection;
        this.bulletSpawn = bulletSpawn; 
    
        
        float impulse =  CalculateImpulse();

        bullet.transform.forward = shootingDirection;

      
        bullet.GetComponent<Rigidbody>().
        AddForce((bulletSpawn.forward.normalized) * impulse*100, ForceMode.Impulse);
        
        bulletAlive = true; 
      

        return bullet;
   }

    private float CalculateImpulse()
    {
        float feetPerSecond = initialMuzzleVelocity * 3.28084f; 
        float muzzleEnergy = (this.grains*(feetPerSecond*feetPerSecond))/450240f;
       
        //convert from ft-lbs to joule
        muzzleEnergy = muzzleEnergy*1.35582f; 
       
        //divide muzzle energy by barrel length for force
        float force = muzzleEnergy/ barrelLength;
        
        //time s in barrel times force will give impulse
        return force * timeInBarrel;
    }

   private void DamageTargetIfHit(Collision collision) 
   {
        Entity target = collision.gameObject.transform.GetComponent<Entity>();

        if (target != null && !target.CompareTo(this.bulletOriginEntity))
        {
            target.TakeDamage(damage);
        }
   }

    private void CreateBulletImpactEffect(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        GameObject hole = CreateBulletHoleAtImpact(contact);

        SetChildParent(hole, collision.gameObject);

    }

    private GameObject CreateBulletHoleAtImpact(ContactPoint contact)
    {
        GameObject hole = Instantiate(
            GlobalReferences.Instance.bulletImpactEffectPrefab,
            contact.point - (-contact.normal * 0.005f),
            Quaternion.LookRotation(-contact.normal)
        );
        return hole;
        GameObjectGarbageCollector.Instance.AddToGarbageBin(hole);
    }

    private void SetChildParent(GameObject child, GameObject parent)
    {
        child.transform.SetParent(parent.transform);

    }
    


   

}
