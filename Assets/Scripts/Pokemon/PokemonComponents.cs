using UnityEngine;
using System.Collections;

public class PokemonComponents : MonoBehaviour
{
    public Pokemon pokemon { get; private set; }
    public PokemonHPPP hpPP { get; private set; }
    public PokemonStats stats { get; private set; }
    public PokemonConditions conditions { get; private set; }
    public PokemonBuffsDebuffs buffsDebuffs { get; private set; }
    public PokemonInput input { get; private set; }
    public PokemonAnimationController anim { get; private set; }
    public Transform cameraFocus { get; private set; }
    public AudioSource audioS { get; private set; }
    public AudioListener audioL { get; private set; }
    public new Rigidbody rigidbody { get; private set; }
    public new CapsuleCollider collider { get; private set; }
    public Animator animator { get; private set; }

    void Awake()
    {
        pokemon = GetComponent<Pokemon>();
        hpPP = GetComponent<PokemonHPPP>();
        stats = GetComponent<PokemonStats>();
        conditions = GetComponent<PokemonConditions>();
        buffsDebuffs = GetComponent<PokemonBuffsDebuffs>();
        input = GetComponent<PokemonInput>();
        anim = GetComponent<PokemonAnimationController>();
        cameraFocus = transform.FindChild("Camera Focus");
        audioS = GetComponent<AudioSource>();
        audioL = GetComponent<AudioListener>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.Sleep();
        collider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
    }
}
