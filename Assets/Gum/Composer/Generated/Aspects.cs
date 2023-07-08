namespace Gum.Composer.Generated
{
	public readonly struct AbilityAspect : IAspect
	{
		public static readonly Gum.Composer.AspectType ASPECT_TYPE = (int)AspectType.Ability;

		public Gum.Composer.AspectType Type => ASPECT_TYPE;

		public readonly SemihCelek.Gmtk2023.AbilityModule.Model.AbilityType Value;

		public AbilityAspect(SemihCelek.Gmtk2023.AbilityModule.Model.AbilityType arg0)
		{		

			 Value = arg0;
		}
	}
	public readonly struct DamageAspect : IAspect
	{
		public static readonly Gum.Composer.AspectType ASPECT_TYPE = (int)AspectType.Damage;

		public Gum.Composer.AspectType Type => ASPECT_TYPE;

		public readonly System.Int32 Value;

		public DamageAspect(System.Int32 arg0)
		{		

			 Value = arg0;
		}
	}
	public readonly struct EnemyAspect : IAspect
	{
		public static readonly Gum.Composer.AspectType ASPECT_TYPE = (int)AspectType.Enemy;

		public Gum.Composer.AspectType Type => ASPECT_TYPE;

		public readonly SemihCelek.Gmtk2023.EnemyModule.Model.EnemyType Value;

		public EnemyAspect(SemihCelek.Gmtk2023.EnemyModule.Model.EnemyType arg0)
		{		

			 Value = arg0;
		}
	}
	public readonly struct GameObjectAspect : IAspect
	{
		public static readonly Gum.Composer.AspectType ASPECT_TYPE = (int)AspectType.GameObject;

		public Gum.Composer.AspectType Type => ASPECT_TYPE;

		public readonly UnityEngine.GameObject Value;

		public GameObjectAspect(UnityEngine.GameObject arg0)
		{		

			 Value = arg0;
		}
	}
	public readonly struct HealthAspect : IAspect
	{
		public static readonly Gum.Composer.AspectType ASPECT_TYPE = (int)AspectType.Health;

		public Gum.Composer.AspectType Type => ASPECT_TYPE;

		public readonly System.Int32 Value;

		public HealthAspect(System.Int32 arg0)
		{		

			 Value = arg0;
		}
	}
	public readonly struct SpeedAspect : IAspect
	{
		public static readonly Gum.Composer.AspectType ASPECT_TYPE = (int)AspectType.Speed;

		public Gum.Composer.AspectType Type => ASPECT_TYPE;

		public readonly System.Int32 Value;

		public SpeedAspect(System.Int32 arg0)
		{		

			 Value = arg0;
		}
	}
}