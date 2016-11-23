using DarkRift;
using UnityEngine;
using System.Collections;

public class PokemonAnimationController : MonoBehaviour
{
    private PokemonComponents components;

    void Awake()
    {
        components = GetComponent<PokemonComponents>();
    }

    public void Stop()
    {
        components.animator.SetFloat("Speed", 0.0f);
        Networking.SerialiseAnimFloat(TagIndex.PokemonUpdate, TagIndex.PokemonUpdateSubjects.AnimatorFloat, "Speed", 0.0f);
    }
    public void Walk()
    {
        components.animator.SetFloat("Speed", 1.0f);
        Networking.SerialiseAnimFloat(TagIndex.PokemonUpdate, TagIndex.PokemonUpdateSubjects.AnimatorFloat, "Speed", 1.0f);
    }
    public void Run()
    {
        components.animator.SetFloat("Speed", 2.0f);
        Networking.SerialiseAnimFloat(TagIndex.PokemonUpdate, TagIndex.PokemonUpdateSubjects.AnimatorFloat, "Speed", 2.0f);
    }
    public void Jump(bool value)
    {
        components.animator.SetBool("Jump", value);
        Networking.SerialiseAnimBool(TagIndex.PokemonUpdate, TagIndex.PokemonUpdateSubjects.AnimatorBool, "Jump", value);
    }
    public void Fall()
    {
        components.animator.SetBool("Falling", true);
        Networking.SerialiseAnimBool(TagIndex.PokemonUpdate, TagIndex.PokemonUpdateSubjects.AnimatorBool, "Falling", true);
    }
    public void Land()
    {
        components.animator.SetBool("Falling", false);
        Networking.SerialiseAnimBool(TagIndex.PokemonUpdate, TagIndex.PokemonUpdateSubjects.AnimatorBool, "Falling", false);
    }
    public void Battle(bool value)
    {
       components.animator.SetBool("In Battle", value);
       Networking.SerialiseAnimBool(TagIndex.PokemonUpdate, TagIndex.PokemonUpdateSubjects.AnimatorBool, "In Battle", value);
    }
    public void KnockedOut(bool value)
    {
       components.animator.SetBool("Dead", value);
       Networking.SerialiseAnimBool(TagIndex.PokemonUpdate, TagIndex.PokemonUpdateSubjects.AnimatorBool, "Dead", value);
    }
    public void Attacking(string moveName, bool value)
    {
       components.animator.SetBool(moveName, value);
       Networking.SerialiseAnimBool(TagIndex.PokemonUpdate, TagIndex.PokemonUpdateSubjects.AnimatorBool, moveName, value);
    }

    public void PerformJump()
    {
        if(components.pokemon.Trainer.networkID == DarkRiftAPI.id)
            components.pokemon.Trainer.components.controller.JumpTransition();
    }
}
