using UnityEngine;
namespace Cold
{
  [RequireComponent(typeof(WoodState))]
  public class WoodController : MonoBehaviour{
    #region inspector
    [SerializeField] AudioClip clipPick;
    [SerializeField] AudioClip clipDrop;
    #endregion
    public WoodState wood{get; private set;} = null;
    void Start()
    {
      wood = transform.GetComponent<WoodState>();
      wood.EventHold += OnHold;
    }
    void OnHold(WoodState wood){
      if(wood.IsHold){
        AudioSource.PlayClipAtPoint(clipPick, transform.position, 0.3f);
      }
      else{
        AudioSource.PlayClipAtPoint(clipDrop, transform.position, 0.2f);
      }
    }
  }
}