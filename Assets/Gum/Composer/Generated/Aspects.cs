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