using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CapsuleCollider2D))]
public class Slide : MonoBehaviour
{
    // states
    [SerializeField]
    BoolVariable isSliding = null;

    [SerializeField]
    BoolVariable isPaused = null;

    [SerializeField]
    CapsuleCollider2DVariable fitCollider = null;
    

    // components
    [SerializeField]
    CapsuleCollider2D standingCollider = null;

    [SerializeField]
    CapsuleCollider2D slidingCollider = null;
 
    private void OnEnable() {
        fitCollider.Value = standingCollider;
    }

    private void OnDisable() {
        fitCollider.Value = null;
    }


    public void OnSlideInput(InputAction.CallbackContext context)
    {
        if (!isPaused.Value)
        {
            if (context.started)
            {
                OnStartSliding();
            }
            else if (context.canceled)
            {
                OnStopSliding();
            }
        }
    }

    public void OnStartSliding ()
    {
        standingCollider.enabled = false;
        slidingCollider.enabled = true;
        isSliding.Value = true;
        fitCollider.Value = slidingCollider;
    }

    public void OnStopSliding ()
    {
        standingCollider.enabled = true;
        slidingCollider.enabled = false;
        isSliding.Value = false;
        fitCollider.Value = standingCollider;
    }
}