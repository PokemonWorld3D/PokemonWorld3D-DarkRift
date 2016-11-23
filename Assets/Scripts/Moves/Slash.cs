using UnityEngine;
using System.Collections;

public class Slash : Move
{
	[SerializeField] private Collider col;
	[SerializeField] private TrailRenderer trail;
	[SerializeField] private Material[] Materials;
	
	public Slash()
	{
		ResetMoveData("Slash", "The target is attacked with a slash of claws or blades. Critical hits land more easily.", false, true, false, true, false, PokemonTypes.NORMAL,
			MoveCategories.PHYSICAL, 0.0f, 70);
	}
	public void SlashStart()
	{
        components.pokemon.CannotMove();
        ResetMoveValues();
        components.audioS.PlayOneShot(soundEffect);
        trail.materials = Materials;
		trail.enabled = true;
	}
	public void SlashDamage()
	{
        if(!GameManager.instance.isServer)
            return;

		Collider[] cols = Physics.OverlapSphere(col.transform.position, range);
		
		for(int i = 0; i < cols.Length; i++)
		{
			if(cols[i].gameObject == components.pokemon.enemy)
				Calculations.DealDamage(components.pokemon, cols[i].transform.root.GetComponent<Pokemon>(), this);
		}
	}
	public void SlashTrailOff()
	{
		trail.enabled = false;
	}
}