using System;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    #region Fields

    [SerializeField] private BoolVariable isSliding = null;
    [SerializeField] private BoolVariable isGrounded = null;
    [SerializeField] private BoolVariable isMoving = null;

    [SerializeField] private Rigidbody2D playerRigidbody;
    
    #endregion

    #region Unity Events Methods

    private void Awake()
    {
        isSliding.OnValueChange += Slide;
        isGrounded.OnValueChange += Grounded;
        isMoving.OnValueChange += Move;
    }

    private void OnDestroy()
    {
        isSliding.OnValueChange -= Slide;
        isGrounded.OnValueChange -= Grounded;
        isMoving.OnValueChange -= Move;
    }
    
    private void Update()
    {
        //TODO executé chaque frame
    }
    
    #endregion

    #region Events

    public void OnPower(PowerType powerType)
    {
        switch (powerType)
        {
            case PowerType.Fall:
                //TODO add code here
                break;
            case PowerType.Winter:
                //TODO add code here
                break;
            case PowerType.Spring:
                //TODO add code here
                break;
            case PowerType.Summer:
                //TODO add code here
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(powerType), powerType, null);
        }
    }
    
    //TODO add more powers and dashs
    
    public void OnDeath() 
    {
        //TODO Quand on meurt
    }

    private void Slide()
    {
        //TODO Quand on glisse
    }

    private void Grounded()
    {
        if (isGrounded.Value)
        {
            //TODO Quand on atterri
            FMODUnity.RuntimeManager.PlayOneShot("event:/SD/Gardien/Atterissage", GetComponent<Transform>().position);
            return;
        }

        if (playerRigidbody.velocity.y > 0.1f)
        {
            //TODO Quand on va vers le haut (saut)
            FMODUnity.RuntimeManager.PlayOneShot("event:/SD/Gardien/Jump", GetComponent<Transform>().position);
        }
        else
        {
            //TODO quand on est en chute libre
        }
    }
    
    private void Move()
    {
        if (isMoving.Value)
        {
            //TODO Quand on bouge
            FMODUnity.RuntimeManager.PlayOneShot("event:/SD/Gardien/Footstep_Walk", GetComponent<Transform>().position);
        }
        else
        {
            //TODO Quand on s'arrête
        }
    }

    #endregion
}
