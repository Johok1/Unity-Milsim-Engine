using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    
    public float speed = 12f;   

    public float groundDistance = 0.4f;
    
    public float jumpHeight = 3f;

    public CharacterController controller;
    
    public GameObject player; 

    public Transform groundCheck;
   
    public LayerMask groundMask;
    
    public Camera playerCamera; 


    public Transform aimPosition; 

    public Transform returnPosition; 
    
    public Camera aimCamera; 

    public Animator animator; 
    
    public Transform bulletSpawn; 

    public AudioSource shockwaveSource;

    
}
