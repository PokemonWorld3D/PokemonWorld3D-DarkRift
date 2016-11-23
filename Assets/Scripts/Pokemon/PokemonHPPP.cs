using UnityEngine;
using System.Collections;

public class PokemonHPPP : MonoBehaviour
{
	public int curHP, curPP, curMaxHP, curMaxPP, maxHP, maxPP, hpEV, ppEV, hpIV, ppIV;

	public GameObject damagePrefab;

	private float regenRate = 3.0f;
	private int ppRegen;
	private PokemonComponents components;
	
	void Awake()
	{
		components = GetComponent<PokemonComponents>();
	}
	void Start()
	{
		InvokeRepeating("Regen", 0.0f, regenRate);
	}
	
	private void SyncCurHP(int curHP)
	{
		int difference = curHP - this.curHP;

		Vector3 here = new Vector3(transform.position.x, components.collider.height + 1.0f, transform.position.z);
		GameObject floatDmg = Instantiate(damagePrefab, here, Quaternion.identity) as GameObject;

		if(difference < 0)
			floatDmg.GetComponent<FloatingDamage>().AssignValues(Color.red, difference.ToString(), false);
		if(difference > 0 && this.curHP > 0)
			floatDmg.GetComponent<FloatingDamage>().AssignValues(Color.green, difference.ToString(), false);

		Destroy(floatDmg, 1.0f);

		this.curHP = curHP;
	}
	
	public void SetupFirstTime()
	{
		hpIV = Random.Range(0, 32);
		ppIV = Random.Range(0, 32);
		maxHP = Calculations.CalculateHP(components.pokemon.baseHP, components.pokemon.level, hpIV, hpEV);
		maxPP = Calculations.CalculateHP(components.pokemon.basePP, components.pokemon.level, ppIV, ppEV);
		curMaxHP = maxHP;
		curMaxPP = maxPP;
		curHP = curMaxHP;
		curPP = curMaxPP;
		ppRegen = (int)(curMaxPP * 0.1f);

		if(ppRegen < 1)
			ppRegen = 1;
	}
	public void SetupExisting()
	{
		maxHP = Calculations.CalculateHP(components.pokemon.baseHP, components.pokemon.level, hpIV, hpEV);
		maxPP = Calculations.CalculateHP(components.pokemon.basePP, components.pokemon.level, ppIV, ppEV);
		ppRegen = (int)(curMaxPP * 0.1f);

		if(ppRegen < 1)
			ppRegen = 1;
	}
	public void LevelUp()
	{
		maxHP = Calculations.CalculateHP(components.pokemon.baseHP, components.pokemon.level, hpIV, hpEV);
		maxPP = Calculations.CalculateHP(components.pokemon.basePP, components.pokemon.level, ppIV, ppEV);
		curMaxHP = maxHP;
		curMaxPP = maxPP;
		curHP = curMaxHP;
		curPP = curMaxPP;
		ppRegen = (int)(curMaxPP * 0.1f);
		
		if(ppRegen < 1)
			ppRegen = 1;
	}

	private void Regen()
	{
		if(!components.pokemon.attacking)
			AdjCurPP(ppRegen);
	}

	public void AdjCurHP(int _adj, bool _critical)
	{
		if(components.conditions.protecting && _adj < 0)
			return;
		
		if(_adj >= -curHP && components.conditions.bracing)
		{
			_adj = (-curHP + 1);
			components.conditions.bracing = false;
		}

//		Vector3 here = new Vector3(transform.position.x, col.height, transform.position.z);
//		GameObject floatDmg = Instantiate(damagePrefab, here, Quaternion.identity) as GameObject;
//
//		if(_adj < 0)
//		{
//			floatDmg.GetComponent<Floating_Damage>().AssignValues(Color.red, _adj.ToString(), _critical);
////			if(sleeping)
////			{
////				RemoveBuffDebuff(BuffsAndDebuffs.SLEEPING, 0.0f, 0.0f, null);
////			}
//		}
//		if(_adj > 0)
//			floatDmg.GetComponent<Floating_Damage>().AssignValues(Color.green, _adj.ToString(), _critical);
//
//		Destroy(floatDmg, 1.0f);
//
//		NetworkServer.Spawn(floatDmg);

		curHP += _adj;
		
		if(curHP < 0)
			curHP = 0;
		
		if(curHP > curMaxHP)
			curHP = curMaxHP;
		
		if(curHP == 0)
			StartCoroutine(components.pokemon.Faint());
	}
	public void AdjCurPP(int _adj)
	{
		curPP += _adj;
		
		if(curPP < 0)
			curPP = 0;
		
		if(curPP > curMaxPP)
			curPP = curMaxPP;
	}
}