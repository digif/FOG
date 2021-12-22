using FSLib.FSEvents.SO;
using UnityEngine;
using UnityEngine.Events;

namespace FSLib.FSEvents.Listeners
{
    /// <summary>
    /// <see cref="bool"/> implementation of <see cref="IFsOneArgumentEventListener{T}"/>
    /// </summary>
    /// <inheritdoc cref="IFsOneArgumentEventListener{T}"/>
    /// <inheritdoc cref="FsEventListener"/>
    public class FsBoolEventListener : IFsOneArgumentEventListener<bool>
    {
        /// <summary>
        /// The FSEventSO to subscribe to of type <see cref="FsBoolEventSo"/>
        /// </summary>
        [Tooltip("The bool event to listen")]
        [SerializeField] private FsBoolEventSo fsBoolEventSo;

        /// <summary>
        /// Public <see cref="UnityEvent{T0}"/> to be raised when the given <see cref="FsBoolEventSo"/> is raised
        /// </summary>
        [Tooltip("The methods to be called when above event is raised")]
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        // ReSharper disable once MemberCanBePrivate.Global
        public UnityEvent<bool> listeners = new FsBoolEvent();
        
        #region Listener Handler

        protected override void AddListeners()
        {
            fsBoolEventSo.fsOneArgumentAction += Invoke;
        }

        protected override void RemoveListeners()
        {
            fsBoolEventSo.fsOneArgumentAction -= Invoke;
        }

        protected override void Invoke(bool value)
        {
            listeners.Invoke(value);
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