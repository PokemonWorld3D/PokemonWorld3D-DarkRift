using DarkRift;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public static class Networking
{

    public static void SerialisePokemonData(PokemonData data, string trainername, Vector3 position)
	{
		using(DarkRiftWriter writer = new DarkRiftWriter())
		{
            writer.Write(new string[] { data.pokemonName, data.nickname, data.equippedItem, trainername } );
            writer.Write(new int[] { data.gender, data.nature, data.level, data.curMaxHP, data.curMaxPP, data.curMaxATK, data.curMaxDEF, data.curMaxSPATK, data.curMaxSPDEF, data.curMaxSPD, data.curHP,
            data.curPP, data.curATK, data.curDEF, data.curSPATK, data.curSPDEF, data.curSPD, data.hpEV, data.ppEV, data.atkEV, data.defEV, data.spatkEV, data.spdefEV, data.spdefEV, data.hpIV,
            data.ppIV, data.atkIV, data.defIV, data.spatkIV, data.spdefIV, data.spdIV, data.curEXP, data.id });
            writer.Write(data.fromTrade);
            writer.Write(new double[] { position.x, position.y, position.z });
			DarkRiftAPI.SendMessageToAll(TagIndex.Controller, TagIndex.ControllerSubjects.SpawnPokemon, writer);
		}
	}
    public static void SerialiseAnimFloat(byte tagIndex, ushort subject, string stateName, float value)
	{
		using(DarkRiftWriter writer = new DarkRiftWriter())
		{
			writer.Write(stateName);
			writer.Write(value);

			DarkRiftAPI.SendMessageToOthers(tagIndex, subject, writer);
		}
	}
    public static void SerialiseAnimBool(byte tagIndex, ushort subject, string stateName, bool value)
	{
		using(DarkRiftWriter writer = new DarkRiftWriter())
		{
			writer.Write(stateName);
			writer.Write(value);

			DarkRiftAPI.SendMessageToOthers(tagIndex, subject, writer);
		}
	}
    public static void BurnMessage(Pokemon target, Move moveUsed)
    {
        string targetsName = string.IsNullOrEmpty(target.nickname) ? target.pokemonName : target.nickname;
		string msg = targetsName + "(" + target.trainerName + ") was burned by " + moveUsed.moveName + "!";
        DarkRiftAPI.SendMessageToAll(TagIndex.Chat, TagIndex.ChatSubjects.BattleChat, msg);
    }
    public static void DamageMessage(Pokemon attacker, Pokemon target, Move moveUsed, int damage, bool critical)
	{
		string attackersName = string.IsNullOrEmpty(attacker.nickname) ? attacker.pokemonName : attacker.nickname;
		string targetsName = string.IsNullOrEmpty(target.nickname) ? target.pokemonName : target.nickname;
        string msg;

		if(critical)
			msg = attackersName + "(" + attacker.trainerName + ") dealt " + damage + " damage to " + targetsName + "(" + target.trainerName +
			") using " + moveUsed.moveName + "!!!";
		else
			msg = attackersName + "(" + attacker.trainerName + ") dealt " + damage + " damage to " + targetsName + "(" + target.trainerName +
			") using " + moveUsed.moveName + ".";

        DarkRiftAPI.SendMessageToAll(TagIndex.Chat, TagIndex.ChatSubjects.BattleChat, msg);
	}
	public static void FlinchMessage(Pokemon target, Move moveUsed)
	{
		string targetsName = string.IsNullOrEmpty(target.nickname) ? target.pokemonName : target.nickname;
		string msg = moveUsed.moveName + " caused " + targetsName + "(" + target.trainerName + ") to flinch!";
        DarkRiftAPI.SendMessageToAll(TagIndex.Chat, TagIndex.ChatSubjects.BattleChat, msg);
	}
	public static void PartiallyTrappedMessage(Pokemon target, Move moveUsed)
	{
		string targetsName = string.IsNullOrEmpty(target.nickname) ? target.pokemonName : target.nickname;
		string msg = targetsName + "(" + target.trainerName + ") was trapped by " + moveUsed.moveName + "!";
        DarkRiftAPI.SendMessageToAll(TagIndex.Chat, TagIndex.ChatSubjects.BattleChat, msg);
	}
	public static void StatModMessage(Pokemon target, Move moveUsed, StatType stat, bool trueForUp)
	{
		string targetsName = string.IsNullOrEmpty(target.nickname) ? target.pokemonName : target.nickname;
		string statString = string.Empty;

		if(stat == StatType.ATTACK)
			statString = "attack";
		else if(stat == StatType.DEFENSE)
			statString = "defense";
		else if(stat == StatType.SPECIALATTACK)
			statString = "special attack";
		else if(stat == StatType.SPECIALDEFENSE)
			statString = "special defense";
		else if(stat == StatType.SPEED)
			statString = "speed";

        string msg;

        if(trueForUp)
			msg = targetsName + "(" + target.trainerName + ") raised its " + statString + " using " + moveUsed.moveName + "!";
		else
			msg = targetsName + "(" + target.trainerName + ") had its " + statString + " lowered by " + moveUsed.moveName + "!";

        DarkRiftAPI.SendMessageToAll(TagIndex.Chat, TagIndex.ChatSubjects.BattleChat, msg);
	}
    public static void DeserialisePokemonData(object data, ushort senderID, Trainer trainer)
	{
        if(data is DarkRiftReader)
            using(DarkRiftReader reader = (DarkRiftReader)data)
            {
                string[] strings = reader.ReadStrings();
                int[] ints = reader.ReadInt32s();
                PokemonData pokemonData = new PokemonData(strings[0], strings[1], strings[2], ints[0], ints[1], ints[2], ints[3], ints[4], ints[5], ints[6], ints[7], ints[8], ints[9], ints[10],
                    ints[11], ints[12], ints[13], ints[14], ints[15], ints[16], ints[17], ints[18], ints[19], ints[20], ints[21], ints[22], ints[23], ints[24], ints[25], ints[26], ints[27], ints[28],
                    ints[29], ints[30], ints[31], ints[32], reader.ReadBoolean());

                double[] doubles = reader.ReadDoubles();
                

                GameObject clone = Object.Instantiate(Resources.Load("Prefabs/Pokemon/" + pokemonData.pokemonName), new Vector3((float)doubles[0], (float)doubles[1], (float)doubles[2]),
                    Quaternion.identity) as GameObject;
                PokemonComponents components = clone.GetComponent<PokemonComponents>();

                components.pokemon.trainerName = strings[3];
                components.pokemon.networkID = senderID;
                components.pokemon.nickname = pokemonData.nickname;
                components.pokemon.fromTrade = pokemonData.fromTrade;
                components.pokemon.level = pokemonData.level;
                components.pokemon.gender = (Genders)pokemonData.gender;
                components.pokemon.nature = (Natures)pokemonData.nature;
                components.hpPP.curMaxHP = pokemonData.curMaxHP;
                components.hpPP.curMaxPP = pokemonData.curMaxPP;
                components.stats.curMaxATK = pokemonData.curMaxATK;
                components.stats.curMaxDEF = pokemonData.curMaxDEF;
                components.stats.curMaxSPATK = pokemonData.curMaxSPATK;
                components.stats.curMaxSPDEF = pokemonData.curMaxSPDEF;
                components.stats.curMaxSPD = pokemonData.curMaxSPD;
                components.hpPP.curHP = pokemonData.curHP;
                components.hpPP.curPP = pokemonData.curPP;
                components.stats.curATK = pokemonData.curATK;
                components.stats.curDEF = pokemonData.curDEF;
                components.stats.curSPATK = pokemonData.curSPATK;
                components.stats.curSPDEF = pokemonData.curSPDEF;
                components.stats.curSPD = pokemonData.curSPD;
                components.hpPP.hpEV = pokemonData.hpEV;
                components.hpPP.ppEV = pokemonData.ppEV;
                components.stats.atkEV = pokemonData.atkEV;
                components.stats.defEV = pokemonData.defEV;
                components.stats.spatkEV = pokemonData.spatkEV;
                components.stats.spdefEV = pokemonData.spdefEV;
                components.stats.spdEV = pokemonData.spdEV;
                components.hpPP.hpIV = pokemonData.hpIV;
                components.hpPP.ppIV = pokemonData.ppIV;
                components.stats.atkIV = pokemonData.atkIV;
                components.stats.defIV = pokemonData.defIV;
                components.stats.spatkIV = pokemonData.spatkIV;
                components.stats.spdefIV = pokemonData.spdefIV;
                components.stats.spdIV = pokemonData.spdIV;
                components.pokemon.curEXP = pokemonData.curEXP;
                components.pokemon.equippedItem = pokemonData.equippedItem;
                components.pokemon.id = pokemonData.id;

                trainer.AssignPokemon(components.pokemon);

                components.pokemon.SetupExistingPokemon();
            }
		else
            Debug.LogError("Should have recieved a DarkRiftReciever but didn't! (Got: " + data.GetType() + ")");
	}
	public static void DeserialiseTrainerAnimFloat(object data, Animator animator)
	{
		if(data is DarkRiftReader)
			using(DarkRiftReader reader = (DarkRiftReader)data)
                animator.SetFloat(reader.ReadString(), reader.ReadSingle());
		else
			Debug.LogError("Should have recieved a DarkRiftReciever but didn't! (Got: " + data.GetType() + ")");
	}
    public static void DeserialiseTrainerAnimBool(object data, Animator animator)
	{
		if(data is DarkRiftReader)
			using(DarkRiftReader reader = (DarkRiftReader)data)
                animator.SetBool(reader.ReadString(), reader.ReadBoolean());
		else
			Debug.LogError("Should have recieved a DarkRiftReciever but didn't! (Got: " + data.GetType() + ")");
	}
    public static void DeserialisePokemonAnimFloat(object data, Animator animator)
	{
		if(data is DarkRiftReader)
			using(DarkRiftReader reader = (DarkRiftReader)data)
                animator.SetFloat(reader.ReadString(), reader.ReadSingle());
		else
			Debug.LogError("Should have recieved a DarkRiftReciever but didn't! (Got: " + data.GetType() + ")");
	}
    public static void DeserialisePokemonAnimBool(object data, Animator animator)
	{
		if(data is DarkRiftReader)
			using(DarkRiftReader reader = (DarkRiftReader)data)
                animator.SetBool(reader.ReadString(), reader.ReadBoolean());
		else
			Debug.LogError("Should have recieved a DarkRiftReciever but didn't! (Got: " + data.GetType() + ")");
	}
}