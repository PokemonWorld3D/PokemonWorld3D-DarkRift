using DarkRift;
using UnityEngine;
using System.Collections;

public class PokemonConditions : MonoBehaviour
{
	public bool burned, frozen, paralyzed, poisoned, sleeping, confused, cursed, embargoed, encored, flinching, healBlocked, identified, infatuated, nightmared, partiallyTrapped, perishSonged, seeded,
        taunted, tormented, aquaRinged, bracing, centerOfAttention, defenseCurling, rooting, magicallyCoated, magneticallyLevitating, minimized, protecting, semiInvulnerable, hasASubstitute, takingAim,
        trapped;

	private PokemonComponents components;

	[SerializeField] private GameObject partiallyTrappedSFX;

	void Awake()
	{
		components = GetComponent<PokemonComponents>();
	}
	void Start()
	{
		if(components.pokemon.networkID == DarkRiftAPI.id)
			InvokeRepeating("ConditionTicker", 0.0f, 5.0f);
	}

	public void Burn(bool value)
	{
		if(!protecting)
			burned = value;
	}
	public void Flinch(bool value)
	{
		if(!protecting)
			flinching = value;
	}
	public void Protect(bool value)
	{
		protecting = value;
	}

	private void ConditionTicker()
	{
		if(burned)
		{
			int amount = (int)(components.hpPP.curHP * 0.125f);

			if(amount < 1)
				amount = 1;

			components.hpPP.AdjCurHP(-amount, false);
		}

		if(flinching)
			flinching = false;
	}

	public void PartiallyTrapped(string attack)
	{
		if(attack == "Fire Spin")
		{
			GameObject sfx = partiallyTrappedSFX.transform.FindChild("Fire Spin Effect").gameObject;
			sfx.transform.parent = null;
			sfx.SetActive(true);
		}
	}
}