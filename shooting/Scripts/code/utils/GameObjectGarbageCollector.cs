using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectGarbageCollector : MonoBehaviour
{

    public static GameObjectGarbageCollector Instance { get; set; }

    
   

    private class TimedGarbage
    {
        public GameObject obj;
        public float destroyTime;
    }

    private List<TimedGarbage> timedGarbage = new List<TimedGarbage>();

    public void AddToGarbageBin(GameObject gameObject, float delay = 10f)
    {
        timedGarbage.Add(new TimedGarbage
        {
            obj = gameObject,
            destroyTime = Time.time + delay
        });
    }

    private void Start()
    {
        StartCoroutine(StaggeredGarbageCollector());
    }

    private IEnumerator StaggeredGarbageCollector()
    {
        while (true)
        {
            float now = Time.time;

            for (int i = timedGarbage.Count - 1; i >= 0; i--)
            {
                if (timedGarbage[i].destroyTime <= now)
                {
                    if (timedGarbage[i].obj != null)
                        Destroy(timedGarbage[i].obj);

                    timedGarbage.RemoveAt(i);

                    // 🔄 Wait a short time between destructions to avoid FPS drop
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // Check again next frame
            yield return null;
        }
    }


    
    
    
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

}
