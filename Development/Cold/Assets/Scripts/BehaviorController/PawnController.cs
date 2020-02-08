using UnityEngine;
using System.Collections;
namespace Cold
{
  [RequireComponent(typeof(Rigidbody2D))]
  public class PawnController : MonoBehaviour{
    #region inspector
    [Range(0f, 10f)]
    public float speed;
    [SerializeField] Sprite spBodyFront = null;
    [SerializeField] Sprite spBodyBack = null;
    [SerializeField] Sprite spHeadFront = null;
    [SerializeField] Sprite spHeadBack = null;
    #endregion
    
    SpriteRenderer renderBody;
    SpriteRenderer renderHead;
    Transform transArrow;
    public bool movable{get; set;} = true;
    public float angle{get; set;} = 0f;
    public Rigidbody2D rb{get; private set;}
    public PawnState pawn{get; private set;}
    void Start()
    {
      // Simple Billborad
      rb = GetComponent<Rigidbody2D>();
      pawn = GetComponent<PawnState>();
      renderBody = transform.Find("Body")?.GetComponent<SpriteRenderer>();
      renderHead = transform.Find("Head")?.GetComponent<SpriteRenderer>();
      transArrow = transform.Find("Arrow");
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
      if(renderBody){
        renderBody.sprite = dirVect.y>0? spBodyBack : spBodyFront;
      }
      if(renderHead){
        renderHead.sprite = dirVect.y>0? spHeadBack : spHeadFront;
        renderHead.sortingOrder = dirVect.y>0? -1 : 1;
      }
      float angle = Vector3.Angle(Vector3.right, dirVect);
      if(target.y < transform.position.y){
        angle = -angle;
      }
      transArrow.rotation = Quaternion.Euler(0,0,angle);
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