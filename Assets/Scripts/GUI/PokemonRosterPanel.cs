using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PokemonRosterPanel : MonoBehaviour
{
	private Image[] EmptyPokeBalls, Pokemon, Selected;
	private Color occupiedPokeBall;
    private HUD hud;
	private int index = 0;

    void Awake()
    {
        hud = GetComponentInParent<HUD>();
        occupiedPokeBall = new Color(255, 255, 255, 0.5f);
        EmptyPokeBalls = new Image[6];
        Pokemon = new Image[6];
        Selected = new Image[6];
        
        for(int i = 0; i < EmptyPokeBalls.Length; i++)
        {
            EmptyPokeBalls[i] = transform.FindChild("Empty Poke Ball " + i.ToString()).GetComponent<Image>();
            Pokemon[i] = transform.FindChild("Pokemon " + i.ToString()).GetComponent<Image>();
            Selected[i] = transform.FindChild("Selected " + i.ToString()).GetComponent<Image>();
        }
    }

	public void Setup()
	{
		for(int i = 0; i < hud.trainer.PokemonRoster.Count; i++)
		{
			EmptyPokeBalls[i].color = occupiedPokeBall;
			Pokemon[i].sprite = Resources.Load<Sprite>("Sprites/Mini Pokemon/" + hud.trainer.PokemonRoster[i].pokemonName);
			Pokemon[i].enabled = true;
		}

		UpdateSelectedPokemon(index);
	}
	public void UpdateSelectedPokemon(int index)
	{
		Selected[this.index].enabled = false;
		this.index = index;
		Selected[this.index].enabled = true;
	}
}
