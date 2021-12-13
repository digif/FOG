using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutumnTrigger : MonoBehaviour
{
    [SerializeField]
    List<Animator> targets = new List<Animator>();

    public void OnPower()
    {
        foreach (var target in targets)
        {
            target.SetTrigger("OnAutumn");
        }
    }
}
