using UnityEngine;
using System.Collections;

public class Inferno : Move
{
	public ParticleSystem inferno;
	
	public Inferno()
	{
		ResetMoveData("Inferno", "The user attacks by engulfing the target in an intense fire. This leaves the target with a burn.", false, false, false, false, false,
			PokemonTypes.FIRE, MoveCategories.SPECIAL, 0.0f, 100);
	}
	public void StartInferno()
	{
		ResetMoveValues();
		
		inferno.Play();
	}
	public void StopInferno()
	{
		inferno.Stop();
	}
}