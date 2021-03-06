﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Cold
{
  public class HealthBar : MonoBehaviour
  {
    #region inspector
    [SerializeField] Transform Health = null;
    [SerializeField] Transform Strength = null;
    #endregion
    HeroState hero => GameCore.I.hero;
    Image imgHealth;
    Image imgStrength;
    public float dbgHealth;
    public float dbgStrength;
    void Start(){
      imgHealth = Health.GetComponent<Image>();
      imgStrength = Strength.GetComponent<Image>();
    }
    void Update()
    {
      if(hero is null){
        return;
      }
      dbgHealth = hero.Health;
      dbgStrength = hero.Stren;
      imgHealth.fillAmount = hero.Health/Const.MaxHealth;
      imgStrength.fillAmount = hero.Stren/Const.MaxHealth;
    }

  }
}
