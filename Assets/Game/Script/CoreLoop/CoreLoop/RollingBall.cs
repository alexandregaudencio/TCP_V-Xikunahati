using Game.Ball;
using UnityEngine;

namespace Game.CoreLoop
{
    public class RollingBall : MonoBehaviour
    {
        [SerializeField] private BallController ballController;
        private CoreLoopController coreLoopController;
        private void Awake()
        {
            coreLoopController = GetComponentInParent<CoreLoopController>();
        }




    }

}
