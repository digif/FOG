using UnityEngine;

public class Freezable : MonoBehaviour
{
    [SerializeField] private Behaviour[] scriptsToFreeze;
    
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.layer != 6) return; //Freeze layer

        foreach (var behaviour in scriptsToFreeze)
        {
            behaviour.enabled = false;
        }
    }
}
