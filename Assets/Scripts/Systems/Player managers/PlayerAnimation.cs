using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    // variables
    [SerializeField]
    Vector2Variable playerSpeed = null;


    // event
    [SerializeField]
    GameEvent onDeath = null;

    [SerializeField]
    GameEvent onAutumnPower = null;


    // states
    [SerializeField]
    BoolVariable isSliding = null;

    [SerializeField]
    BoolVariable isGrounded = null;

    [SerializeField]
	BoolVariable isFacingRight = null;

    [SerializeField]
    BoolVariable isDead = null;


    // components
    [SerializeField]
    Animator m_Animator = null;
    
    
    // local variables
    bool m_WasGrounded = true;
    
    bool m_WasSliding = false;


    private void Awake() {
        onDeath.Add(OnDeath);
        onAutumnPower.Add(OnAutumnPower);
    }

    private void OnDisable() {
        onDeath.Remove(OnDeath);
        onAutumnPower.Remove(OnAutumnPower);
    }

    void OnAutumnPower ()
    {
        m_Animator.SetTrigger("OnPower");
    }
    
    void OnDeath() 
    {
        m_Animator.SetTrigger("OnDeath");
    }

    void Update()
    {
        m_Animator.SetBool("isDead", isDead.Value);
        if (!isDead.Value)
        {
            // flip orientation of the sprite depending on where Player look
            transform.localScale = new Vector3(
                Mathf.Abs(transform.localScale.x) * (isFacingRight.Value==false? -1 : 1 ),
                transform.localScale.y,
                transform.localScale.z
            );

            // set animations trigger
            m_Animator.SetBool("isSliding", isSliding.Value);
            m_Animator.SetFloat("HorizontalSpeed", Mathf.Abs(playerSpeed.Value.x));
            m_Animator.SetFloat("VerticalSpeed", playerSpeed.Value.y);

            if(m_WasGrounded != isGrounded.Value)
            {
                if (m_WasGrounded)
                {
                    if(playerSpeed.Value.y > 0.1)
                        m_Animator.SetTrigger("OnJump");
                    else
                        m_Animator.SetTrigger("OnFall");
                }
                else
                    m_Animator.SetTrigger("OnLand");
                m_WasGrounded = isGrounded.Value;
            }
            if(m_WasSliding !=isSliding.Value)
            {
                if (!m_WasSliding && isGrounded.Value)
                    m_Animator.SetTrigger("OnStartSlide");
                
                m_WasSliding = isSliding.Value;
            }
        }
    }
}
