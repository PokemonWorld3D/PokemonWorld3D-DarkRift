using DarkRift;
using UnityEngine;
using System.Collections;

public class SFXFlamethrower : MonoBehaviour
{
	private Flamethrower move;
	private ParticleSystem flamethrower;
	private float lastTime;

	void Awake()
	{
		move = transform.root.GetComponent<Flamethrower>();
		flamethrower = GetComponent<ParticleSystem>();
	}
	void OnParticleCollision(GameObject target)
	{
		if(!GameManager.instance.isServer)
			return;

		PokemonComponents components = target.GetComponent<PokemonComponents>();

		Calculations.DealDamage(move.components.pokemon, components.pokemon, move);

		if(Random.Range(0.00f, 1.00f) > 0.90f)	//10% chance
		{
			components.conditions.burned = true;

            Networking.BurnMessage(components.pokemon, move);
		}
	}
	void Update()
	{
		if(move.components.pokemon.networkID != DarkRiftAPI.id)
			return;
		
		if(flamethrower.isPlaying)
		{
			if(Time.time - lastTime >= 1.0f)
			{
				move.components.pokemon.DeductPP();
				lastTime = Time.time;
			}
		}
	}
}
