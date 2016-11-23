using DarkRift;
using UnityEngine;
using System.Collections;

public class SFXEmber : MonoBehaviour
{
	private Ember move;
	private ParticleSystem ember;
	private float lastTime;
	
	void Awake()
	{
		move = transform.root.GetComponent<Ember>();
		ember = GetComponent<ParticleSystem>();
	}
	void OnParticleCollision(GameObject target)
	{
		if(!GameManager.instance.isServer || target != move.components.pokemon.enemy)
			return;

		PokemonComponents components = target.GetComponent<PokemonComponents>();

		Calculations.DealDamage(move.components.pokemon, components.pokemon, move);

		if(Random.Range(0.00f, 1.00f) > 0.90f)	//10% chance
		{
            if(components.pokemon.networkID == DarkRiftAPI.id)
			    components.pokemon.hud.playerPokemonPortrait.ModifyStatusCondition(PlayerPokemonPortrait.statusCondition.Burn, true);

            components.conditions.burned = true;

            Networking.BurnMessage(components.pokemon, move);
		}
	}
	void Update()
	{
		if(move.components.pokemon.networkID != DarkRiftAPI.id)
			return;
		
		if(ember.isPlaying)
		{
			if(Time.time - lastTime >= 1.0f)
			{
				move.components.pokemon.DeductPP();
				lastTime = Time.time;
			}
		}
	}
}