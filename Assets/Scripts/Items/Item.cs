using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
	
	public string name;
	public string description;
	public int cost;
	public int worth;
	public ItemTypes type;
	public ItemCategories category;
	
	public Item(string name, string description, int cost, int worth, ItemTypes type, ItemCategories category)
	{
		this.name = name;
		this.description = description;
		this.cost = cost;
		this.worth = worth;
		this.type = type;
		this.category = category;
	}
	
	public Item()
	{
		
	}
	
}
public enum ItemCategories{ AESTHETIC, BERRYANDAPRICORN, ITEM, MEDICINE, OTHER }
public enum ItemTypes{ NONE, ESCAPE, EVOLUTION_STONE, EXCHANGEABLE, FLUTE, FOSSIL, HELD, LEGENDARY_ARTIFACT, REPEL, SHARD, VALUABLE }
