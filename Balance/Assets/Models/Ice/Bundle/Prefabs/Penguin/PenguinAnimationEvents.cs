using UnityEngine;
using UnityEngine.Events;

namespace PenguinEffect.Bundle.Prefabs.Penguin {
    
    public class PenguinAnimationEvents : MonoBehaviour {
        [SerializeField] private UnityEvent onFootStep;

        public UnityEvent OnFootStep => onFootStep;
        
        private void OnStep() {
            OnFootStep.Invoke();
        }
    }
    
}