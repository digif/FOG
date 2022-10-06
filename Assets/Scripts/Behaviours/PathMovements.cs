using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Behaviours
{
    public class PathMovements : IBehaviour
    {
        [SerializeField] private Transform[] pathPoints;
        private Vector3[] _waypoints;

        [SerializeField] private float timeToTravel;
        [Tooltip("If tick the timeToTravel property will handle the time to move from a point to another." +
                 "If not the timeToTravel will be the total time to do the whole path.")]
        [SerializeField] private bool useTimePerPoints;

        [Tooltip("-1 for infinite loop.")]
        [SerializeField] private int loopNumber;
        [SerializeField] private LoopType loopType;
        [SerializeField] private Ease ease;
        

        private void Awake()
        {
            _waypoints = pathPoints.Select(pathPoint => pathPoint.position).ToArray();
        }

        protected override void Action()
        {
            //TODO handle the time per point thing
            transform.DOPath(_waypoints, timeToTravel)
                .SetLoops(loopNumber, loopType)
                .SetEase(ease);
        }
        
        private void OnDrawGizmos()
        {
            for (var i = 0; i < pathPoints.Length; i++)
            {
                var point = pathPoints[i];
                
                Gizmos.DrawSphere(point.position, .1f);
                
                if (i >= pathPoints.Length -1) continue;
                
                Gizmos.DrawLine(point.position, pathPoints[i + 1].position);
            }
        }
    }
}
