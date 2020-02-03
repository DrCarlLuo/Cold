using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cold
{
  using TeamMask = Const.TeamMask;
  public class EnemyController : MonoBehaviour
  {
    PawnController pawn;
    EnemyState me;
    Claw claw;
    HeroState hatred;
    float atkTimer;
    void Start()
    {
      pawn = transform.GetComponent<PawnController>();
      me = transform.GetComponent<EnemyState>();
      claw = transform.GetComponentInChildren<Claw>();
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
      if(atkTimer<=0f){
        if(vec.sqrMagnitude < 5f){
          atkTimer = me.AttackCoolDown;
          claw.Attack(TeamMask.Hero, me.AttackDamage);
        }
      }
      else{
        atkTimer -= Time.deltaTime;
      }
      pawn.MoveBy(vec.normalized);
      pawn.TargetAt(hatred.transform.position);
    }
  }
}
