using System;
using System.Collections.Generic;

[System.Serializable]
public class PokemonData : IEquatable<PokemonData>
{
    public string pokemonName, nickname, equippedItem;
    public int gender, nature, level, curMaxHP, curMaxPP, curMaxATK, curMaxDEF, curMaxSPATK, curMaxSPDEF, curMaxSPD, curHP, curPP, curATK, curDEF, curSPATK, curSPDEF, curSPD, hpEV, ppEV, atkEV, defEV, spatkEV,
        spdefEV, spdEV, hpIV, ppIV, atkIV, defIV, spatkIV, spdefIV, spdIV, curEXP, id;
    public bool fromTrade;

    public PokemonData(string pokemonName, string nickname, string equippedItem, int gender, int nature, int level, int curMaxHP, int curMaxPP, int curMaxATK, int curMaxDEF, int curMaxSPATK, int curMaxSPDEF,
        int curMaxSPD, int curHP, int curPP, int curATK, int curDEF, int curSPATK, int curSPDEF, int curSPD, int hpEV, int ppEV, int atkEV, int defEV, int spatkEV, int spdefEV, int spdEV, int hpIV,
        int ppIV, int atkIV, int defIV, int spatkIV, int spdefIV, int spdIV, int curEXP, int id, bool fromTrade)
    {
        this.pokemonName = pokemonName;
        this.nickname = nickname;
        this.equippedItem = equippedItem;
        this.gender = gender;
        this.nature = nature;
        this.level = level;
        this.curMaxHP = curMaxHP;
        this.curMaxPP = curMaxPP;
        this.curMaxATK = curMaxATK;
        this.curMaxDEF = curMaxDEF;
        this.curMaxSPATK = curMaxSPATK;
        this.curMaxSPDEF = curMaxSPDEF;
        this.curMaxSPD = curMaxSPD;
        this.curHP = curHP;
        this.curPP = curPP;
        this.curATK = curATK;
        this.curDEF = curDEF;
        this.curSPATK = curSPATK;
        this.curSPDEF = curSPDEF;
        this.curSPD = curSPD;
        this.hpEV = hpEV;
        this.ppEV = ppEV;
        this.atkEV = atkEV;
        this.defEV = defEV;
        this.spatkEV = spatkEV;
        this.spdefEV = spdefEV;
        this.spdEV = spdEV;
        this.hpIV = hpIV;
        this.ppIV = ppIV;
        this.atkIV = atkIV;
        this.defIV = defIV;
        this.spatkIV = spatkIV;
        this.spdefIV = spdefIV;
        this.spdIV = spdIV;
        this.curEXP = curEXP;
        this.id = id;
        this.fromTrade = fromTrade;
    }    
    public PokemonData(){    }

    public override bool Equals(object obj)
    {
        if(obj == null)
            return false;

        PokemonData objAsData = obj as PokemonData;

        if(objAsData == null)
            return false;
        else
            return Equals(objAsData);
    }
    public override int GetHashCode()
    {
        return id;
    }
    public bool Equals(PokemonData other)
    {
        if(other == null)
            return false;

        return (id.Equals(other.id));
    }
}