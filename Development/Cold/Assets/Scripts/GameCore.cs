using UnityEngine;
using System.Collections.Generic;

namespace Cold
{
  public class GameCore : MonoBehaviour
  {
    #region inspector
    [SerializeField] Transform heroTrans;
    #endregion
    public static GameCore I{get; private set;}
    [HideInInspector] public HeroState hero = null;
    void Awake(){
      if(I is null){
        I = this;
      }
    }
    void Start(){
      hero = heroTrans.GetComponent<HeroState>();
    }
  }
}
