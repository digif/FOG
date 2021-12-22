using FSLib.FSEvents.SO;
using UnityEngine;
using UnityEngine.Events;

namespace FSLib.FSEvents.Listeners
{
    /// <summary>
    /// void implementation of <see cref="FsEventListener"/>
    /// </summary>
    /// <inheritdoc cref="FsEventListener"/>
    public class FsVoidEventListener : FsEventListener
    {
        /// <summary>
        /// The FSEventSO to subscribe to of type <see cref="FsVoidEventSo"/>
        /// </summary>
        [Tooltip("The void event to listen")]
        public FsVoidEventSo fsVoidEventSo;

        /// <summary>
        /// Public <see cref="UnityEvent{T0}"/> to be raised when the given <see cref="FsVoidEventSo"/> is raised
        /// </summary>
        [Tooltip("The methods to be called when above event is raised")]
        public UnityEvent listeners = new UnityEvent();
        
        /// <summary>
        /// This function is call if you click on the auto add button in the unity editor
        /// Also called at start if there are no event registered in the <see cref="UnityEvent"/>
        /// Your method name HAVE to be the SAME as the <see cref="fsVoidEventSo"/> name
        /// </summary>

        #region Listener Handler

        protected override void AddListeners()
        {
            fsVoidEventSo.fsVoidEvent += Invoke;
        }

        protected override void RemoveListeners()
        {
            fsVoidEventSo.fsVoidEvent -= Invoke;
        }

        private void Invoke()
        {
            listeners.Invoke();
        }

        #endregion
        
        #region Unity Functions

        protected override void Awake()
        {
            RemoveListeners();
            AddListeners();
        }

        protected override void OnEnable()
        {
            RemoveListeners();
            AddListeners();
        }

        protected override void OnDisable()
        {
            RemoveListeners();
        }

        protected override void OnDestroy()
        {
            RemoveListeners();
        }

        #endregion
        
    }
}