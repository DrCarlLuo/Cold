using UnityEngine;
namespace Cold
{
    public class WoodState : MonoBehaviour, ICombustible, IPortable{
      public float HeatAmt{get; set;} = 20f;
      public bool IsHold{get; set;} = false;
    }
}