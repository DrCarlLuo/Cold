using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cold
{
  public class TargetFollow : MonoBehaviour
  {
    [SerializeField]
    Transform Hero = null;
    [Range(0.5f, 5f)]
    public float smooth;
    const float cameraDist = -10f;

    void Start(){
      transform.position = TargetPosition();
    }
    void Update()
    {
      transform.position = Vector3.Lerp(
        transform.position,
        TargetPosition(),
        smooth*Time.deltaTime
      );
    }
    Vector3 TargetPosition(){
      var tarPos = Hero.position;
      tarPos.z = cameraDist;
      return tarPos;
    }
  }
}
