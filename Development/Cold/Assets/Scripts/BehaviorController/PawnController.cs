using UnityEngine;
using System.Collections;
namespace Cold
{
  [RequireComponent(typeof(Rigidbody2D))]
  [RequireComponent(typeof(PawnState))]
  public class PawnController : MonoBehaviour{
    [Range(0f, 10f)]
    public float speed;
    public bool movable{get; set;} = true;
    public float angle{get; set;} = 0f;
    public Rigidbody2D body{get; private set;}
    public PawnState pawn{get; private set;}
    void Start()
    {
      // Simple Billborad
      body = GetComponent<Rigidbody2D>();
      pawn = GetComponent<PawnState>();
    }
    public void MoveBy(Vector3 movement){
      if(movable){
        // body.MovePosition(movement*speed*Time.deltaTime);
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
    public void HitBackBy(Vector3 vec){
      // body.MovePosition(vec);
      StartCoroutine(HitBackCoroutine(vec));
    }
    IEnumerator HitBackCoroutine(Vector3 vec){
      while(vec != Vector3.zero){
        Vector3 next = Vector3.Lerp(vec, Vector3.zero, 0.3f);
        transform.localPosition += vec-next;
        vec = next;
        yield return null;
      }
    }
    void Update(){
      var pos = transform.position;
      pos.z = pos.y;
      transform.position = pos;
    }
  }
}