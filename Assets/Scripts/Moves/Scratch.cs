using UnityEngine;
using System.Collections;

public class Scratch : Move
{
	[SerializeField] private Collider col;
	[SerializeField] private TrailRenderer trail;
	[SerializeField] private Material[] Materials;

	public Scratch()
	{
		ResetMoveData("Scratch", "Hard, pointed, sharp claws rake the target to inflict damage.", false, false, false, true, false, PokemonTypes.NORMAL, MoveCategories.PHYSICAL,
			0.0f, 40);
	}
	public void ScratchStart()
	{
        components.pokemon.CannotMove();
		ResetMoveValues();
		components.audioS.PlayOneShot(soundEffect);
		trail.materials = Materials;
		trail.enabled = true;
	}
	public void ScratchDamage()
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
	public void ScratchTrailOff()
	{
		trail.enabled = false;
	}
}
