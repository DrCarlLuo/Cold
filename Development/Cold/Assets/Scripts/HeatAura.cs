using UnityEngine;
using System.Collections.Generic;
namespace Cold
{
  public class HeatAura : MonoBehaviour{
    void OnTriggerStay2D(Collider2D other)
    {
      var hero = other.transform.GetComponent<HeroState>();
      if(hero){
        hero.IsWarm = true;
      }
    }
    void OnTriggerExit2D(Collider2D other)
    {
      var hero = other.transform.GetComponent<HeroState>();
      if(hero){
        hero.IsWarm = false;
      }
    }
  }
}