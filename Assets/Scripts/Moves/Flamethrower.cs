using UnityEngine;
using System.Collections;

public class Flamethrower : Move
{
	public ParticleSystem flamethrower;

	public Flamethrower()
	{
		ResetMoveData("Flamethrower", "The target is scorched with an intense blast of fire. This may also leave the target with a burn.", false, false, false, false, false,
			PokemonTypes.FIRE, MoveCategories.SPECIAL, 0.0f, 90);
	}
	public void StartFlamethrower()
	{
        components.pokemon.CannotMove();
        ResetMoveValues();

		flamethrower.Play();
	}
	public void FinishFlamethrower()
	{
		flamethrower.Stop();
	}
}