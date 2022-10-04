using UnityEngine;

public class SlopeHandler : MonoBehaviour
{
    #region Fields
    
    [SerializeField] private Vector2Variable moveDirection = null;
    [SerializeField] private BoolVariable isAboveGround = null;
    
    private Transform myTransform;

    #endregion

    #region Unity Event Methods

    private void Awake()
    {
        myTransform = transform;
    }

    private void FixedUpdate()
    {
        const int layer = 1 << 3;
        var hit = Physics2D.Raycast(myTransform.position, Vector2.down, 1.5f, layer);
        
        if (hit.collider != null)
        {
            //TODO limit max slope
            isAboveGround.Value = true;
            moveDirection.Value = Vector2.Perpendicular(hit.normal).normalized;
        }
        else
        {
            isAboveGround.Value = false;
            moveDirection.Value = Vector2.left;
        }
    }

    #endregion
}
