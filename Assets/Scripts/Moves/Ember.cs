﻿using UnityEngine;
using System.Collections;

public class Ember : Move
{
    public ParticleSystem ember;

    public Ember()
    {
        ResetMoveData("Ember", "The target is attacked with small flames. This may also leave the target with a burn.", false, false, false, false, false, PokemonTypes.FIRE,
            MoveCategories.SPECIAL, 0.0f, 40);
    }
    public void EmberStart()
    {
        components.pokemon.CannotMove();
        ResetMoveValues();

        components.audioS.clip = soundEffect;
        components.audioS.loop = true;
        components.audioS.Play();
        ember.Play();
    }
    public void EmberFinish()
    {
        ember.Stop();
        components.audioS.Stop();
    }
}