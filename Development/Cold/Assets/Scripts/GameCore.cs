using UnityEngine;
using System.Collections.Generic;

namespace Cold
{
  public class GameCore : MonoBehaviour
  {
    #region inspector
    [SerializeField] Transform heroTrans = null;
    [SerializeField] Transform woodTrans = null;
    [SerializeField] Transform sceneRoot = null;
    [SerializeField] int initWoodCount;
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
      
      for(int i=0; i<initWoodCount; i++){
        float p = 1f + 3f*Random.Range(0, 1f);
        float t = 360f*Random.Range(0,1f);
        var pos = new Vector3(p*Mathf.Cos(t), p*Mathf.Sin(t), 0);
        Transform wood = Instantiate(woodTrans, pos, Quaternion.identity);
        wood.SetParent(sceneRoot);
      }
    }
  }
}
