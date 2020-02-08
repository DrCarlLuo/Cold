using UnityEngine;
namespace Cold
{
    public class FireHeapState : MonoBehaviour{
        public float HealthLoss = 5f;
        public float Health{get; set;}
        void Update(){
            Health -= HealthLoss*Time.deltaTime;
            if(Health<0f) Health = 0f;
        }
    }
}