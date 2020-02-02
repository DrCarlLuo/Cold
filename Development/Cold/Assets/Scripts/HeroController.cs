using UnityEngine;

namespace Cold
{
  public class HeroController : MonoBehaviour
  {
    PawnController pawn;
    HeroState hero;
    bool IsDead = false;
    void Start()
    {
      pawn = transform.GetComponent<PawnController>();
      hero = transform.GetComponent<HeroState>();
    }
    void Update()
    {
      if(IsDead){
        return;
      }
      if(hero.health<=0){
        IsDead = true;
        Debug.Log("Game Over");
      }
      Vector3 mov = new Vector3(
        Input.GetAxis(Const.Horizontal), 
        Input.GetAxis(Const.Vertical), 
        0f
      );
      pawn.MoveBy(mov*Time.deltaTime);
    }
  }

}
