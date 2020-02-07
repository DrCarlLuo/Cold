using System;
using System.Collections.Generic;
using UnityEngine;
namespace Cold
{
  using TeamMask = Const.TeamMask;
  public class ClawController : MonoBehaviour{
    public float hitBackDist = 0.5f;
    public void Attack(List<PawnController> pawnctls, float damage){
      foreach(var pawnctl in pawnctls){
        var pawn = pawnctl.pawn;
        pawn.Health -= damage;
        var hitBackDir = pawn.transform.position - transform.position;
        pawnctl.HitBackBy(hitBackDir.normalized * hitBackDist);
      }
    }
    public List<PawnController> GetAttackPawnCtl(TeamMask team){
      Collider2D[] cols = Physics2D.OverlapCircleAll(
        transform.position, 0.15f, LayerMask.GetMask("Pawn")
      );
      List<PawnController> ret = new List<PawnController>();
      foreach(var col in cols){
        var pawnctl = col.transform.GetComponent<PawnController>();
        if(pawnctl != null){
          var pawn = pawnctl.pawn;
          if( (team&pawn.Team) != TeamMask.None){
            ret.Add(pawnctl);
          }
        }
      }
      return ret;
    }
    public void PickAndDrop(){
      if(transform.childCount==0){
        Collider2D[] ret = Physics2D.OverlapCircleAll(
          transform.position, 0.15f, LayerMask.GetMask("Item")
        );
        foreach(var col in ret){
          var portable = col.transform.GetComponent<IPortable>();
          if(portable != null){
            col.transform.SetParent(transform);
            col.transform.localPosition = Vector3.zero;
            portable.IsHold = true;
            break;
          }
        }
      }
      else {
        var trans = transform.GetChild(0);
        var portable = trans.GetComponent<IPortable>();
        trans.SetParent(GameCore.I.SceneRoot, true);
        portable.IsHold = false;
      }
    }
  }
}