using System.Collections.Generic;
using FSLib.FSEvents.SO;
using UnityEngine;
using UnityEngine.InputSystem;

public class Power : MonoBehaviour
{
    // events
    [SerializeField] private FsVoidEventSo onAutumnPower = null;

    // states
    [SerializeField]
    BoolVariable isPaused =null;

    // components
    [SerializeField]
    Collider2D m_collider = null;

    public void OnPowerInput (InputAction.CallbackContext context)
    {
        if(context.started && !isPaused.Value)
        {
            List<Collider2D> contacts = new List<Collider2D>();
            ContactFilter2D filter = new ContactFilter2D ();
            filter.useTriggers = true;
            filter.SetLayerMask(LayerMask.GetMask("AutumnTrigger"));
            m_collider.OverlapCollider(filter, contacts);
            
            foreach (var contact in contacts)
            {
                contact.SendMessage("OnPower");
            }
            if (contacts.Count > 0)
            {
                onAutumnPower.Invoke();
            }
        }
    }

}
