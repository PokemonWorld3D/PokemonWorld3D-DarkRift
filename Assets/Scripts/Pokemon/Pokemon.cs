using DarkRift;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pokemon : MonoBehaviour
{
    /*
     * 
     *  Go in and change any public variables to private with a SerializedField attribute if they only need getters.
     *  Any public variable that has a getter and a setter just leave public and get rid of getter/setter.
     *  Any private variable that has a getter and a setter make it public and delete the getter/setter.
     * 
     */

    public string pokemonName, description, abilityOne, abilityTwo;
    public int pokemonNumber, baseHP, basePP, baseATK, baseDEF, baseSPATK, baseSPDEF, baseSPD, baseEXP, hpEVYield, ppEVYield, atkEVYield, defEVYield, spatkEVYield, spdefEVYield, spdEVYield,
        captureRate, evolveLevel, lastReqEXP, curEXP, nextReqEXP;
    [Range(0.000f, 1f)]public float genderRatio;
    public PokemonTypes typeOne, typeTwo;
    public LevelRates levelRate;
    public Material[] OriginalMats, ShinyMats, CaptureMats;
    public GameObject[] Disable;
    public float maxWalkSpeed, runMultiplier, maxJumpHeight, gravity, colliderRadius;

    [HideInInspector] public ushort networkID;
    [HideInInspector] public string equippedItem, nickname, trainerName;
    [HideInInspector] public bool setup, shiny, fromTrade, attacking, fainting, captured, inBattle;
    [HideInInspector] public int id, level;
    [HideInInspector] public GameObject enemy;
    [HideInInspector] public HUD hud;
    [HideInInspector] public Move activeMove;
    [HideInInspector] public Genders gender;
    [HideInInspector] public Natures nature;

    public Trainer Trainer { get { return trainer; } set { trainer = value; } }
    public float CurWalkSpeed { get { return curWalkSpeed; } set { curWalkSpeed = value; } }
    public float CurJumpHeight { get { return curJumpHeight; } set { curJumpHeight = value; } }

    public Sprite avatar { get; private set; }
    public PokemonComponents components { get; private set; }
    public List<Move> KnownMoves { get; private set; }

    private Trainer trainer;
    private List<Move> LearnedMoves;
    private int activeMoveIndex;
    private float curWalkSpeed, curJumpHeight;
    private Vector3 lastPosition;
    private Quaternion lastRotation;

    void Awake()
    {
        avatar = Resources.Load<Sprite>("Sprites/Pokemon/" + pokemonName);
        components = GetComponent<PokemonComponents>();
        LearnedMoves = new List<Move>();
        GetComponents<Move>(LearnedMoves);
    }
    void Start()
    {
        DarkRiftAPI.onDataDetailed += ReceiveData;
        DarkRiftAPI.onPlayerDisconnected += PlayerDisconnected;
        curWalkSpeed = maxWalkSpeed;
        curJumpHeight = maxJumpHeight;
    }
    void Update()
    {
        if(DarkRiftAPI.isConnected)
            DarkRiftAPI.Receive();

        if(networkID == DarkRiftAPI.id)
        {
            if(transform.position != lastPosition)
                DarkRiftAPI.SendMessageToOthers(TagIndex.PokemonUpdate, TagIndex.PokemonUpdateSubjects.Position, transform.position);
            if(transform.rotation != lastRotation)
                DarkRiftAPI.SendMessageToOthers(TagIndex.PokemonUpdate, TagIndex.PokemonUpdateSubjects.Rotation, transform.rotation);

            lastPosition = transform.position;
            lastRotation = transform.rotation;
        }
    }

    public void CannotMove()
    {
        if(networkID == DarkRiftAPI.id)
            trainer.components.controller.canMove = false;
    }
    public void CanMove()
    {
        if(networkID == DarkRiftAPI.id)
            trainer.components.controller.canMove = true;
    }
    public void Attack()
    {
        if(components.hpPP.curPP >= activeMove.ppCost && activeMove.coolDownTimer == 0.0f)
        {
            components.anim.Attacking(activeMove.moveName, true);

            if(activeMove.coolDownTime != 0.0f)
                activeMove.coolDownTimer = activeMove.coolDownTime;

            attacking = true;
        }

    }
    public void DeductPP()
    {
        if(networkID == DarkRiftAPI.id)
        {
            components.hpPP.AdjCurPP(-activeMove.ppCost);

            if(components.hpPP.curPP < activeMove.ppCost || components.hpPP.curPP == 0)
                EndAttack();
        }

    }
    public void EndAttack()
    {
        components.anim.Attacking(activeMove.moveName, false);
        attacking = false;
    }
    public void AimHeadStart()
    {
        BroadcastMessage("HeadAim", true, SendMessageOptions.RequireReceiver);
    }
    public void AimHeadStop()
    {
        BroadcastMessage("HeadAim", false, SendMessageOptions.RequireReceiver);
    }
    public void NextMove()
    {
        if(activeMove.coolDownTimer == 0.0f)
            activeMove.enabled = false;

        activeMoveIndex = activeMoveIndex == KnownMoves.Count - 1 ? 0 : activeMoveIndex + 1;
        activeMove.activeMove = false;
        activeMove = KnownMoves[activeMoveIndex];
        activeMove.activeMove = true;
        activeMove.enabled = true;
        hud.playerPokemonPortrait.movePanelScript.UpdateActiveMove(this.activeMoveIndex);
    }
    public void LastMove()
    {
        if(activeMove.coolDownTimer == 0.0f)
            activeMove.enabled = false;

        activeMoveIndex = activeMoveIndex > 0 ? activeMoveIndex - 1 : KnownMoves.Count - 1;
        activeMove.activeMove = false;
        activeMove = KnownMoves[activeMoveIndex];
        activeMove.activeMove = true;
        activeMove.enabled = true;
        hud.playerPokemonPortrait.movePanelScript.UpdateActiveMove(this.activeMoveIndex);
    }

    private void ReceiveData(ushort senderID, byte tag, ushort subject, object data)
    {
        Debug.Log("senderID = " + senderID + ", networkID = " + networkID + ", tag = " + tag + ", subject = " + subject + ", data = " + data);
        if(senderID == networkID)
        {
            if(tag == TagIndex.Controller && subject == TagIndex.ControllerSubjects.DestroyPokemon)
                Destroy(gameObject);
            if(tag == TagIndex.PokemonUpdate)
            {
                if(subject == TagIndex.PokemonUpdateSubjects.Position)
                    transform.position = (Vector3)data;
                if(subject == TagIndex.PokemonUpdateSubjects.Rotation)
                    transform.rotation = (Quaternion)data;
                if(subject == TagIndex.PokemonUpdateSubjects.AnimatorFloat)
                    Networking.DeserialisePokemonAnimFloat(data, components.animator);
                if(subject == TagIndex.PokemonUpdateSubjects.AnimatorBool)
                    Networking.DeserialisePokemonAnimBool(data, components.animator);
            }
        }
    }
    private void PlayerDisconnected(ushort ID)
    {
        if (ID == networkID)
            Destroy(gameObject);
    }

    #region Setup Pokemon
    public void SetupPokemonFirstTime()    
    {
        System.Array natures = System.Enum.GetValues(typeof(Natures));
        nature = (Natures)natures.GetValue(UnityEngine.Random.Range(0, 24));

        components.hpPP.SetupFirstTime();
        components.stats.SetupFirstTime();

        if(components.stats.defIV == 10 && components.stats.spdIV == 10 && components.stats.spatkIV == 10)
        {
            if(components.stats.atkIV == 2 || components.stats.atkIV == 3 || components.stats.atkIV == 6 || components.stats.atkIV == 7 || components.stats.atkIV == 10 ||
                components.stats.atkIV == 11 || components.stats.atkIV == 14 || components.stats.atkIV == 15)
            {
                shiny = true;
                GetComponentInChildren<SkinnedMeshRenderer>().materials = ShinyMats;
            }
        }

        float rand = Random.Range(0.000f, 1f);

        if(rand > genderRatio)
            gender = Genders.FEMALE;
        else if(rand <= genderRatio)
            gender = Genders.MALE;

        if(genderRatio == 0.00f)
            gender = Genders.NONE;

        lastReqEXP = Calculations.CalculateCurrentXP(level - 1, levelRate);
        curEXP = Calculations.CalculateCurrentXP(level, levelRate);
        nextReqEXP = Calculations.CalculateRequiredXP(level, levelRate);

        if(trainer.networkID == DarkRiftAPI.id)
            SetupMoves();

        setup = true;
    }
    public void SetupExistingPokemon()
    {
        components.hpPP.SetupExisting();
        components.stats.SetupExisting();

        lastReqEXP = Calculations.CalculateCurrentXP(level - 1, levelRate);
        nextReqEXP = Calculations.CalculateRequiredXP(level, levelRate);

        captured = true;
        setup = true;

        if(networkID == DarkRiftAPI.id)
        {
            if(captured)
                hud = trainer.HUD;

            SetupMoves();
        }
    }
    #endregion

    public void SetupMoves()
    {
        KnownMoves = new List<Move>();

        for(int i = 0; i < LearnedMoves.Count; i++)
        {
            if(level >= LearnedMoves[i].levelLearned)
                KnownMoves.Add(LearnedMoves[i]);
        }

        if(KnownMoves.Count > 0)
        {
            activeMove = KnownMoves[0];
            activeMoveIndex = 0;
            activeMove.activeMove = true;
            activeMove.enabled = true;
        }

        if(captured && networkID == DarkRiftAPI.id)
            hud.playerPokemonPortrait.SetActivePokemon(this);
           
    }
    public void SetEnemy()
    {
        //enemy = ClientScene.FindLocalObject(_netId);

        if(networkID == DarkRiftAPI.id)
            hud.enemyPokemonPortrait.SetTargetPokemon(enemy);
    }
    public void EndBattle()
    {
        enemy = null;

        if(networkID == DarkRiftAPI.id)
            hud.enemyPokemonPortrait.RemoveTargetPokemon();


        inBattle = false;
        components.anim.Battle(false);
    }

    #region Coroutines
    public IEnumerator Faint()
    {
        inBattle = false;
        components.conditions.CancelInvoke();

        //if(!captured)
        //    GetComponent<Pokemon_AI>().worldState = Pokemon_AI.WorldStates.Dead;

        components.anim.KnockedOut(true);

        if(enemy.GetComponent<Pokemon>().captured)
        {
            Pokemon otherPokemon = enemy.GetComponent<Pokemon>();
            bool luckyEgg = false;

            if(otherPokemon.equippedItem == "Lucky Egg")
                luckyEgg = true;

            int increase = Calculations.AddExperience(captured, otherPokemon.fromTrade, baseEXP, luckyEgg, level, otherPokemon.level, otherPokemon.evolveLevel);

            yield return StartCoroutine(otherPokemon.IncreaseEXP(increase));

            if(!captured)
                enemy.GetComponent<Pokemon>().EndBattle();
        }

        yield return null;
    }
    public IEnumerator IncreaseEXP(int increase)
    {
        int target = curEXP + increase;
        float end = (float)target;
        float exp = (float)curEXP;

        while(curEXP != target)
        {
            exp = Mathf.MoveTowards(exp, end, 1.0f);
            curEXP = (int)exp;

            if(curEXP >= nextReqEXP)
            {
                level += 1;
                lastReqEXP = nextReqEXP;
                nextReqEXP = Calculations.CalculateRequiredXP(level, levelRate);
                components.hpPP.LevelUp();
                components.stats.LevelUp();

                if(trainer.networkID == DarkRiftAPI.id)
                    SetupMoves();
            }

            yield return null;
        }

        //if(level >= evolveLevel)
        //{
        //    //THIS NEEDS TO BE AN RPC INSTEAD
        //    StartCoroutine(EvolveStart());
        //}
    }
    #endregion
}
public enum PokemonTypes { NONE, BUG, DARK, DRAGON, ELECTRIC, FAIRY, FIGHTING, FIRE, FLYING, GHOST, GRASS, GROUND, ICE, NORMAL, POISON, PSYCHIC, ROCK, STEEL, WATER }
public enum LevelRates { NONE, ERRATIC, FAST, FLUCTUATING, MEDIUM_FAST, MEDIUM_SLOW, SLOW }
public enum Genders { NONE, FEMALE, MALE }
public enum Natures { NONE, ADAMANT, BASHFUL, BOLD, BRAVE, CALM, CAREFUL, DOCILE, GENTLE, HARDY, HASTY, IMPISH, JOLLY, LAX, LONELY, MILD, MODEST, NAIVE, NAUGHTY, QUIET, QUIRKY, RASH, RELAXED, SASSY,
SERIOUS, TIMID }
