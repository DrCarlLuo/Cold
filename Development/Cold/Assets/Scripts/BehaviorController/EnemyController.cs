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
      if(atkTimer>0f){
        atkTimer -= Time.deltaTime;
      }
      Vector3 vec = hatred.transform.position-transform.position;
      if(vec.sqrMagnitude < me.SeachRadius*me.SeachRadius){ // search target in circle
        pawn.MoveBy(vec.normalized);
        pawn.TargetAt(hatred.transform.position);
        if(atkTimer<=0f){ // has targets in attack range
          atkTimer = me.AttackCoolDown;
          claw.Attack(TeamMask.Hero, me.AttackDamage);
        }
      }
    }
  }
}
