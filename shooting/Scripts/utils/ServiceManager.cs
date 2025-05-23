using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceManager
{
    public static PhysicsService physicsService = new PhysicsService();
    public static PrefabService prefabService = new PrefabService();
    public static RaycastService raycastService = new RaycastService();
}
