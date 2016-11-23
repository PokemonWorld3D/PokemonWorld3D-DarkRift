using DarkRift;
using UnityEngine;
using System.Collections;

public static class Calculations
{
	public static float[,] StatModifier
	{
		get
		{
			if(statModifiers == null)
				InitializeSMArray();
			return statModifiers;
		}
	}
	public static float[,] TypeToTypeDamageRatios
	{
		get
		{
			if(typeToTypeDamageRatios == null)
				InitializeTDArray();
			return typeToTypeDamageRatios;
		}
	}
	
	
	private static float[,] statModifiers;
	private static float[,] typeToTypeDamageRatios;
	
	private static void InitializeSMArray()
	{
		#region statModifiers
		statModifiers = new float[26,26];
		statModifiers[(int)Natures.ADAMANT, (int)StatType.ATTACK] = 1.1f;
		statModifiers[(int)Natures.ADAMANT, (int)StatType.DEFENSE] = 1.0f;
		statModifiers [(int)Natures.ADAMANT, (int)StatType.SPECIALATTACK] = 0.9f;
		statModifiers[(int)Natures.ADAMANT, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers[(int)Natures.ADAMANT, (int)StatType.SPEED] = 1.0f;
		
		statModifiers[(int)Natures.BASHFUL, (int)StatType.ATTACK] = 1.0f;
		statModifiers[(int)Natures.BASHFUL, (int)StatType.DEFENSE] = 1.0f;
		statModifiers[(int)Natures.BASHFUL, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers[(int)Natures.BASHFUL, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers[(int)Natures.BASHFUL, (int)StatType.SPEED] = 1.0f;
		
		statModifiers [(int)Natures.BOLD, (int)StatType.ATTACK] = 0.9f;
		statModifiers[(int)Natures.BOLD, (int)StatType.DEFENSE] = 1.1f;
		statModifiers[(int)Natures.BOLD, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers[(int)Natures.BOLD, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers[(int)Natures.BOLD, (int)StatType.SPEED] = 1.0f;
		
		statModifiers[(int)Natures.BRAVE, (int)StatType.ATTACK] = 1.1f;
		statModifiers[(int)Natures.BRAVE, (int)StatType.DEFENSE] = 1.0f;
		statModifiers[(int)Natures.BRAVE, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers[(int)Natures.BRAVE, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers [(int)Natures.BRAVE, (int)StatType.SPEED] = 0.9f;
		
		statModifiers [(int)Natures.CALM, (int)StatType.ATTACK] = 0.9f;
		statModifiers[(int)Natures.CALM, (int)StatType.DEFENSE] = 1.0f;
		statModifiers[(int)Natures.CALM, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers[(int)Natures.CALM, (int)StatType.SPECIALDEFENSE] = 1.1f;
		statModifiers[(int)Natures.CALM, (int)StatType.SPEED] = 1.0f;
		
		statModifiers[(int)Natures.CAREFUL, (int)StatType.ATTACK] = 1.0f;
		statModifiers[(int)Natures.CAREFUL, (int)StatType.DEFENSE] = 1.0f;
		statModifiers [(int)Natures.CAREFUL, (int)StatType.SPECIALATTACK] = 0.9f;
		statModifiers[(int)Natures.CAREFUL, (int)StatType.SPECIALDEFENSE] = 1.1f;
		statModifiers[(int)Natures.CAREFUL, (int)StatType.SPEED] = 1.0f;
		
		statModifiers[(int)Natures.DOCILE, (int)StatType.ATTACK] = 1.0f;
		statModifiers[(int)Natures.DOCILE, (int)StatType.DEFENSE] = 1.0f;
		statModifiers[(int)Natures.DOCILE, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers[(int)Natures.DOCILE, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers[(int)Natures.DOCILE, (int)StatType.SPEED] = 1.0f;
		
		statModifiers[(int)Natures.GENTLE, (int)StatType.ATTACK] = 1.0f;
		statModifiers [(int)Natures.GENTLE, (int)StatType.DEFENSE] = 0.9f;
		statModifiers[(int)Natures.GENTLE, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers[(int)Natures.GENTLE, (int)StatType.SPECIALDEFENSE] = 1.1f;
		statModifiers[(int)Natures.GENTLE, (int)StatType.SPEED] = 1.0f;
		
		statModifiers[(int)Natures.HARDY, (int)StatType.ATTACK] = 1.0f;
		statModifiers[(int)Natures.HARDY, (int)StatType.DEFENSE] = 1.0f;
		statModifiers[(int)Natures.HARDY, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers[(int)Natures.HARDY, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers[(int)Natures.HARDY, (int)StatType.SPEED] = 1.0f;
		
		statModifiers[(int)Natures.HASTY, (int)StatType.ATTACK] = 1.0f;
		statModifiers [(int)Natures.HASTY, (int)StatType.DEFENSE] = 0.9f;
		statModifiers[(int)Natures.HASTY, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers[(int)Natures.HASTY, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers[(int)Natures.HASTY, (int)StatType.SPEED] = 1.1f;
		
		statModifiers[(int)Natures.IMPISH, (int)StatType.ATTACK] = 1.0f;
		statModifiers[(int)Natures.IMPISH, (int)StatType.DEFENSE] = 1.1f;
		statModifiers [(int)Natures.IMPISH, (int)StatType.SPECIALATTACK] = 0.9f;
		statModifiers[(int)Natures.IMPISH, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers[(int)Natures.IMPISH, (int)StatType.SPEED] = 1.0f;
		
		statModifiers[(int)Natures.JOLLY, (int)StatType.ATTACK] = 1.0f;
		statModifiers[(int)Natures.JOLLY, (int)StatType.DEFENSE] = 1.0f;
		statModifiers [(int)Natures.JOLLY, (int)StatType.SPECIALATTACK] = 0.9f;
		statModifiers[(int)Natures.JOLLY, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers[(int)Natures.JOLLY, (int)StatType.SPEED] = 1.1f;
		
		statModifiers[(int)Natures.LAX, (int)StatType.ATTACK] = 1.0f;
		statModifiers[(int)Natures.LAX, (int)StatType.DEFENSE] = 1.1f;
		statModifiers[(int)Natures.LAX, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers [(int)Natures.LAX, (int)StatType.SPECIALDEFENSE] = 0.9f;
		statModifiers[(int)Natures.LAX, (int)StatType.SPEED] = 1.0f;
		
		statModifiers[(int)Natures.LONELY, (int)StatType.ATTACK] = 1.1f;
		statModifiers [(int)Natures.LONELY, (int)StatType.DEFENSE] = 0.9f;
		statModifiers[(int)Natures.LONELY, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers[(int)Natures.LONELY, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers[(int)Natures.LONELY, (int)StatType.SPEED] = 1.0f;
		
		statModifiers[(int)Natures.MILD, (int)StatType.ATTACK] = 1.0f;
		statModifiers [(int)Natures.MILD, (int)StatType.DEFENSE] = 0.9f;
		statModifiers[(int)Natures.MILD, (int)StatType.SPECIALATTACK] = 1.1f;
		statModifiers[(int)Natures.MILD, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers[(int)Natures.MILD, (int)StatType.SPEED] = 1.0f;
		
		statModifiers [(int)Natures.MODEST, (int)StatType.ATTACK] = 0.9f;
		statModifiers[(int)Natures.MODEST, (int)StatType.DEFENSE] = 1.0f;
		statModifiers[(int)Natures.MODEST, (int)StatType.SPECIALATTACK] = 1.1f;
		statModifiers[(int)Natures.MODEST, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers[(int)Natures.MODEST, (int)StatType.SPEED] = 1.0f;
		
		statModifiers[(int)Natures.NAIVE, (int)StatType.ATTACK] = 1.0f;
		statModifiers[(int)Natures.NAIVE, (int)StatType.DEFENSE] = 1.0f;
		statModifiers[(int)Natures.NAIVE, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers [(int)Natures.NAIVE, (int)StatType.SPECIALDEFENSE] = 0.9f;
		statModifiers[(int)Natures.NAIVE, (int)StatType.SPEED] = 1.1f;
		
		statModifiers[(int)Natures.NAUGHTY, (int)StatType.ATTACK] = 1.1f;
		statModifiers[(int)Natures.NAUGHTY, (int)StatType.DEFENSE] = 1.0f;
		statModifiers[(int)Natures.NAUGHTY, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers [(int)Natures.NAUGHTY, (int)StatType.SPECIALDEFENSE] = 0.9f;
		statModifiers[(int)Natures.NAUGHTY, (int)StatType.SPEED] = 1.0f;

        statModifiers[(int)Natures.NONE, (int)StatType.ATTACK] = 1.0f;
        statModifiers[(int)Natures.NONE, (int)StatType.DEFENSE] = 1.0f;
        statModifiers[(int)Natures.NONE, (int)StatType.SPECIALATTACK] = 1.0f;
        statModifiers[(int)Natures.NONE, (int)StatType.SPECIALDEFENSE] = 1.0f;
        statModifiers[(int)Natures.NONE, (int)StatType.SPEED] = 1.0f;

        statModifiers[(int)Natures.QUIET, (int)StatType.ATTACK] = 1.0f;
		statModifiers[(int)Natures.QUIET, (int)StatType.DEFENSE] = 1.0f;
		statModifiers[(int)Natures.QUIET, (int)StatType.SPECIALATTACK] = 1.1f;
		statModifiers[(int)Natures.QUIET, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers [(int)Natures.QUIET, (int)StatType.SPEED] = 0.9f;
		
		statModifiers[(int)Natures.QUIRKY, (int)StatType.ATTACK] = 1.0f;
		statModifiers[(int)Natures.QUIRKY, (int)StatType.DEFENSE] = 1.0f;
		statModifiers[(int)Natures.QUIRKY, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers[(int)Natures.QUIRKY, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers[(int)Natures.QUIRKY, (int)StatType.SPEED] = 1.0f;
		
		statModifiers[(int)Natures.RASH, (int)StatType.ATTACK] = 1.0f;
		statModifiers[(int)Natures.RASH, (int)StatType.DEFENSE] = 1.0f;
		statModifiers[(int)Natures.RASH, (int)StatType.SPECIALATTACK] = 1.1f;
		statModifiers [(int)Natures.RASH, (int)StatType.SPECIALDEFENSE] = 0.9f;
		statModifiers[(int)Natures.RASH, (int)StatType.SPEED] = 1.0f;
		
		statModifiers[(int)Natures.RELAXED, (int)StatType.ATTACK] = 1.0f;
		statModifiers[(int)Natures.RELAXED, (int)StatType.DEFENSE] = 1.1f;
		statModifiers[(int)Natures.RELAXED, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers[(int)Natures.RELAXED, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers [(int)Natures.RELAXED, (int)StatType.SPEED] = 0.9f;
		
		statModifiers[(int)Natures.SASSY, (int)StatType.ATTACK] = 1.0f;
		statModifiers[(int)Natures.SASSY, (int)StatType.DEFENSE] = 1.0f;
		statModifiers[(int)Natures.SASSY, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers[(int)Natures.SASSY, (int)StatType.SPECIALDEFENSE] = 1.1f;
		statModifiers [(int)Natures.SASSY, (int)StatType.SPEED] = 0.9f;
		
		statModifiers[(int)Natures.SERIOUS, (int)StatType.ATTACK] = 1.0f;
		statModifiers[(int)Natures.SERIOUS, (int)StatType.DEFENSE] = 1.0f;
		statModifiers[(int)Natures.SERIOUS, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers[(int)Natures.SERIOUS, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers[(int)Natures.SERIOUS, (int)StatType.SPEED] = 1.0f;
		
		statModifiers[(int)Natures.TIMID, (int)StatType.ATTACK] = 0.9f;
		statModifiers[(int)Natures.TIMID, (int)StatType.DEFENSE] = 1.0f;
		statModifiers[(int)Natures.TIMID, (int)StatType.SPECIALATTACK] = 1.0f;
		statModifiers[(int)Natures.TIMID, (int)StatType.SPECIALDEFENSE] = 1.0f;
		statModifiers[(int)Natures.TIMID, (int)StatType.SPEED] = 1.1f;
		#endregion
	}
	private static void InitializeTDArray()
	{
		#region typeToTypeDamageRatios
		typeToTypeDamageRatios = new float[19,19];
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.BUG] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.DARK] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.DRAGON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.ELECTRIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.FAIRY] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.FIGHTING] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.FIRE] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.FLYING] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.GHOST] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.GRASS] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.GROUND] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.ICE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.POISON] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.PSYCHIC] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.ROCK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.STEEL] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.BUG, (int)PokemonTypes.WATER] = 1.0f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.BUG] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.DARK] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.DRAGON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.ELECTRIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.FAIRY] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.FIGHTING] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.FIRE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.FLYING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.GHOST] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.GRASS] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.GROUND] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.ICE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.POISON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.PSYCHIC] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.ROCK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.STEEL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DARK, (int)PokemonTypes.WATER] = 1.0f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.BUG] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.DARK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.DRAGON] = 0.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.ELECTRIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.FAIRY] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.FIGHTING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.FIRE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.FLYING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.GHOST] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.GRASS] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.GROUND] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.ICE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.POISON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.PSYCHIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.ROCK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.STEEL] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.DRAGON, (int)PokemonTypes.WATER] = 1.0f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.BUG] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.DARK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.DRAGON] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.ELECTRIC] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.FAIRY] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.FIGHTING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.FIRE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.FLYING] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.GHOST] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.GRASS] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.GROUND] = 0.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.ICE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.POISON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.PSYCHIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.ROCK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.STEEL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ELECTRIC, (int)PokemonTypes.WATER] = 2.0f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.BUG] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.DARK] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.DRAGON] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.ELECTRIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.FAIRY] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.FIGHTING] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.FIRE] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.FLYING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.GHOST] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.GRASS] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.GROUND] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.ICE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.POISON] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.PSYCHIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.ROCK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.STEEL] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.FAIRY, (int)PokemonTypes.WATER] = 1.0f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.BUG] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.DARK] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.DRAGON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.ELECTRIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.FAIRY] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.FIGHTING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.FIRE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.FLYING] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.GHOST] = 0.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.GRASS] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.GROUND] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.ICE] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.NORMAL] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.POISON] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.PSYCHIC] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.ROCK] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.STEEL] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIGHTING, (int)PokemonTypes.WATER] = 1.0f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.BUG] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.DARK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.DRAGON] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.ELECTRIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.FAIRY] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.FIGHTING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.FIRE] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.FLYING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.GHOST] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.GRASS] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.GROUND] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.ICE] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.POISON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.PSYCHIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.ROCK] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.STEEL] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FIRE, (int)PokemonTypes.WATER] = 0.5f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.BUG] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.DARK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.DRAGON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.ELECTRIC] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.FAIRY] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.FIGHTING] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.FIRE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.FLYING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.GHOST] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.GRASS] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.GROUND] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.ICE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.POISON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.PSYCHIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.ROCK] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.STEEL] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.FLYING, (int)PokemonTypes.WATER] = 1.0f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.BUG] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.DARK] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.DRAGON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.ELECTRIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.FAIRY] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.FIGHTING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.FIRE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.FLYING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.GHOST] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.GRASS] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.GROUND] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.ICE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.NORMAL] = 0.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.POISON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.PSYCHIC] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.ROCK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.STEEL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GHOST, (int)PokemonTypes.WATER] = 1.0f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.BUG] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.DARK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.DRAGON] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.ELECTRIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.FAIRY] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.FIGHTING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.FIRE] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.FLYING] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.GHOST] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.GRASS] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.GROUND] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.ICE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.POISON] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.PSYCHIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.ROCK] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.STEEL] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.GRASS, (int)PokemonTypes.WATER] = 2.0f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.BUG] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.DARK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.DRAGON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.ELECTRIC] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.FAIRY] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.FIGHTING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.FIRE] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.FLYING] = 0.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.GHOST] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.GRASS] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.GROUND] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.ICE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.POISON] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.PSYCHIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.ROCK] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.STEEL] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.GROUND, (int)PokemonTypes.WATER] = 1.0f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.BUG] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.DARK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.DRAGON] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.ELECTRIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.FAIRY] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.FIGHTING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.FIRE] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.FLYING] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.GHOST] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.GRASS] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.GROUND] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.ICE] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.POISON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.PSYCHIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.ROCK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.STEEL] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.ICE, (int)PokemonTypes.WATER] = 0.5f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.BUG] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.DARK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.DRAGON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.ELECTRIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.FAIRY] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.FIGHTING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.FIRE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.FLYING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.GHOST] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.GRASS] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.GROUND] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.ICE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.POISON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.PSYCHIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.ROCK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.STEEL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NONE, (int)PokemonTypes.WATER] = 1.0f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.BUG] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.DARK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.DRAGON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.ELECTRIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.FAIRY] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.FIGHTING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.FIRE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.FLYING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.GHOST] = 0.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.GRASS] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.GROUND] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.ICE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.POISON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.PSYCHIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.ROCK] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.STEEL] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.NORMAL, (int)PokemonTypes.WATER] = 1.0f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.BUG] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.DARK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.DRAGON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.ELECTRIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.FAIRY] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.FIGHTING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.FIRE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.FLYING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.GHOST] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.GRASS] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.GROUND] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.ICE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.POISON] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.PSYCHIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.ROCK] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.STEEL] = 0.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.POISON, (int)PokemonTypes.WATER] = 1.0f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.BUG] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.DARK] = 0.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.DRAGON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.ELECTRIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.FAIRY] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.FIGHTING] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.FIRE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.FLYING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.GHOST] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.GRASS] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.GROUND] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.ICE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.POISON] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.PSYCHIC] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.ROCK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.STEEL] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.PSYCHIC, (int)PokemonTypes.WATER] = 1.0f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.BUG] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.DARK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.DRAGON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.ELECTRIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.FAIRY] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.FIGHTING] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.FIRE] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.FLYING] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.GHOST] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.GRASS] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.GROUND] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.ICE] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.POISON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.PSYCHIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.ROCK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.STEEL] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.ROCK, (int)PokemonTypes.WATER] = 1.0f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.BUG] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.DARK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.DRAGON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.ELECTRIC] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.FAIRY] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.FIGHTING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.FIRE] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.FLYING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.GHOST] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.GRASS] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.GROUND] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.ICE] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.POISON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.PSYCHIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.ROCK] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.STEEL] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.STEEL, (int)PokemonTypes.WATER] = 0.5f;
		
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.BUG] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.DARK] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.DRAGON] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.ELECTRIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.FAIRY] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.FIGHTING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.FIRE] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.FLYING] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.GHOST] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.GRASS] = 0.5f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.GROUND] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.ICE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.NONE] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.NORMAL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.POISON] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.PSYCHIC] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.ROCK] = 2.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.STEEL] = 1.0f;
		typeToTypeDamageRatios[(int)PokemonTypes.WATER, (int)PokemonTypes.WATER] = 0.5f;
		#endregion
	}

	#region Stats
	public static int CalculateHP(int _baseHP, int _level, int _iv, int _ev)
	{
		return (int)((((_iv + (2 * _baseHP) + (_ev / 4) + 100) * _level) / 100) + 10);
	}
	public static int CalculatePP(int _basePP, int _level)
	{
		return (int)((((2 * _basePP) + 100) * _level) / 100);
	}
	public static int CalculateStat(int _baseStat, int _level, int _iv, int _ev, Natures _nature, StatType _statType)
	{
		float statModifier = DetermineStatModifier(_nature, _statType);
		return (int)(((((_iv + (2 * _baseStat) + (_ev / 4)) * _level) / 100) + 5) * statModifier);
	}
	private static float DetermineStatModifier(Natures _nature, StatType _stat)
	{
		return (float) (StatModifier[(int)_nature, (int)_stat]);
	}
	#endregion

	#region EXP
	public static int CalculateCurrentXP(int _level, LevelRates _lvlrate)
	{
		if(_lvlrate == LevelRates.ERRATIC)
		{
			return CalculateErraticCurrentXP(_level);
		}
		if(_lvlrate == LevelRates.FAST)
		{
			return CalculateFastCurrentXP(_level);
		}
		if(_lvlrate == LevelRates.FLUCTUATING)
		{
			return CalculateFluctuatingCurrentXP(_level);
		}
		if(_lvlrate == LevelRates.MEDIUM_FAST)
		{
			return CalculateMediumFastCurrentXP(_level);
		}
		if(_lvlrate == LevelRates.MEDIUM_SLOW)
		{
			return CalculateMediumSlowCurrentXP(_level);
		}
		if(_lvlrate == LevelRates.SLOW)
		{
			return CalculateSlowCurrentXP(_level);
		}
		return 0;
	}
	public static int CalculateRequiredXP(int _level, LevelRates _lvlrate)
	{
		if(_lvlrate == LevelRates.ERRATIC)
		{
			return CalculateErraticRequiredXP(_level);
		}
		if(_lvlrate == LevelRates.FAST)
		{
			return CalculateFastRequiredXP(_level);
		}
		if(_lvlrate == LevelRates.FLUCTUATING)
		{
			return CalculateFluctuatingRequiredXP(_level);
		}
		if(_lvlrate == LevelRates.MEDIUM_FAST)
		{
			return CalculateMediumFastRequiredXP(_level);
		}
		if(_lvlrate == LevelRates.MEDIUM_SLOW)
		{
			return CalculateMediumSlowRequiredXP(_level);
		}
		if(_lvlrate == LevelRates.SLOW)
		{
			return CalculateSlowRequiredXP(_level);
		}
		return 0;
	}
	
	private static int CalculateErraticCurrentXP(int _level)
	{
		if(_level < 50)
		{
			return (int)((Mathf.Pow(_level, 3.0f) * (100 - _level)) / 50);
		}
		else if(_level >= 50 && _level < 68)
		{
			return (int)((Mathf.Pow(_level, 3.0f) * (150 - _level)) / 100);
		}
		else if(_level >= 68 && _level < 98)
		{
			return (int)((Mathf.Pow(_level, 3.0f) * (1911 - (10 * _level)) / 3) / 500);
		}
		else
		{
			return (int)((Mathf.Pow(_level, 3.0f) * (160 - _level)) / 100);
		}
	}
	private static int CalculateErraticRequiredXP(int _level)
	{
		if(_level < 50)
		{
			return (int)((Mathf.Pow((_level + 1), 3.0f) * (100 - (_level + 1))) / 50);
		}
		else if(_level >= 50 && _level < 68)
		{
			return (int)((Mathf.Pow((_level + 1), 3.0f) * (150 - (_level + 1))) / 100);
		}
		else if(_level >= 68 && _level < 98)
		{
			return (int)((Mathf.Pow((_level + 1), 3.0f) * (1911 - (10 * (_level + 1))) / 3) / 500);
		}
		else
		{
			return (int)((Mathf.Pow((_level + 1), 3.0f) * (160 - (_level + 1))) / 100);
		}
	}
	private static int CalculateFastCurrentXP(int _level)
	{
		return (int)((4 * Mathf.Pow(_level, 3.0f)) / 5);
	}	
	private static int CalculateFastRequiredXP(int _level)
	{
		return (int)((4 * Mathf.Pow((_level +1), 3.0f)) / 5);
	}
	private static int CalculateMediumFastCurrentXP(int _level)
	{
		return (int)(Mathf.Pow(_level, 3.0f));
	}	
	private static int CalculateMediumFastRequiredXP(int _level)
	{
		return (int)(Mathf.Pow((_level + 1), 3.0f));
	}	
	private static int CalculateMediumSlowCurrentXP(int _level)
	{	
		return (int)(1.2 * Mathf.Pow(_level, 3.0f) - 15 * Mathf.Pow(_level, 2.0f) + 100 * _level - 140);
	}	
	private static int CalculateMediumSlowRequiredXP(int _level)
	{	
		return (int)(1.2 * Mathf.Pow((_level + 1), 3.0f) - 15 * Mathf.Pow((_level + 1), 2.0f) + 100 * (_level + 1) - 140);
	}	
	private static int CalculateSlowCurrentXP(int _level)
	{
		return (int)((5 * Mathf.Pow(_level, 3.0f)) / 4);
	}	
	private static int CalculateSlowRequiredXP(int _level)
	{
		return (int)((5 * Mathf.Pow((_level + 1), 3.0f)) / 4);
	}	
	private static int CalculateFluctuatingCurrentXP(int _level)
	{
		if(_level < 15)
		{
			return (int)(Mathf.Pow(_level, 3.0f) * ((((_level + 1) / 3) + 24) / 50));
		}
		else if(_level >= 15 && _level < 36)
		{
			return (int)(Mathf.Pow(_level, 3.0f) * (((_level + 14) / 50)));
		}
		else
		{
			return (int)(Mathf.Pow(_level, 3.0f) * ((_level / 2) + 32) / 50);
		}
	}	
	private static int CalculateFluctuatingRequiredXP(int _level)
	{
		if(_level < 15)
		{
			return (int)(Mathf.Pow((_level + 1), 3.0f) * (((((_level + 1) + 1) / 3)) + 24) / 50);
		}
		else if(_level >= 15 && _level < 36)
		{
			return (int)(Mathf.Pow((_level + 1), 3.0f) * ((((_level + 1) + 14) / 50)));
		}
		else
		{
			return (int)(Mathf.Pow((_level + 1), 3.0f) * ((((_level + 1) / 2) + 32) / 50));
		}
	}
	#endregion

	#region Damage
	private static int CalculateAttackDamage(PokemonComponents attackerComponents, PokemonComponents targetComponents, Move moveUsed, bool crit)
	{
		return (int)((((2 * attackerComponents.pokemon.level + 10) / (float)250) * ((float)attackerComponents.stats.curATK /
			(float)targetComponents.stats.curDEF) * moveUsed.curPower + 2) * SetModifier(moveUsed.type, attackerComponents.pokemon,
				targetComponents.pokemon, crit));
	}
	private static int CalculateSpecialAttackDamage(PokemonComponents attackerComponents, PokemonComponents targetComponents, Move moveUsed, bool crit)
	{
		return (int)((((2 * attackerComponents.pokemon.level + 10) / (float)250) * ((float)attackerComponents.stats.curSPATK /
			(float)targetComponents.stats.curSPDEF) * moveUsed.curPower + 2) * SetModifier(moveUsed.type, attackerComponents.pokemon,
				targetComponents.pokemon, crit));
	}
	private static float SetModifier(PokemonTypes moveType, Pokemon attacker, Pokemon target, bool critHit)
	{
		//Other is dependant on equipped items, abilities, and field advantages.

		float crit = 0.0f;

		if(critHit)
			crit = 1.5f;
		else
			crit = 1.0f;

		return (DetermineSTAB(moveType, attacker) * DetermineTypeEffectiveness(moveType, target) * crit * /*other*/ Random.Range(0.85f, 1.0f));
	}
	private static float DetermineSTAB(PokemonTypes moveType, Pokemon user)
	{
		float stab1 = 1.0f;
		float stab2 = 1.0f;

		if(moveType == user.typeOne)
		{
			if(user.abilityOne == "Adaptability" || user.abilityTwo == "Adaptability")
				stab1 = 2.0f;
			else
				stab1 = 1.5f;
		}

		if(moveType == user.typeTwo)
		{
			if(user.abilityOne == "Adaptability" || user.abilityTwo == "Adaptability")
				stab2 = 2.0f;
			else
				stab2 = 1.5f;
		}

		return stab1 * stab2;
	}
	private static bool DetermineCritical(int attackerBaseSPD, bool moveHasHighCritChance)
	{
		float chance = 0.0f;

		if(moveHasHighCritChance)
			chance = (attackerBaseSPD / 64);
		else
			chance = (attackerBaseSPD / 512);

		float random = Random.Range(1, 101);

		if(random <= chance)
			return  true;
		else
			return false;
	}
	private static float DetermineTypeEffectiveness(PokemonTypes moveType, Pokemon target)
	{
		
		float te1 = (float)(TypeToTypeDamageRatios[(int)moveType, (int)target.typeOne]);
		float te2 = (float)(TypeToTypeDamageRatios[(int)moveType, (int)target.typeTwo]);

		return te1 * te2;
	}
	public static void DealDamage(Pokemon attacker, Pokemon target, Move moveUsed)
	{
		int damage;
		bool critical = DetermineCritical(attacker.baseSPD, moveUsed.highCritRate);

		if(moveUsed.category == MoveCategories.PHYSICAL)
			damage = CalculateAttackDamage(attacker.components, target.components, moveUsed, critical);
		else if(moveUsed.category == MoveCategories.SPECIAL)
			damage = CalculateAttackDamage(attacker.components, target.components, moveUsed, critical);
		else
			damage = 0;

		target.components.hpPP.AdjCurHP(-damage, critical);

        DarkRiftAPI.SendMessageToID(target.networkID, TagIndex.PokemonUpdate, TagIndex.PokemonUpdateSubjects.AdjustHP, damage);
	}
	#endregion

	public static int AddExperience(bool _faintedIsCaptured, bool _winningIsFromTrade, int _faintedBaseEXP, bool _winningHasLuckyEgg, int _faintedLevel, int _winningLevel,
	                                int _winningEvolveLevel)
	{
		//		float f = 1.2 if the pkmn calculating exp for has 2 or more affection hearts or 1 if less than 2 affection hearts
		
		float a = 1.0f;
		if(!_faintedIsCaptured)
		{
			a = 1.0f;
		}
		
		float t = 1.0f;
		if(_winningIsFromTrade)
		{
			t = 1.5f;
		}
		
		int baseEXP = _faintedBaseEXP;
		
		float e= 1.0f;
		if(_winningHasLuckyEgg)
		{
			e = 1.5f; 
		}
		
		int level = _faintedLevel;
		
		float v = 1.0f;
		if(_winningLevel > _winningEvolveLevel)
		{
			v = 1.2f;
		}
		
		int s = 1;
		
		return (int)Mathf.Abs(a * t * baseEXP * e * level * /*f * */v) / (7 * s);
	}

	public static bool AttemptCapture(Pokemon _pokemon, PokemonConditions _pokemonConditions, PokeBallTypes _pokeBallType)
	{
		float ballBonus = 1.0f, statusBonus;
		int modifiedCatchRate;
		PokemonHPPP hp = _pokemon.gameObject.GetComponent<PokemonHPPP>();

		if(_pokeBallType == PokeBallTypes.POKEBALL)
		{
			ballBonus = 1.0f;
		}
		else if(_pokeBallType == PokeBallTypes.GREATBALL)
		{
			ballBonus = 1.5f;
		}
		else if(_pokeBallType == PokeBallTypes.ULTRABALL)
		{
			ballBonus = 2f;
		}
		else if(_pokeBallType == PokeBallTypes.MASTERBALL)
		{
			ballBonus = 255f;
		}
		statusBonus = CaptureStatusBonus(_pokemonConditions);
		modifiedCatchRate = (int)(((3 * hp.maxHP - 2 * hp.curHP) * _pokemon.captureRate * ballBonus) / (3 * hp.maxHP) * statusBonus);
		int i = Random.Range(0, 255);
		if(i <= modifiedCatchRate)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	private static float CaptureStatusBonus(PokemonConditions _pokemonConditions)
	{
		if(_pokemonConditions.sleeping)
		{
			return 2f;
		}
		else if(_pokemonConditions.burned)
		{
			return 1.5f;
		}
		else if(_pokemonConditions.frozen)
		{
			return 2f;
		}
		else if(_pokemonConditions.paralyzed)
		{
			return 1.5f;
		}
		else if(_pokemonConditions.poisoned)
		{
			return 1.5f;
		}
		else
		{
			return 1f;
		}
	}
}
public enum StatType
{
	HITPOINTS, POWERPOINTS, ATTACK, DEFENSE, SPECIALATTACK, SPECIALDEFENSE, SPEED
}
