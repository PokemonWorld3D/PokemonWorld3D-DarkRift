using DarkRift;
using UnityEngine;
using System.Collections;

public class SFXFireSpin : MonoBehaviour
{
	private FireSpin move;
	private ParticleSystem fireSpin;
	private float lastTime;
	
	void Awake()
	{
		move = transform.root.GetComponent<FireSpin>();
		fireSpin = GetComponent<ParticleSystem>();
	}
	void OnParticleCollision(GameObject target)
	{
		if(!GameManager.instance.isServer)
			return;

		PokemonComponents components = target.GetComponent<PokemonComponents>();

		if(!components.conditions.partiallyTrapped)
		{
			components.conditions.partiallyTrapped = true;
			components.conditions.PartiallyTrapped("Fire Spin");
		}
	}
	void Update()
	{
		if(move.components.pokemon.Trainer.networkID != DarkRiftAPI.id)
			return;

		if(fireSpin.isPlaying && Time.time - lastTime >= 1.0f)
		{
			move.components.pokemon.DeductPP();
			lastTime = Time.time;
		}
	}
}
