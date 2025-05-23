using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityController : MonoBehaviour
{
    
    public PlayerData playerData; 

    public WorldData worldData;
    
    private bool isGrounded;

    private Vector3 velocity;
   
    void Update()
    {
        
        ApplyGravity();

        UpdateIsGrounded();
        
        InputJumpIfGrounded();

    }


    private void ApplyGravity()
    {
        velocity.y += worldData.gravity * Time.deltaTime;
        //multiply by time twice because gravity is
        //an acceleration, time squared 
        playerData.controller.Move(velocity * Time.deltaTime);
    }

      private void UpdateIsGrounded()
    {
        isGrounded = Physics.CheckSphere(playerData.groundCheck.position, 
        playerData.groundDistance, 
        playerData.groundMask);
    }

    private void InputJumpIfGrounded()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(playerData.jumpHeight * -2 * worldData.gravity);
            
        }
        
    }
}
