using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPosition : MonoBehaviour
{
    // variables
    [SerializeField]
    Vector2Variable playerSpeed = null;

    [SerializeField]
    Vector2Variable spawnPosition = null;


    // states
    [SerializeField]
    BoolVariable isGrounded = null;

    [SerializeField]
    BoolVariable isFalling = null;

    [SerializeField]
	BoolVariable isFacingRight = null;

    [SerializeField]
    BoolVariable isDead = null;


    // components
    [SerializeField]
    Collider2D m_GroundDetectionCollider = null;

    [SerializeField]
    Rigidbody2D rb = null;

    void Start() 
    {
        rb.position = spawnPosition.Value;
    }


    void FixedUpdate() 
    {
        if (isDead.Value)
        {
            rb.velocity = new Vector2 (0,0);
        }

        // check if Player is on the ground
        if (m_GroundDetectionCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            isGrounded.Value = true;
        }
        else
        {
            isGrounded.Value = false;
        }


        // check if Player is falling
        if (rb.velocity.y < 0 && !isGrounded.Value)
            isFalling.Value = true;
        else
            isFalling.Value = false;

        // check Player orientation
        if(playerSpeed.Value.x > 0)
            isFacingRight.Value = true;
        else if(playerSpeed.Value.x < 0)
            isFacingRight.Value = false;
    }
}
