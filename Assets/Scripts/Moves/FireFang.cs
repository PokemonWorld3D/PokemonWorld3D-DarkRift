using UnityEngine;
using System.Collections;

public class FireFang : Move
{
	public ParticleSystem[] FireFangs;
	public Collider col;

	public FireFang()
	{
		ResetMoveData("Fire Fang", "The user bites with flame-cloaked fangs. This will also make the target flinch and may leave it with a burn.", false, false, true, true, false,
			PokemonTypes.FIRE, MoveCategories.PHYSICAL, 0.0f, 65);
	}
	public void StartFireFang()
	{
        components.pokemon.CannotMove();
        ResetMoveValues();

		foreach(ParticleSystem p in FireFangs)
			p.Play();
	}
	public void FireFangDamage()
	{
        if(!GameManager.instance.isServer)
            return;

		Collider[] cols = Physics.OverlapSphere(col.transform.position, range);
		
		for(int i = 0; i < cols.Length; i++)
		{
			if(cols[i].gameObject == components.pokemon.enemy)
			{
				PokemonComponents targetComponents = cols[i].GetComponent<PokemonComponents>();

				if(Random.Range(0.00f, 1.00f) > 0.90f)		//10% CHANCE
				{
					targetComponents.conditions.Flinch(true);

                    Networking.FlinchMessage(targetComponents.pokemon, this);
				}
				if(Random.Range(0.00f, 1.00f) > 0.90f)		//10% CHANCE
				{
					targetComponents.conditions.Burn(true);

					Networking.BurnMessage(targetComponents.pokemon, this);
				}

				Calculations.DealDamage(components.pokemon, targetComponents.pokemon, this);
			}
		}
	}
	public void EndFireFang()
	{
		foreach(ParticleSystem p in FireFangs)
			p.Stop();
	}
}