using UnityEngine;

namespace PenguinEffect.Bundle.Prefabs.Penguin {
    public class PenguinAnimationController : MonoBehaviour {
        private static readonly int ParamWalking = Animator.StringToHash("Walking");
        
        [SerializeField] private Animator animator;

        public bool Walking {
            get => animator.GetBool(ParamWalking);
            set => animator.SetBool(ParamWalking, value);
        }
    }
}