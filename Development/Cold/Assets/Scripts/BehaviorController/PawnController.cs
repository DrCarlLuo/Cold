using UnityEngine;

namespace Cold
{
  public class PawnController : MonoBehaviour{
    [Range(0f, 10f)]
    public float speed;
    public bool movable{get; set;} = true;
    public float angle{get; set;} = 0f;
    void Start()
    {
      // Simple Billborad
      // transform.rotation = Camera.main.transform.rotation;
    }
    public void MoveBy(Vector3 movement){
      if(movable){
        transform.localPosition += movement*speed*Time.deltaTime;
      }
    }
    public void TargetAt(Vector3 target){
      Vector3 dirVect = target-transform.position;
      dirVect.z = 0;
      float angle = Vector3.Angle(Vector3.right, dirVect);
      if(target.y < transform.position.y){
        angle = -angle;
      }
      transform.rotation = Quaternion.Euler(0,0,angle);
    }
    void Update(){
      var pos = transform.position;
      pos.z = pos.y;
      transform.position = pos;
    }
  }
}