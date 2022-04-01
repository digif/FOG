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

    private const float jumpDelay = 0.75f;
    private float lastWallJump = 0f;
    private Transform myTransform;
    private Rigidbody2D myRigidbody;

    private void Awake()
    {
        myTransform = transform;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (myRigidbody.velocity.y >= 0) return;
        if (isGrounded.Value || isAboveGround.Value)
        {
            isAgainstWall.Value = false;
            return;
        }
        if (lastWallJump + jumpDelay > Time.time) return;
        
        const int layer = 1 << 3;
        var position = myTransform.position;
        var hit = Physics2D.Raycast(position, isFacingRight.Value ? Vector2.right : Vector2.left, 0.75f, layer);
        
        if (hit.collider == null || hit.collider.gameObject.layer != 3) //Ground layer
        {
            isAgainstWall.Value = false;
            return; 
        }
        
        myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        isAgainstWall.Value = true;
    }
    
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (lastWallJump + jumpDelay > Time.time) return;
        if (!isAgainstWall.Value) return;
        if (!context.started) return;

        lastWallJump = Time.time;
        //TODO change to add force
        myRigidbody.AddForce(new Vector2((isFacingRight.Value ? -jumpPower.Value : jumpPower.Value) * .5f, jumpPower.Value * 0.2f), ForceMode2D.Impulse);
        isAgainstWall.Value = false;
        OnJump.Raise();
    }
}
