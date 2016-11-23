using UnityEngine;
using System.Collections;

public class PokemonStats : MonoBehaviour
{
    public int curATK, curDEF, curSPATK, curSPDEF, curSPD, curMaxATK, curMaxDEF, curMaxSPATK, curMaxSPDEF, curMaxSPD, maxATK, maxDEF, maxSPATK, maxSPDEF, maxSPD, atkIV, defIV, spatkIV, spdefIV, spdIV,
        atkEV, defEV, spatkEV, spdefEV, spdEV;
	
	private PokemonComponents components;
	
	void Awake()
	{
		components = GetComponent<PokemonComponents>();
	}

	public void AdjSpeed(float adj)
	{
		components.pokemon.CurWalkSpeed = components.pokemon.maxWalkSpeed * adj;
		components.animator.speed = adj;

		if(components.pokemon.CurWalkSpeed > components.pokemon.maxWalkSpeed)
		{
			components.pokemon.CurWalkSpeed = components.pokemon.maxWalkSpeed;
			components.animator.speed = 1.0f;
		}

		if(components.pokemon.CurWalkSpeed < 0.0f)
		{
			components.pokemon.CurWalkSpeed = 0.0f;
			components.animator.speed = 0.0f;
		}
	}
	
	public void SetupFirstTime()
	{
		atkIV = Random.Range(0, 32);
		defIV = Random.Range(0, 32);
		spatkIV = Random.Range(0, 32);
		spdefIV = Random.Range(0, 32);
		spdIV = Random.Range(0, 32);
		maxATK = Calculations.CalculateStat(components.pokemon.baseATK, components.pokemon.level, atkIV, atkEV, components.pokemon.nature, StatType.ATTACK);
		maxDEF = Calculations.CalculateStat(components.pokemon.baseDEF, components.pokemon.level, defIV, defEV, components.pokemon.nature, StatType.DEFENSE);
		maxSPATK = Calculations.CalculateStat(components.pokemon.baseSPATK, components.pokemon.level, spatkIV, spatkEV, components.pokemon.nature, StatType.SPECIALATTACK);
		maxSPDEF = Calculations.CalculateStat(components.pokemon.baseSPDEF, components.pokemon.level, spdefIV, spdefEV, components.pokemon.nature, StatType.SPECIALDEFENSE);
		maxSPD = Calculations.CalculateStat(components.pokemon.baseSPD, components.pokemon.level, spdIV, spdEV, components.pokemon.nature, StatType.SPEED);
		curMaxATK = maxATK;
		curMaxDEF = maxDEF;
		curMaxSPATK = maxSPATK;
		curMaxSPDEF = maxSPDEF;
		curMaxSPD = maxSPD;
		curATK = maxATK;
		curDEF = maxDEF;
		curSPATK = maxSPATK;
		curSPDEF = maxSPDEF;
		curSPD = maxSPD;
	}
	public void SetupExisting()
	{
		maxATK = Calculations.CalculateStat(components.pokemon.baseATK, components.pokemon.level, atkIV, atkEV, components.pokemon.nature, StatType.ATTACK);
		maxDEF = Calculations.CalculateStat(components.pokemon.baseDEF, components.pokemon.level, defIV, defEV, components.pokemon.nature, StatType.DEFENSE);
		maxSPATK = Calculations.CalculateStat(components.pokemon.baseSPATK, components.pokemon.level, spatkIV, spatkEV, components.pokemon.nature, StatType.SPECIALATTACK);
		maxSPDEF = Calculations.CalculateStat(components.pokemon.baseSPDEF, components.pokemon.level, spdefIV, spdefEV, components.pokemon.nature, StatType.SPECIALDEFENSE);
		maxSPD = Calculations.CalculateStat(components.pokemon.baseSPD, components.pokemon.level, spdIV, spdEV, components.pokemon.nature, StatType.SPEED);
	}
	public void LevelUp()
	{
		maxATK = Calculations.CalculateStat(components.pokemon.baseATK, components.pokemon.level, atkIV, atkEV, components.pokemon.nature, StatType.ATTACK);
		maxDEF = Calculations.CalculateStat(components.pokemon.baseDEF, components.pokemon.level, defIV, defEV, components.pokemon.nature, StatType.DEFENSE);
		maxSPATK = Calculations.CalculateStat(components.pokemon.baseSPATK, components.pokemon.level, spatkIV, spatkEV, components.pokemon.nature, StatType.SPECIALATTACK);
		maxSPDEF = Calculations.CalculateStat(components.pokemon.baseSPDEF, components.pokemon.level, spdefIV, spdefEV, components.pokemon.nature, StatType.SPECIALDEFENSE);
		maxSPD = Calculations.CalculateStat(components.pokemon.baseSPD, components.pokemon.level, spdIV, spdEV, components.pokemon.nature, StatType.SPEED);
		curMaxATK = maxATK;
		curMaxDEF = maxDEF;
		curMaxSPATK = maxSPATK;
		curMaxSPDEF = maxSPDEF;
		curMaxSPD = maxSPD;
		curATK = maxATK;
		curDEF = maxDEF;
		curSPATK = maxSPATK;
		curSPDEF = maxSPDEF;
		curSPD = maxSPD;
	}

	public void AdjCurAtk(int adj)
	{
		curATK += adj;

		if(curATK > curMaxATK)
			curATK = curMaxATK;

		if(curATK < 0)
			curATK = 0;
	}
	public void AdjCurDef(int adj)
	{
		curDEF += adj;

		if(curDEF > curMaxDEF)
			curDEF = curMaxDEF;

		if(curDEF < 0)
			curDEF = 0;
	}

	public void AdjCurMaxDef(int adj)
	{
		curMaxDEF += adj;

		if(curDEF < 0)
			curDEF = 0;
	}
}
