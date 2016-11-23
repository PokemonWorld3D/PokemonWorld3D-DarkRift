using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerPokemonPortrait : MonoBehaviour
{
	public enum statusCondition { Burn = 0, Frozen = 1, Paralyze = 2, Poison = 3, Sleep = 4 }

    public MovePanel movePanelScript { get; private set; }

    [SerializeField] private Image hpBar, ppBar, expBar, avatar;
    [SerializeField] private Text info, hitPoints, powerPoints, experiencePoints;
    [SerializeField] private GameObject movePanel, buffDebuffPanel;
    [SerializeField] private GameObject buffDebuffPrefab;
    [SerializeField] private Sprite[] BuffSprites, DebuffSprites;

    private Image[] StatusConditions;
    private Pokemon pokemon;
	private PokemonHPPP hpPP;

    void Awake()
    {
        movePanelScript = movePanel.GetComponent<MovePanel>();
        StatusConditions = new Image[5];
        for(int i = 0; i < StatusConditions.Length - 1; i++)
        {
            StatusConditions[i] = transform.FindChild("Status Conditions").GetChild(i).GetComponent<Image>();
        }
    }
	void Update()
	{
		HandlePlayerPokemonGUI();
	}
	
	public void SetActivePokemon(Pokemon pokemon)
	{
		this.pokemon = pokemon;
		hpPP = pokemon.components.hpPP;
		gameObject.SetActive(true);
		enabled = true;
		movePanel.SetActive(true);
		movePanelScript.pokemon = this.pokemon;
		movePanelScript.Setup();
	}
	public void RemoveActivePokemon()
	{
		enabled = false;
		gameObject.SetActive(false);
		movePanelScript.Clear();
		movePanelScript.pokemon = null;
		movePanel.SetActive(false);
		pokemon = null;
		hpPP = null;
	}
	public void ModifyStatusCondition(statusCondition condition, bool enabled)
	{
		StatusConditions[(int)condition].enabled = enabled;
	}
    public void SpawnBuffIcon(Buff buff)
	{
		GameObject buffIcon = Instantiate(buffDebuffPrefab) as GameObject;
		buffIcon.transform.SetParent(buffDebuffPanel.transform);
		buffIcon.GetComponent<Buff_Debuff_Icon>().SetupIcon(BuffSprites[(int)buff.type], buff.duration);
	}
	public void SpawnDebuffIcon(Debuff debuff)
	{
		GameObject debuffIcon = Instantiate(buffDebuffPrefab) as GameObject;
		debuffIcon.transform.SetParent(buffDebuffPanel.transform);
		debuffIcon.GetComponent<Buff_Debuff_Icon>().SetupIcon(DebuffSprites[(int)debuff.type], debuff.duration);
	}

	private void HandlePlayerPokemonGUI()
	{
		if(pokemon.nickname != "")
			info.text = "Level " + pokemon.level + " " + pokemon.nickname;
		else
			info.text = "Level " + pokemon.level + " " + pokemon.pokemonName;

		avatar.sprite = pokemon.avatar;
		hitPoints.text = "HP : " + hpPP.curHP + " / " + hpPP.curMaxHP;
		powerPoints.text = "PP : " + hpPP.curPP + " / " + hpPP.curMaxPP;
		experiencePoints.text = "EXP : " + pokemon.curEXP + " / " + pokemon.nextReqEXP;
		hpBar.fillAmount = Mathf.MoveTowards(hpBar.fillAmount, ((float)hpPP.curHP / (float)hpPP.curMaxHP), Time.deltaTime * 0.5f);

		if(hpPP.curHP > hpPP.curMaxHP / 2)
			hpBar.color = new Color32((byte)CalculateValue(hpPP.curHP, hpPP.curMaxHP / 2, hpPP.curMaxHP, 255, 0), 255, 0, 255);
		else
			hpBar.color = new Color32(255, (byte)CalculateValue(hpPP.curHP, 0, hpPP.curMaxHP / 2, 0, 255), 0 , 255);
		
		ppBar.fillAmount = Mathf.MoveTowards(ppBar.fillAmount, ((float)hpPP.curPP / (float)hpPP.curMaxPP), Time.deltaTime * 0.5f);
		expBar.fillAmount = Mathf.MoveTowards(expBar.fillAmount, (((float)pokemon.curEXP - (float)pokemon.lastReqEXP) / ((float)pokemon.nextReqEXP - (float)pokemon.lastReqEXP)),
		                             Time.deltaTime * 0.5f);
	}
	private float CalculateValue(float curValue, float minValue, float maxValue, float minXPos, float maxXPos)
	{
		return (curValue - minValue) * (maxXPos - minXPos) / (maxValue - minValue) + minXPos;
	}
}
