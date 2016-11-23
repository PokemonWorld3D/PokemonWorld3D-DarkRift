using DarkRift;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleRequest : MonoBehaviour
{
    private Text text;
    private GameObject accept, decline, okay;
    private HUD hud;

	void Awake()
	{
        text = transform.FindChild("Text").GetComponent<Text>();
        accept = transform.FindChild("Accept Button").gameObject;
        decline = transform.FindChild("Decline Button").gameObject;
        okay = transform.FindChild("Okay Button").gameObject;
		hud = GetComponentInParent<HUD>();
	}

	public void ReceiveBattleRequest(string trainersName)
	{
		text.text = trainersName + " would like to battle you.";
		gameObject.SetActive(true);
		accept.SetActive(true);
		decline.SetActive(true);
		
	}
	public void AcceptRequest()
	{
		//hud.trainer.CmdAcceptBattleRequest(otherTrainerNetId);
	}
	public void DeclineRequest()
	{
		//hud.trainer.CmdDeclineBattleRequest(otherTrainerNetId);
	}
	public void RequestAccepted(string trainersName)
	{
		text.text = trainersName + " has accepted your request for a Pokemon battle.";
		gameObject.SetActive(true);
		okay.SetActive(true);
	}
	public void RequestDenied(string trainersName)
	{
		text.text = trainersName + " has declined your request for a Pokemon battle.";
		gameObject.SetActive(true);
		okay.SetActive(true);
	}
}
