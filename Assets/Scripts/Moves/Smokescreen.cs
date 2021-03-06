using UnityEngine;
using System.Collections;

public class Smokescreen : Move
{
	[SerializeField] private ParticleSystem smokescreen;

	public Smokescreen()
	{
		ResetMoveData("Smokescreen", "The user releases an obscuring cloud of smoke or ink.", false, false, false, false, false, PokemonTypes.NORMAL, MoveCategories.STATUS,
			0.0f, 0);
	}
	public void SmokescreenStart()
	{
        components.pokemon.CannotMove();
        smokescreen.Play();
	}
	public void SmokescreenFinish()
	{
		smokescreen.Stop();
	}
}