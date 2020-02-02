using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Cold
{
  public class HealthBar : MonoBehaviour
  {
    #region inspector
    [SerializeField] Transform Hero;
    [SerializeField] Transform Health;
    [SerializeField] Transform Strength;
    #endregion
    HeroState hero;
    Image imgHealth;
    Image imgStrength;
    public float dbgHealth;
    public float dbgStrength;
    void Start(){
      hero = Hero.GetComponent<HeroState>();
      imgHealth = Health.GetComponent<Image>();
      imgStrength = Strength.GetComponent<Image>();
    }
    void Update()
    {
      dbgHealth = hero.health;
      dbgStrength = hero.stren;
      imgHealth.fillAmount = hero.health/Const.MaxHealth;
      imgStrength.fillAmount = hero.stren/Const.MaxHealth;
    }

  }
}
