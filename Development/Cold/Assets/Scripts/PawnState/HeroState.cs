using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cold
{
  public class HeroState : PawnState
  {
    public float ColdDamage = 10f;
    public float StrengthDelta = 10f;
    public float MaxWarmTimer = 3f;
    public float Stren;
    float warmTimer;
    void Start(){
      warmTimer = MaxWarmTimer;
      Stren = Health;
      Team = Const.TeamMask.Hero;
    }
    void Update()
    {
      if(IsWarm){
        warmTimer = MaxWarmTimer;
        Stren += StrengthDelta*Time.deltaTime;
      }
      else{
        if(warmTimer > 0){
          warmTimer -= Time.deltaTime;
        }
        else{
          Stren -= StrengthDelta*Time.deltaTime;
        }
      }
      if(Stren<=0f){
        Health -= ColdDamage*Time.deltaTime;
      }
      Stren = Mathf.Clamp(Stren, 0, Health);
    }
  }
}
