using Behaviours;
using UnityEngine;

namespace Actions
{
    public abstract class IAction : MonoBehaviour
    {
        [SerializeField] protected IBehaviour[] behaviours;
        protected const string Action = "Action";

        protected virtual void Raise()
        {
            foreach (var behaviour in behaviours)
            {
                behaviour.SendMessage(Action);
            }
        }
    }
}
