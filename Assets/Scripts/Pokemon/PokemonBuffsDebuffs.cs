using DarkRift;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PokemonBuffsDebuffs : MonoBehaviour
{
	public List<Buff> Buffs { get; private set; }
	public List<Debuff> Debuffs { get; private set; }

	private PokemonComponents components;

	void Awake()
	{
		components = GetComponent<PokemonComponents>();
        Buffs = new List<Buff>();
		Debuffs = new List<Debuff>();
	}
	void Start()
	{
		InvokeRepeating("BuffTicker", 0.0f, 1.0f);
		InvokeRepeating("DebuffTicker", 0.0f, 1.0f);
	}

    public void AddBuff(Buff buff)
    {
        if(!Buffs.Contains(buff))
		{
			Buffs.Add(buff);

            if(components.pokemon.networkID == DarkRiftAPI.id)
                components.pokemon.hud.playerPokemonPortrait.SpawnBuffIcon(buff);
        }
    }
    public void AddDebuff(Debuff debuff)
    {
        if(!Debuffs.Contains(debuff))
		{
			Debuffs.Add(debuff);

            if(debuff.type == Debuff.Types.SpdDown)
			   components.stats.AdjSpeed(debuff.percentage);

            if(components.pokemon.networkID == DarkRiftAPI.id)
			    components.pokemon.hud.playerPokemonPortrait.SpawnDebuffIcon(debuff);
		}
    }

	private void BuffTicker()
	{
        if(Buffs.Count == 0)
            return;

		for(int i = 0; i < Buffs.Count; i++)
		{
			Buff modded = new Buff
			{
				type = Buffs[i].type,
				percentage = Buffs[i].percentage,
				duration = Buffs[i].duration - 1.0f
			};

			if(modded.duration <= 0.0f)
			{
				Buffs.RemoveAt(i);
			}
			else
				Buffs[i] = modded;
		}
	}
	private void DebuffTicker()
	{
        if(Debuffs.Count == 0)
            return;

		for(int i = 0; i < Debuffs.Count; i++)
		{
			Debuff modded = new Debuff
			{
				type = Debuffs[i].type,
				percentage = Debuffs[i].percentage,
				duration = Debuffs[i].duration - 1.0f
			};

			if(modded.duration <= 0.0f)
				RemoveDebuff(i);
			else
				Debuffs[i] = modded;
		}
	}
	private void RemoveDebuff(int index)
	{
		if(Debuffs[index].type == Debuff.Types.AtkDown)
			components.stats.AdjCurAtk((int)((float)components.stats.curMaxATK * Debuffs[index].percentage));

		if(Debuffs[index].type == Debuff.Types.DefDown)
			components.stats.AdjCurDef((int)((float)components.stats.curMaxDEF * Debuffs[index].percentage));

		if(Debuffs[index].type == Debuff.Types.SpdDown)
			components.stats.AdjSpeed((1.0f + Debuffs[index].percentage));

		Debuffs.RemoveAt(index);
	}
}
public struct Buff
{
	public enum Types { AtkUp = 0, DefUp = 1, SpATKUp = 2, SpDEFUp = 3, SpdUp = 4 }
	public Types type;
	public float percentage, duration;
}
public struct Debuff
{
	public enum Types { AtkDown = 0, DefDown = 1, SpATKDown = 2, SpDEFDown = 3, SpdDown = 4 }
	public Types type;
	public float percentage, duration;
}
