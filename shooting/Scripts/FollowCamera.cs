using UnityEngine;

public class FollowCamera : MonoBehaviour
{
public Transform objectTransform;  // The transform of the object you want to move
public Camera camera;              // The camera to shoot the ray from
public float rayDistance = 30f;    // Distance for the ray to travel

void Update()
{
    // Shoot a ray from the camera's position in the direction it's facing
    Ray ray = camera.ScreenPointToRay(new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0));
   
    // If no hit, place the object at the end of the ray (rayDistance)
    objectTransform.position = ray.origin + ray.direction * rayDistance;
    
}

}
