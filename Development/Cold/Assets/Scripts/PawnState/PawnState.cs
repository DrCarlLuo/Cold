using UnityEngine;
namespace Cold
{
  public class PawnState : MonoBehaviour{
    public float AttackCoolDown = 1.1f;
    public float AttackDamage = 10f;
    public bool IsDead = false;
    public bool IsWarm = false;
    public Const.TeamMask Team;
    float health = Const.MaxHealth;
    public float Health{get=>health; set{
      if(value<=0){
        IsDead = true;
      }
      health = Mathf.Clamp(value, 0, Const.MaxHealth);
    }}
  }
}