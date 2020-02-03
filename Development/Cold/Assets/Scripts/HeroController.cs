using UnityEngine;

namespace Cold
{
  using TeamMask = Const.TeamMask;
  public class HeroController : MonoBehaviour
  {
    PawnController pawn;
    HeroState hero;
    Claw claw;
    void Start()
    {
      pawn = transform.GetComponent<PawnController>();
      hero = transform.GetComponent<HeroState>();
      claw = transform.GetComponentInChildren<Claw>();
    }
    void Update()
    {
      if(!pawn.enabled){
        return;
      }
      if(Input.GetMouseButtonDown(0)){
        // claw.Attack(TeamMask.Enemy, hero.AttackDamage);
      }
      Vector3 mov = new Vector3(
        Input.GetAxis(Const.Horizontal), 
        Input.GetAxis(Const.Vertical), 
        0f
      );
      pawn.MoveBy(mov);
      Vector3 mousePos = Input.mousePosition;
      mousePos.z = -Camera.main.transform.position.z;
      pawn.TargetAt(Camera.main.ScreenToWorldPoint(mousePos));
    }
  }
}
