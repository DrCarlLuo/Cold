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
      hero = GameCore.I.hero;
      imgHealth = Health.GetComponent<Image>();
      imgStrength = Strength.GetComponent<Image>();
    }
    void Update()
    {
      dbgHealth = hero.Health;
      dbgStrength = hero.Stren;
      imgHealth.fillAmount = hero.Health/Const.MaxHealth;
      imgStrength.fillAmount = hero.Stren/Const.MaxHealth;
    }

  }
}
