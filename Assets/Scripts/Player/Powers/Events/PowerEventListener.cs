using FSLib.FSEvents.Listeners;
using UnityEngine;
using UnityEngine.Events;

namespace Systems.Events
{
    public class PowerEventListener : IFsOneArgumentEventListener<PowerType>
    {
        [SerializeField] private PowerEventSo powerEventSo;
    
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        // ReSharper disable once MemberCanBePrivate.Global
        public UnityEvent<PowerType> listeners = new PowerEvent();
    
        #region Listener Handler

        protected override void AddListeners()
        {
            powerEventSo.fsOneArgumentAction += Invoke;
        }

        protected override void RemoveListeners()
        {
            powerEventSo.fsOneArgumentAction -= Invoke;
        }

        protected override void Invoke(PowerType value)
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