using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovementController : MonoBehaviour
{

    public NpcMovementData npcMovementData;    
     

    public  void Start(){

        GetComponentInChildren<NpcGunController>().SetFireAtWill(true);
        this.npcMovementData.coverObjects = GlobalReferences.Instance.coverObjects; 
        UpdateCoverObject();
    }

    public  void Update()
    {
        if(!GetComponent<NpcGunController>().IsLineOfSight()){
            UpdateSweepCoverObjects();
        }else{
            this.npcMovementData.agent.SetDestination(transform.position);
        }
    }

    public void UpdateSweepCoverObjects(){
        if (this.npcMovementData.isWaiting) return; 

        this.npcMovementData.closestCoverObject = GetClosestCoverObject();
        if (this.npcMovementData.closestCoverObject != null)
        {
            float distanceToCover = Vector3.Distance(transform.position, 
            this.npcMovementData.closestCoverObject.transform.position);

            
            if (distanceToCover < 2f && !this.npcMovementData.isWaiting)
            {
                StartCoroutine(StayInCoverBeforeMoving());
            
                
            }

        
            Vector3 targetPosition = this.npcMovementData.closestCoverObject.transform.position;
            targetPosition.z +=1f; //sit behind target a lil, should prolly replace with an algorithm
            //that caculates which side of the cover would actually block line of sight from the player lul kms
            
            this.npcMovementData.agent.SetDestination(targetPosition);
        
        }
    }


    private GameObject GetClosestCoverObject()
    {
        if (HasValidCoverObjects())
        {
            GameObject closestObject = null;
            float closestDistance = float.MaxValue;

            foreach (GameObject obj in this.npcMovementData.coverObjects)
            {
                if (! IsInvalidCoverObject(obj) && ! IsCoverOccupiedBySquad(obj))
                {
                float distance = Vector3.Distance(transform.position, obj.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestObject = obj;
                    }
                }
            }

            return closestObject;
        }else{
            return null; 
        }
    }

    private bool HasValidCoverObjects()
    {
        return this.npcMovementData.coverObjects != null && 
        this.npcMovementData.coverObjects.Count > 0;
    }

    private bool IsInvalidCoverObject(GameObject obj)
    {
        return obj == null || this.npcMovementData.usedCoverObjects.Contains(obj) || IsWithinTargetRadius(obj);
    }


    private bool IsWithinTargetRadius(GameObject obj)
    {
        if (this.npcMovementData.target == null)
        {
            return false;
        }

        float exclusionRadius = 0.0f; 
        return Vector3.Distance(this.npcMovementData.target.transform.position, obj.transform.position) < exclusionRadius;
    }


    private bool IsCoverOccupiedBySquad(GameObject obj)
    {
        foreach (GameObject squadMember in this.npcMovementData.squad)
        {
            if (squadMember == null || squadMember == gameObject) 
            {
                continue;
            }

            NpcMovementController squadMemberAI = squadMember.GetComponent<NpcMovementController>();
            if (squadMemberAI != null && squadMemberAI.npcMovementData.closestCoverObject == obj)
            {
                return true;
            }
        }
        return false;
    }

    private IEnumerator StayInCoverBeforeMoving()
    {
        this.npcMovementData.isWaiting = true;

    
        yield return new WaitForSeconds(this.npcMovementData.coverStayTime);

    
        MarkCoverAsUsed(this.npcMovementData.closestCoverObject);

        this.npcMovementData.isWaiting = false;
        UpdateCoverObject(); 
    }

    public void SetSlowEffect(float slowEffect){
        float speed = GetComponent<UnityEngine.AI.NavMeshAgent>().speed;
        float newSpeed = speed/slowEffect; 
        GetComponent<UnityEngine.AI.NavMeshAgent>().speed = newSpeed;
        StartCoroutine(ResetSpeed(speed));
    }

    private IEnumerator ResetSpeed(float originalSpeed){
        yield return new WaitForSeconds(1f);
        GetComponent<UnityEngine.AI.NavMeshAgent>().speed = originalSpeed;
    }



    public void MarkCoverAsUsed(GameObject coverObject)
    {
        if (coverObject != null)
        {
            this.npcMovementData.usedCoverObjects.Add(coverObject);
        }
    }

    private void UpdateCoverObject()
    {
        this.npcMovementData.closestCoverObject = GetClosestCoverObject();
    }

}
