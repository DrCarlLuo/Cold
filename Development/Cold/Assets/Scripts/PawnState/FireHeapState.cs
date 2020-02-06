using UnityEngine;
namespace Cold
{
    public class FireHeapState : PawnState{
        public float HealthLoss = 5f;
        void Update(){
            if(IsDead){
                return;
            }
            Health -= HealthLoss*Time.deltaTime;
        }
    }
}