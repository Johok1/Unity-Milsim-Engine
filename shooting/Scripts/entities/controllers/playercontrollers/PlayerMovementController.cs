using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    public PlayerData playerData; 

    private float kickbackEffect = 1f;

    private Vector3 velocity;

    private bool isGrounded;


    public void SetKickbackEffect(float kickbackEffect)
    {
        this.kickbackEffect = kickbackEffect;
    }

    public void Update()
    {
        Vector3 move =  GetMovementVectorFromInput();
 
        playerData.controller.Move(((move * playerData.speed) / kickbackEffect) * Time.deltaTime);
    }

    private Vector3 GetMovementVectorFromInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;

        return move;
    }


}