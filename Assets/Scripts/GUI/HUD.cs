using DarkRift;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour
{
    [HideInInspector] public Trainer trainer;

    public GameObject loadingPanel, otherTrainerPanel;
    public PlayerPokemonPortrait playerPokemonPortrait;
    public EnemyPokemonPortrait enemyPokemonPortrait;
    public BattleRequest battleRequestScript;
    public PokemonRosterPanel pokemonRosterPanel;

    [SerializeField] private GameObject wildPokemonPanel, battleRequestPanel;
    [SerializeField] private InputField chatInput;
    [SerializeField] private Text mainChat, battleChat;

    private GameObject target;

	public void SetTrainer(Trainer trainer)
	{
		this.trainer = trainer;
		this.trainer.HUD = this;
		pokemonRosterPanel.Setup();
	}
	public void DisplayWildPokemonPanel(GameObject target)
	{
		wildPokemonPanel.SetActive(true);
		this.target = target;
	}
	public void HideWildPokemonPanel()
	{
		wildPokemonPanel.SetActive(false);
		target = null;
	}
	public void WildPokemonBattle()
	{
		//NetworkInstanceId netId = target.GetComponent<NetworkIdentity>().netId;

		//trainer.CmdInitWildPokemonBattle(netId);
		HideWildPokemonPanel();
	}
	public void DisplayOtherTrainerPanel(GameObject target)
	{
		otherTrainerPanel.SetActive(true);
		this.target = target;
	}
	public void HideOtherTrainerPanel()
	{
		otherTrainerPanel.SetActive(false);
		target = null;
	}
	//public void RequestTrainerBattle()
	//{
	//	Trainer otherTrainer = target.GetComponent<Trainer>();
 //       DarkRiftAPI.SendMessageToServer(TagIndex.TrainerBattle, TagIndex.TrainerBattleSubjects.Request, otherTrainer.networkID);
	//}

	public void AddToMainChat(string message)
	{
		mainChat.text += "\n" + message;
	}
	public void AddToBattleChat(string message)
	{
		battleChat.text += "\n" + message;
	}


	public void SendChatMessage()
	{
		if(!string.IsNullOrEmpty(chatInput.text.Trim()))
		{
            DarkRiftAPI.SendMessageToAll(TagIndex.Chat, TagIndex.ChatSubjects.MainChat, chatInput.text);

			chatInput.text = string.Empty;
		}
	}
}
