using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cold
{
  public class EnemyState : PawnState
  {
    public float HeatDamage = 10f;
    public float SeachRadius = 10f;
    void Start()
    {
      Team = Const.TeamMask.Enemy;
    }
    void Update(){
      if(IsWarm){
        Health -= HeatDamage*Time.deltaTime;
      }
    }
  }
}
