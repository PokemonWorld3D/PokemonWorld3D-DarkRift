using DarkRift;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Growl : Move
{
	public ParticleSystem growl;
	public Debuff attackDown = new Debuff
	{
		type = Debuff.Types.AtkDown,
		percentage = 0.10f,
		duration = 10.0f
	};

    public override void Awake()
    {
        base.Awake();

        soundEffect = Resources.Load("Audio/Pokemon Cries/" + components.pokemon.pokemonName) as AudioClip;
    }
	public Growl()
	{
		ResetMoveData("Growl", "The user growls in an endearing way, making opposing Pokémon less wary. This lowers their Attack stats.", false, false, false, false, false,
			PokemonTypes.NORMAL, MoveCategories.STATUS, 0.0f, 0);
	}
	public void GrowlStart()
	{
        components.pokemon.CannotMove();
        growl.Play();
		components.audioS.PlayOneShot(soundEffect);

        if(!GameManager.instance.isServer)
			return;
		
		Collider[] cols = Physics.OverlapSphere(gameObject.transform.position, range);
		
		for(int i = 0; i < cols.Length; i++)
		{
			if(cols[i].gameObject == components.pokemon.enemy)
			{
				PokemonComponents targetComponents = cols[i].GetComponent<PokemonComponents>();

				if(!targetComponents.buffsDebuffs.Debuffs.Contains(attackDown))
				{
					targetComponents.buffsDebuffs.Debuffs.Add(attackDown);
					targetComponents.stats.AdjCurAtk(-(int)((float)targetComponents.stats.curATK * attackDown.percentage));

                    Networking.StatModMessage(targetComponents.pokemon, this, StatType.ATTACK, false);
				}
			}
		}
	}
}