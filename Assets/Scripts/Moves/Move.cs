using UnityEngine;
using System.Collections;

[System.Serializable]
public class Move : MonoBehaviour
{
    [HideInInspector] public string moveName, description;
    [HideInInspector] public bool recoil, highCritRate, flinch, contact, disabled, critHit, activeMove;
    [HideInInspector] public PokemonTypes type = PokemonTypes.NONE;
    [HideInInspector] public MoveCategories category = MoveCategories.NONE;
    [HideInInspector] public int basePower, curPower;
    [HideInInspector] public float recoilDamage;
    [HideInInspector] public AudioClip soundEffect;

    public float coolDownTime, coolDownTimer, range;
    public int levelLearned, ppCost;

    public PokemonComponents components { get; private set; }
    public Sprite icon { get; private set; }

    public virtual void Awake()
    {
        components = GetComponent<PokemonComponents>();
        icon = Resources.Load<Sprite>("Sprites/Move Icons/" + moveName);
        soundEffect = Resources.Load("Audio/Moves/" + moveName) as AudioClip;
    }
    void Update()
    {
        if(coolDownTimer > 0.0f)
        {
            coolDownTimer -= Time.deltaTime;

            if(coolDownTimer < 0.0f)
            {
                coolDownTimer = 0.0f;

                if(!activeMove)
                    enabled = false;
            }
        }
    }

    public void PowerIncrease(float modifier)
    {
        curPower = (int)(curPower + (basePower * modifier));
    }
    public void PowerDecrease(float modifier)
    {
        curPower = (int)(curPower - (basePower * modifier));
    }
    public void ResetMoveData(string moveName, string description, bool recoil, bool highCritRate, bool flinch, bool contact, bool disabled, PokemonTypes type, MoveCategories category,
        float recoilDamage, int power)
    {
        this.moveName = moveName;
        this.description = description;
        this.recoil = recoil;
        this.highCritRate = highCritRate;
        this.flinch = flinch;
        this.contact = contact;
        this.disabled = disabled;
        this.type = type;
        this.category = category;
        this.recoilDamage = recoilDamage;
        this.basePower = power;
        this.curPower = this.basePower;
    }
    public void ResetMoveValues()
    {
        //pkmnLevel = components.pokemon.level;
        //pkmnATK = components.stats.curATK;
        //pkmnSPATK = components.stats.curSPATK;
        //pkmnBaseSpeed = components.pokemon.baseSPD;
        //pkmnTypeOne = components.pokemon.typeOne;
        //pkmnTypeTwo = components.pokemon.typeTwo;
        critHit = false;
    }
}
public enum MoveCategories { NONE, PHYSICAL, SPECIAL, STATUS}