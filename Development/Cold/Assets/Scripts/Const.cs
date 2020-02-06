using System;
namespace Cold
{
  public class Const{
    public const string Horizontal = "Horizontal";
    public const string Vertical = "Vertical";
    public const string Fire = "Fire1";
    public const string Portable = "Portable";
    public const float MaxHealth = 100f;
    [Flags]
    public enum TeamMask
    {
      None = 0,
      Hero = 1<<0,
      Enemy = 1<<1,
      All = ~0,
    }
  }
}