using UnityEngine;
using System.Collections.Generic;

namespace Cold
{
  public class GameCore : MonoBehaviour
  {
    #region inspector
    [SerializeField] Transform heroTrans = null;
    [SerializeField] Transform sceneRoot = null;
    #endregion
    public static GameCore I{get; private set;}
    [HideInInspector] public HeroState hero = null;
    [HideInInspector] public Transform SceneRoot => sceneRoot;
    void Awake(){
      if(I is null){
        I = this;
      }
      hero = heroTrans.GetComponent<HeroState>();
    }
    void Start(){
      
    }
  }
}
