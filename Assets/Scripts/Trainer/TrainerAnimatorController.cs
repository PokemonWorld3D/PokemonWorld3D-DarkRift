using DarkRift;
using UnityEngine;
using System.Collections;

public class TrainerAnimatorController : MonoBehaviour
{
    private TrainerComponents components;
  
    void Awake()
    {
        components = GetComponent<TrainerComponents>();
    }

    public void Stop()
    {
        components.animator.SetFloat("Speed", 0.0f);
        Networking.SerialiseAnimFloat(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.AnimatorFloat, "Speed", 0.0f);
    }
    public void Walk()
    {
        components.animator.SetFloat("Speed", 1.0f);
        Networking.SerialiseAnimFloat(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.AnimatorFloat, "Speed", 1.0f);
    }
    public void Run()
    {
        components.animator.SetFloat("Speed", 2.0f);
        Networking.SerialiseAnimFloat(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.AnimatorFloat, "Speed", 2.0f);
    }
    public void Jump(bool value)
    {
        components.animator.SetBool("Jump", value);
        Networking.SerialiseAnimBool(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.AnimatorBool, "Jump", value);
    }
    public void Fall()
    {
        components.animator.SetBool("Falling", true);
        Networking.SerialiseAnimBool(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.AnimatorBool, "Falling", true);
    }
    public void Land()
    {
        components.animator.SetBool("Falling", false);
        Networking.SerialiseAnimBool(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.AnimatorBool, "Falling", false);
    }
    public void Battle(bool value)
    {
       components.animator.SetBool("In Battle", value);
       Networking.SerialiseAnimBool(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.AnimatorBool, "In Battle", value);
    }
    public void ThrowEmptyBall(bool value)
    {
        components.animator.SetBool("Throw Empty Ball", value);
        Networking.SerialiseAnimBool(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.AnimatorBool, "Throw Empty Ball", value);
    }
    public void ThrowPokemonBall(bool value)
    {
        components.animator.SetBool("Throw Pokemon Ball", value);
        Networking.SerialiseAnimBool(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.AnimatorBool, "Throw Pokemon Ball", value);
    }
    public void Return(bool value)
    {
        components.animator.SetBool("Pokemon Return", value);
        Networking.SerialiseAnimBool(TagIndex.PlayerUpdate, TagIndex.PlayerUpdateSubjects.AnimatorBool, "Pokemon Return", value);
    }

    public void PerformJump()
    {
        if(components.trainer.networkID == DarkRiftAPI.id)
            components.controller.JumpTransition();
    }
}
