using UnityEngine;
namespace Cold
{
    public class FireHeapHealer : MonoBehaviour{
        FireHeapState fireHeap;
        void Start(){
            fireHeap = transform.GetComponentInParent<FireHeapState>();
        }
        void OnTriggerEnter2D(Collider2D other){
            var bust = other.transform.GetComponent<ICombustible>();
            if(bust != null){
                Destroy(other.gameObject);
                fireHeap.Health += bust.HeatAmt;
            }
        }
    }
}