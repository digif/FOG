using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    #region Fields

    [SerializeField] private BoolVariable isSliding = null;
    [SerializeField] private BoolVariable isGrounded = null;
    [SerializeField] private BoolVariable isFacingRight = null;
    [SerializeField] private BoolVariable isMoving = null;
    [SerializeField] private SpriteRenderer playerSprite;

    [SerializeField] private Rigidbody2D playerRigidbody;
    
    private Animator animator = null;

    #endregion

    #region Unity Events Methods

    private void Awake()
    {
        animator = GetComponent<Animator>();

        isSliding.OnValueChange += Slide;
        isGrounded.OnValueChange += Grounded;
        isFacingRight.OnValueChange += FacingRight;
        isMoving.OnValueChange += Move;
    }

    private void OnDestroy()
    {
        isSliding.OnValueChange -= Slide;
        isGrounded.OnValueChange -= Grounded;
        isFacingRight.OnValueChange -= FacingRight;
        isMoving.OnValueChange -= Move;
    }
    private void Update()
    {
        animator.SetFloat(AnimatorHash.VerticalSpeed, playerRigidbody.velocity.y);
    }
    
    #endregion

    #region Events

    public void OnAutumnPower ()
    {
        animator.SetTrigger(AnimatorHash.Power);
    }
    
    public void OnDeath() 
    {
        animator.SetTrigger(AnimatorHash.Death);
    }

    private void Slide()
    {
        animator.SetBool(AnimatorHash.Slide, isSliding.Value);
    }

    private void Grounded()
    {
        if (isGrounded.Value)
        {
            animator.SetTrigger(AnimatorHash.Land);
            return;
        }

        animator.SetTrigger(playerRigidbody.velocity.y > 0.1f ? AnimatorHash.Jump : AnimatorHash.Fall);
    }

    private void FacingRight()
    {
        playerSprite.flipX = !isFacingRight.Value;
    }

    private void Move()
    {
        animator.SetBool(AnimatorHash.Move, isMoving.Value);
    }

    #endregion
}
