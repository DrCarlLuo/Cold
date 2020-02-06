using UnityEngine;
using System.Collections.Generic;
namespace Cold
{
  public class HeatAura : MonoBehaviour{
    FireHeapState fireHeap = null;
    void Start(){
      fireHeap = GetComponentInParent<FireHeapState>();
    }
    void Update(){
      float rate = fireHeap.Health/Const.MaxHealth;
      rate += 0.1f*rate*Mathf.Sin(8f*Time.time);
      transform.localScale = Vector3.one * rate;
      if(fireHeap.Health <= 0){
        gameObject.SetActive(false);
      }
    }
    void OnTriggerStay2D(Collider2D other)
    {
      var pawn = other.transform.GetComponent<PawnState>();
      if(pawn){
        pawn.IsWarm = true;
      }
    }
    void OnTriggerExit2D(Collider2D other)
    {
      var pawn = other.transform.GetComponent<PawnState>();
      if(pawn){
        pawn.IsWarm = false;
      }
    }
  }
}