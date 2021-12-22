using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CapsuleCollider2D))]
public class Slide : MonoBehaviour
{
    #region Fields
    
    [SerializeField] private BoolVariable isPaused = null;
    [SerializeField] private BoolVariable isSliding = null;
    [SerializeField] private CapsuleCollider2D standingCollider = null;
    [SerializeField] private CapsuleCollider2D slidingCollider = null;
    [SerializeField] private PhysicsMaterial2D playerMaterial;

    #endregion

    #region Inputs

    public void OnSlideInput(InputAction.CallbackContext context)
    {
        if (isPaused.Value) return;
        
        if (context.started)
        {
            DoSlide(true);
        }
        else if (context.canceled)
        {
            DoSlide(false);
        }
    }

    #endregion

    #region Private Methods

    private void DoSlide (bool sliding)
    {
        playerMaterial.friction = sliding ? 0.1f : 0.5f;
        standingCollider.enabled = !sliding;
        slidingCollider.enabled = sliding;
        isSliding.Value = sliding;
    }

    #endregion
}