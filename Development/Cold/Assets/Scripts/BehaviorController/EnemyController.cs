using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cold
{
  using TeamMask = Const.TeamMask;
  [RequireComponent(typeof(PawnController))]
  public class EnemyController : MonoBehaviour
  {
    PawnController pawn;
    EnemyState me;
    ClawController claw;
    HeroState hatred;
    float atkTimer;
    void Start()
    {
      pawn = transform.GetComponent<PawnController>();
      me = transform.GetComponent<EnemyState>();
      claw = transform.GetComponentInChildren<ClawController>();
      hatred = GameCore.I.hero;
      atkTimer = 0f;
    }
    void Update(){
      if(!pawn.enabled){
        return;
      }
      if(hatred is null
      || hatred.IsDead){
        return;
      }
      Vector3 vec = hatred.transform.position-transform.position;
      var pawnctls = claw.GetAttackPawnCtl(TeamMask.Hero);
      if(pawnctls.Count>0){ // has targets in attack range
        if(atkTimer<=0f){
          atkTimer = me.AttackCoolDown;
          claw.Attack(pawnctls, me.AttackDamage);
        }
      }
      else{
        pawn.MoveBy(vec.normalized);
      }
      if(atkTimer>0f){
        atkTimer -= Time.deltaTime;
      }
      pawn.TargetAt(hatred.transform.position);
    }
  }
}
