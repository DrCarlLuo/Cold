using UnityEngine;
namespace Cold
{
    public class FireHeapState : PawnState{
        #region inspector
        [SerializeField] Transform aura;
        #endregion
        public float HealthLoss = 5f;
        void Update(){
            if(IsDead){
                return;
            }
            Health -= HealthLoss*Time.deltaTime;
            float rate = Health/Const.MaxHealth;
            aura.localScale = Vector3.one * rate;
            if(Health <= 0){
                aura.GetComponent<HeatAura>().gameObject.SetActive(false);
            }
        }
    }
}