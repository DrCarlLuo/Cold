using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cold
{
  public class HeroState : MonoBehaviour
  {
    [SerializeField] float HealthDelta = 10f;
    [SerializeField] float StrengthDelta = 10f;
    [SerializeField] float MaxTimer = 3f;
    public bool IsWarm{get;set;} = false;
    public float health{get; private set;} = Const.MaxHealth;
    public float stren{get; private set;} = Const.MaxHealth;
    public float warmTimer{get; private set;}
    void Start(){
      warmTimer = MaxTimer;
    }
    void Update()
    {
      if(IsWarm){
        warmTimer = MaxTimer;
        stren += StrengthDelta*Time.deltaTime;
      }
      else{
        if(warmTimer > 0){
          warmTimer -= Time.deltaTime;
        }
        else{
          stren -= StrengthDelta*Time.deltaTime;
        }
      }
      if(stren<=0f){
        health -= HealthDelta*Time.deltaTime;
      }
      health = Mathf.Clamp(health, 0, Const.MaxHealth);
      stren = Mathf.Clamp(stren, 0, health);
    }
  }
}
