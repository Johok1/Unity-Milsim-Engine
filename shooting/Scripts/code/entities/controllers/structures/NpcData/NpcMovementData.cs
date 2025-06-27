using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovementData : MonoBehaviour
{
    
    public UnityEngine.AI.NavMeshAgent agent;

    public GameObject target;
  

    public List<GameObject> coverObjects; 

    public HashSet<GameObject> usedCoverObjects = new HashSet<GameObject>();

    public List<GameObject> squad;  

    public GameObject closestCoverObject; 

    public float slowEffect = 1f; 

    public bool isWaiting = false; 

    [SerializeField] public float coverStayTime = 5.0f; 

   
}
