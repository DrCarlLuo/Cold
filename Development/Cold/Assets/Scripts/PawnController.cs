using UnityEngine;

namespace Cold
{
  public class PawnController : MonoBehaviour{
    [Range(1f, 10f)]
    public float speed;
    public bool movable{get; set;} = true;
    void Start()
    {
      // Simple Billborad
      transform.rotation = Camera.main.transform.rotation;
    }
    public void MoveBy(Vector3 movement){
      if(movable){
        transform.localPosition += movement;
      }
    }
    void Update(){
      var pos = transform.position;
      pos.z = pos.y;
      transform.position = pos;
    }
  }
}