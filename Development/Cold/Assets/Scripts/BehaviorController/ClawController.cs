using System;
using UnityEngine;
namespace Cold
{
  using TeamMask = Const.TeamMask;
  public class ClawController : MonoBehaviour{
    public bool IsBusy{get; private set;} = false;
    public void Attack(TeamMask team, float damage){
      Collider2D[] ret = Physics2D.OverlapCircleAll(
        transform.position, 0.15f, LayerMask.GetMask("Pawn")
      );
      Debug.Log(transform.parent.name + " Attack");
      foreach(var col in ret){
        var pawn = col.transform.GetComponent<PawnState>();
        if( (team&pawn.Team) != TeamMask.None){
          pawn.Health -= damage;
        }
      }
    }
    public void PickAndDrop(){
      if(!IsBusy){
        Collider2D[] ret = Physics2D.OverlapCircleAll(
          transform.position, 0.15f, LayerMask.GetMask("Pawn")
        );
        foreach(var col in ret){
          var portable = col.transform.GetComponent<IPortable>();
          if(portable != null){
            IsBusy = true;
            col.transform.SetParent(transform);
            col.transform.localPosition = Vector3.zero;
            portable.IsHold = true;
            break;
          }
        }
      }
      else if(transform.childCount>0){
        var trans = transform.GetChild(0);
        var portable = trans.GetComponent<IPortable>();
        trans.SetParent(GameCore.I.SceneRoot, true);
        portable.IsHold = false;
        if(transform.childCount <= 0){
          IsBusy = false;
        }
      }
    }
  }
}