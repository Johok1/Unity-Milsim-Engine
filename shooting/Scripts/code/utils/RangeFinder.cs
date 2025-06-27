using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeFinder : MonoBehaviour
{
    public Transform bulletSpawn; 
    public Text rangeUi;     // UI Text component to display the distance

   // public GameObject bulletSpawn;
    // Update is called once per frame
    void Update()
    {
        
        // Cast a ray from the camera's position in the forward direction
        Ray ray = new Ray(bulletSpawn.position, bulletSpawn.forward); // Or use rangeCam.transform.forward for continuous raycasting
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
        // Check if the ray hits something
        if (Physics.Raycast(ray, out hit))
        {
            // If it hits something, calculate the distance from the object to the hit point
            float distance = Vector3.Distance(transform.position, hit.point);
            rangeUi.text = distance.ToString("F2") + " m"; // Display the distance with 2 decimal points
        }
        else
        {
            // If it doesn't hit anything, display "- m"
            rangeUi.text = "- m";
        }
    }
}
