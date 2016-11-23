using UnityEngine;
using System.Collections;

[System.Serializable]
public class PokeBall : Item
{
	
	public Sprite icon;
	public GameObject model;
	public float catchRate;
	public PokeBallTypes pokeBallType;
	
	public PokeBall(string name, string description, float catchRate, int cost, int worth, PokeBallTypes pokeBallType, ItemCategories category)
	{
		base.name = name;
		base.description = description;
        icon = Resources.Load<Sprite>("Sprites/PokeBalls/" + base.name);
		this.catchRate = catchRate;
		base.cost = cost;
		base.worth = worth;
		this.pokeBallType = pokeBallType;
		base.category = category;
	}
	
	public PokeBall()
	{
		
	}
}
public enum PokeBallTypes{ CHERISHBALL, DIVEBALL, DREAMBALL, DUSKBALL, FASTBALL, FRIENDBALL, GREATBALL, HEALBALL, HEAVYBALL, LEVELBALL, LOVEBALL, LUREBALL, LUXURYBALL, MASTERBALL,
								MOONBALL, NESTBALL, NETBALL, PARKBALL, POKEBALL, PREMIERBALL, QUICKBALL, REPEATBALL, SAFARIBALL, SPORTBALL, TIMERBALL, ULTRABALL }