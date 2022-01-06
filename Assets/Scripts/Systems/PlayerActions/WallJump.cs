using UnityEngine;
using UnityEngine.InputSystem;

public class WallJump : MonoBehaviour
{
    [SerializeField] private BoolVariable isGrounded = null;
    [SerializeField] private BoolVariable isAgainstWall = null;
    [SerializeField] private FloatVariable jumpPower = null;
    [SerializeField] private BoolVariable isAboveGround = null;
    [SerializeField] private BoolVariable isFacingRight = null;
    [SerializeField] private GameEvent OnJump = null;
    
    private Transform myTransform;
    private Rigidbody2D myRigidbody;

    private void Awake()
    {
        myTransform = transform;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isGrounded.Value || isAboveGround.Value)
        {
            isAgainstWall.Value = false;
            return;
        }
        
        const int layer = 1 << 3;
        var position = myTransform.position;
        var hit = Physics2D.Raycast(position, isFacingRight.Value ? Vector2.right : Vector2.left, 1.5f, layer);
        Debug.DrawRay(position, isFacingRight.Value ? Vector2.right : Vector2.left * 1.5f, Color.yellow);
        if (hit.collider != null && hit.collider.gameObject.layer == 3) // Ground layer
        {
            isAgainstWall.Value = true;
            //TODO limit fall
            //TODO change player movements
            //TODO anim ?
        }
    }
    
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (!isAgainstWall.Value) return;
        if (!context.started) return;

        myRigidbody.velocity = new Vector2(isFacingRight.Value ? -jumpPower.Value : jumpPower.Value, jumpPower.Value);
        isAgainstWall.Value = false;
        OnJump.Raise();
    }
}
