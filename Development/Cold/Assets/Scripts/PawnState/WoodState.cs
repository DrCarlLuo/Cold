using UnityEngine;
using System;
namespace Cold
{
    public class WoodState : MonoBehaviour, ICombustible, IPortable{
      public event Action<WoodState> EventHold;
      public float HeatAmt{get; set;} = 20f;
      bool isHold = false;
      public bool IsHold{get=>isHold; set{
        if(value==isHold){
          return;
        }
        isHold = value;
        EventHold?.Invoke(this);
      }}
    }
}