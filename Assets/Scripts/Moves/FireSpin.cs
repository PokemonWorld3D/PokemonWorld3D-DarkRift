using UnityEngine;
using System.Collections;

public class FireSpin : Move
{
	public ParticleSystem fireSpin;

	public FireSpin()
	{
		ResetMoveData("Fire Spin", "The target becomes trapped within a fierce vortex of fire that rages for five seconds.", false, false, false, false, false, PokemonTypes.FIRE,
			MoveCategories.SPECIAL, 0.0f, 35);
	}
	public void StartFireSpin()
	{
		ResetMoveValues();
		
		fireSpin.Play();
	}
	public void FinishFireSpin()
	{
		fireSpin.Stop();
	}
}