using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalReferences : MonoBehaviour
{
    // Start is called before the first frame update


    public static GlobalReferences Instance { get; set; }

    public GameObject bulletImpactEffectPrefab; 

    public List<GameObject> coverObjects; 

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        if (bulletImpactEffectPrefab == null)
        {
            Debug.LogError("Bullet Impact Effect Prefab is not assigned in the inspector.");
        }

        if (coverObjects == null || coverObjects.Count == 0)
        {
            Debug.LogError("Cover Objects list is not assigned or empty in the inspector.");
        }
    }
    

  
}
