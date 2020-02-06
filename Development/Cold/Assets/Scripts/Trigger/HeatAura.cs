using UnityEngine;
using System.Collections.Generic;
namespace Cold
{
  public class HeatAura : MonoBehaviour{
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