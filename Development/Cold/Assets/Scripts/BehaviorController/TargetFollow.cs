using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cold
{
  public class TargetFollow : MonoBehaviour
  {
    HeroState hero => GameCore.I.hero;
    [Range(0.5f, 5f)]
    public float smooth;
    const float cameraDist = -10f;

    void Start(){
      transform.position = TargetPosition();
    }
    void Update()
    {
      if(hero is null){
        return;
      }
      transform.position = Vector3.Lerp(
        transform.position,
        TargetPosition(),
        smooth*Time.deltaTime
      );
    }
    Vector3 TargetPosition(){
      var tarPos = hero.transform.position;
      tarPos.z = cameraDist;
      return tarPos;
    }
  }
}
