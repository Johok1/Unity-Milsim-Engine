using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabService : Service
{

    public GameObject InstantiatePrefab(GameObject prefab, Vector3 position)
    {
        //create bullet at bullet spawn position with default rotation 
        GameObject bullet = Instantiate(prefab, position,
            Quaternion.identity);

        return bullet;
    }

    public void LaunchPrefab(GameObject prefab, Vector3 forwardDirection, float velocity)
    {
        //rotate bullet towards shooting direction 
        prefab.transform.forward = forwardDirection;

        //add force to rigidbody component scaled by the bulletVelocity modifier 
        prefab.GetComponent<Rigidbody>().AddForce((forwardDirection) * velocity,
            ForceMode.Impulse);
    }

}
