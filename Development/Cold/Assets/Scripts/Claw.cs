using UnityEngine;
namespace Cold
{
  using TeamMask = Const.TeamMask;
  public class Claw : MonoBehaviour{
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
  }
}