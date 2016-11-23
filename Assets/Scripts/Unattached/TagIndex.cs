using UnityEngine;
using System.Collections;

// We reccomend that for each project you keep tags and subjects in a class to make
// your life simpler. Here's how we usually do it:

public class TagIndex
{
	public const int Controller = 0;		//For controller ralated things (think creating new players etc)
	public const int PlayerUpdate = 1;		//For player changing things like change of animation/position/rotation etc
    public const int PokemonUpdate = 2;     //For changing Pokemon data
    public const int Items = 3;
    public const int TrainerBattle = 4;     //For requesting/accepting/declining battles with other players'
    public const int Chat = 5;

	// By the way, there's no problem with using enums for the following,
	// it's just casting can be confusing so we dont.

	public class ControllerSubjects
    {
		public const int JoinMessage = 0;			//Tells everyone we've joined and need to know who's there.
		public const int SpawnPlayer = 1;			//Tell people to spawn a new player for us.
        public const int SpawnPokemon = 2;          //Tell people to spawn a Pokemon.'
        public const int DestroyPokemon = 3;
	}
	public class PlayerUpdateSubjects
    {
		public const int Position = 0;		    //Move the player to (Vector3)Data
		public const int Rotation = 1;		    //Rotate the player to (Quaternion)Data
        public const int AnimatorFloat = 2;     //Update one of the animator's floats (AnimatorFloat)Data
        public const int AnimatorBool = 3;      //Update one of the animator's bools (AnimatorBool)Data
	}
    public class PokemonUpdateSubjects
    {
        public const int Position = 0;		    //Move the pokemon to (Vector3)Data
		public const int Rotation = 1;		    //Rotate the pokemon to (Quaternion)Data
        public const int AimHead = 2;
        public const int AnimatorFloat = 3;     //Update one of the animator's floats (AnimatorFloat)Data
        public const int AnimatorBool = 4;      //Update one of the animator's bools (AnimatorBool)Data
        public const int AdjustHP = 5;
    }
    public class ItemSubjects
    {
        public const int PokemonBalls = 0;
    }
    public class TrainerBattleSubjects
    {
        public const int Request = 0;       //Request a battle
        public const int Accept = 1;        //Accept a request
        public const int Decline = 2;       //Decline a request
    }
    public class ChatSubjects
    {
        public const int MainChat = 0;
        public const int ClanChat = 1;
        public const int PMChat = 2;
        public const int TradeChat = 3;
        public const int BattleChat = 4;
    }
}