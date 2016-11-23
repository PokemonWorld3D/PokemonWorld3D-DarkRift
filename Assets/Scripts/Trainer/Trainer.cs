using DarkRift;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trainer : MonoBehaviour
{
    public ushort networkID;
    [HideInInspector] public bool localPlayer;
    public float walkSpeed, runMultiplier, jumpHeight, gravity, colliderRadius;

    public bool InBattle { get { return inBattle; } }
    public bool CanBattle { get { return canBattle; } }
    public int SelectedRosterSlot { get { return selectedRosterSlot; } }

    public TrainerComponents components { get; private set; }
    public Trainer opponent { get; private set; }
    public List<PokemonData> PokemonRoster { get; private set; }
    public HUD hud { get; private set; }

    public Pokemon Pokemon { get { return pokemon; } set { pokemon = value; } }
    public string TrainersName { get { return trainerName; } set { trainerName = value; } }
    public HUD HUD { get { return hud; } set { hud = value; } }

    [SerializeField] private Transform cameraFocus;
    [SerializeField] private ReturnBall returnBall;

    private string username, trainerName = "Trainer";
    private Genders gender;
    private int funds, selectedRosterSlot;
    private Vector3 lastPosition;
    private Quaternion lastRotation;
    private bool canBattle = true, inBattle;
    private List<string> MainChatHistory = new List<string>();
    private List<PokemonData> DownloadedData = new List<PokemonData>(), PokemonInventory = new List<PokemonData>();
    private Pokemon pokemon;

    void Awake()
    {
        components = GetComponent<TrainerComponents>();
        PokemonRoster = new List<PokemonData>();
    }
    void Start()
    {
        DarkRiftAPI.onDataDetailed += ReceiveData;
        DarkRiftAPI.onPlayerDisconnected += PlayerDisconnected;
    }
    void Update()
    {
        DarkRiftAPI.Receive();

        if(localPlayer)
        {
            if(transform.position != lastPosition)
                DarkRiftAPI.SendMessageToOthers(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.Position, transform.position);
            if(transform.rotation != lastRotation)
                DarkRiftAPI.SendMessageToOthers(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.Rotation, transform.rotation);

            lastPosition = transform.position;
            lastRotation = transform.rotation;
        }
    }

    public void Init(GameManager.TrainerData trainerData)
    {
        if(localPlayer)
        {
            username = trainerData.username;
            trainerName = trainerData.trainername;
            gender = trainerData.gender;
            funds = trainerData.funds;

            PokemonRoster = new List<PokemonData>();
            PokemonInventory = new List<PokemonData>();

            if(trainerData.Pokemon.Count > 6)
            {
                for(int i = 0; i < 5; i++)
                {
                    PokemonRoster.Add(trainerData.Pokemon[0]);
                    trainerData.Pokemon.RemoveAt(0);
                }
                PokemonInventory = trainerData.Pokemon;
            }
            else
                PokemonRoster = trainerData.Pokemon;

            GameObject.Find("HUD").SendMessage("SetTrainer", this);
            OnPokeRosterAdd();
            Camera.main.SendMessage("SetTarget", cameraFocus);
            components.input.enabled = true;
            components.controller.enabled = true;
            components.audioL.enabled = true;
            components.rigidbody.WakeUp();
            enabled = true;
        }
    }
    public void AssignPokemon(Pokemon pokemon)
    {
        this.pokemon = pokemon;
        pokemon.Trainer = this;

        if(localPlayer)
        {
            pokemon.components.input.enabled = true;
            components.controller.pokemon = pokemon;
        }

        if(inBattle)
            pokemon.components.anim.Battle(true);
    }
    public void RemovePokemon()
	{
		pokemon = null;
        components.controller.pokemon = null;

		hud.playerPokemonPortrait.RemoveActivePokemon();
	}

    private void ReceiveData(ushort senderID, byte tag, ushort subject, object data)
    {
        if(senderID == networkID)
        {
            if(subject == TagIndex.ControllerSubjects.SpawnPokemon)
                Networking.DeserialisePokemonData(data, senderID, this);
            if(tag == TagIndex.PlayerUpdate)
            {
                if(subject == TagIndex.PlayerUpdateSubjects.Position)
                    transform.position = (Vector3)data;
                if(subject == TagIndex.PlayerUpdateSubjects.Rotation)
                    transform.rotation = (Quaternion)data;
                if(subject == TagIndex.PlayerUpdateSubjects.AnimatorFloat)
                    Networking.DeserialiseTrainerAnimFloat(data, components.animator);
                if(subject == TagIndex.PlayerUpdateSubjects.AnimatorBool)
                    Networking.DeserialiseTrainerAnimBool(data, components.animator);
            }
        }
    }
    private void PlayerDisconnected(ushort ID)
    {
        if (ID == networkID)
            Destroy(gameObject);
    }
    private void OnPokeRosterAdd()
    {
        if(networkID == DarkRiftAPI.id)
            hud.pokemonRosterPanel.Setup();
    }
    private void OnMainChatChange(int index)
    {
        if(networkID == DarkRiftAPI.id)
            hud.AddToMainChat(MainChatHistory[index]);
    }

    //#region ClientRPCs
    //[ClientRpc] public void RpcIncomingBattleRequest(string trainerName, NetworkInstanceId otherTrainerNetId)
    //{
    //    if(!isLocalPlayer)
    //        return;

    //    hud.battleRequestScript.IncomingBattleRequest(trainerName, otherTrainerNetId);
    //}
    //[ClientRpc] public void RpcRequestAcceted(string trainersName)
    //{
    //    if(!isLocalPlayer)
    //        return;

    //    hud.battleRequestScript.RequestAccepted(trainersName);
    //}
    //[ClientRpc] public void RpcRequestDenied(string trainersName)
    //{
    //    if(!isLocalPlayer)
    //        return;

    //    hud.battleRequestScript.RequestDenied(trainersName);
    //}
    //[ClientRpc] public void RpcInitTrainerBattle(NetworkInstanceId opponent)
    //{
    //    Trainer otherTrainer = ClientScene.FindLocalObject(opponent).GetComponent<Trainer>();

    //    inBattle = true;
    //    this.opponent = otherTrainer;

    //    if(pokemon)
    //    {
    //        pokemon.inBattle = true;

    //        if(otherTrainer.pokemon)
    //        {
    //            pokemon.enemy = otherTrainer.pokemon.gameObject;

    //            if(isLocalPlayer)
    //                hud.enemyPokemonPortrait.SetTargetPokemon(otherTrainer.pokemon.gameObject);
    //        }
    //    }
    //}
    //#endregion

    public void NextSlot()
    {
        selectedRosterSlot = selectedRosterSlot == PokemonRoster.Count - 1 ? 0 : selectedRosterSlot + 1;
    }
    public void LastSlot()
    {
        selectedRosterSlot = selectedRosterSlot > 0 ? selectedRosterSlot - 1 : PokemonRoster.Count - 1;
    }
    public void RecallPokemon()
	{
        components.controller.canMove = false;
		transform.LookAt(pokemon.gameObject.transform);
        components.anim.Return(true);
	}
    public void ActivateReturnBall()
	{
		returnBall.gameObject.SetActive(true);

		StartCoroutine(PokemonReturn());
	}
	public void DeactivateReturnBall()
	{
		returnBall.gameObject.SetActive(false);
	}
    public void Capture(Vector3 target)
    {
        components.controller.canMove = false;
        transform.LookAt(target);
        components.anim.ThrowEmptyBall(true);
	}
    //[Command] public void CmdRequestTrainerBattle(NetworkInstanceId otherTrainerNetId)
    //{
    //    NetworkServer.FindLocalObject(otherTrainerNetId).GetComponent<Trainer>().RpcIncomingBattleRequest(TrainersName, netId);
    //}
    //[Command] public void CmdAcceptBattleRequest(NetworkInstanceId otherTrainerNetId)
    //{
    //    NetworkServer.FindLocalObject(otherTrainerNetId).GetComponent<Trainer>().RpcRequestAcceted(TrainersName);
    //    NetworkServer.FindLocalObject(otherTrainerNetId).GetComponent<Trainer>().RpcInitTrainerBattle(netId);
    //    RpcInitTrainerBattle(otherTrainerNetId);
    //}
    //[Command] public void CmdDeclineBattleRequest(NetworkInstanceId otherTrainerNetId)
    //{
    //    NetworkServer.FindLocalObject(otherTrainerNetId).GetComponent<Trainer>().RpcRequestDenied(TrainersName);
    //}
    //[Command] public void CmdInitWildPokemonBattle(NetworkInstanceId netId)
    //{
    //    GameObject wildPokemon = NetworkServer.FindLocalObject(netId);

    //    pokemon.enemy = NetworkServer.FindLocalObject(netId);
    //    pokemon.inBattle = true;
    //    pokemon.RpcSetEnemy(netId);

    //    //wildPokemon.GetComponent<Pokemon_AI>().target = activePokemon.gameObject;
    //    wildPokemon.GetComponent<Pokemon>().inBattle = true;
    //    wildPokemon.GetComponent<Pokemon>().enemy = pokemon.gameObject;
    //    //wildPokemon.GetComponent<Pokemon_AI>().worldState = Pokemon_AI.WorldStates.Battle;
    //}
    //#endregion

	private void GetStatsBack()
	{
		PokemonHPPP hpPP = pokemon.components.hpPP;
		PokemonStats stats = pokemon.components.stats;

		PokemonData data = new PokemonData(pokemon.pokemonName, pokemon.nickname, pokemon.equippedItem, (int)pokemon.gender, (int)pokemon.nature, pokemon.level, hpPP.curMaxHP, hpPP.curMaxPP,
            stats.curMaxATK, stats.curMaxDEF, stats.curMaxSPATK, stats.curMaxSPDEF, stats.curMaxSPD, hpPP.curHP, hpPP.curPP, stats.curATK, stats.curDEF, stats.curSPATK, stats.curSPDEF, stats.curSPD,
            hpPP.hpEV, hpPP.ppEV, stats.atkEV, stats.defEV, stats.spatkEV, stats.spdefEV, stats.spdEV, hpPP.hpIV, hpPP.ppIV, stats.atkIV, stats.defIV, stats.spatkIV, stats.spdefIV, stats.spdIV, 
            pokemon.curEXP, pokemon.id, pokemon.fromTrade);

        int index = PokemonRoster.FindIndex(x => x.id == data.id);
		PokemonRoster[index] = data;
	}

    private IEnumerator PokemonReturn()
	{
		if(localPlayer)
			GetStatsBack();

        returnBall.audioS.Play();

		yield return new WaitForSeconds(1.0f);
		
		returnBall.target = pokemon.gameObject;
		returnBall.lineRenderer.enabled = true;

//		if(localPlayer)
//			pokemon.RpcBeingCaptured();

		yield return new WaitForSeconds(1.0f);

        //		Vector3 scale = Vector3.zero;
        //
        //		while(Vector3.Distance(trainer.activePokemon.gameObject.transform.localScale, scale) > 0.1f)
        //		{
        //			trainer.activePokemon.gameObject.transform.localScale = Vector3.Lerp(trainer.activePokemon.gameObject.transform.localScale, scale, Time.deltaTime * 5.0f);
        //			yield return null;
        //		}

        DarkRiftAPI.SendMessageToAll(TagIndex.Controller, TagIndex.ControllerSubjects.DestroyPokemon, "Hi");

		returnBall.target = null;

		yield return new WaitForSeconds(1.5f);

		returnBall.lineRenderer.enabled = false;

		if(localPlayer)
			RemovePokemon();

        components.input.FinishedReturning();

		//if(isServer && inBattle && opponent)
		//{
		//	bool allDead = true;

		//	for(int i = 0; i < PokemonRoster.Count; i++)
		//	{
		//		if(PokemonRoster[i].curHP > 0)
		//			allDead = false;
		//	}

		//	if(allDead)
		//	{
		//		canBattle = false;
		//		RpcEndTrainerBattle(false);
		//		opponent.RpcEndTrainerBattle(true);
		//	}
		//}

		yield return null;
	}
}
public enum TrainerColors { BLUE, GREEN, PURPLE, RED, YELLOW }
