using DarkRift;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PW3DServer : MonoBehaviour
{
    //The server IP (world/server) to connect to.
    [SerializeField] private string serverIP = "127.0.0.1";
    //The server port (map/room) to connect to.
    [SerializeField] private int port = 4296;

    //The GameObject we instantiate when a player joins.
    [SerializeField] private GameObject playerPrefab;

    //The players spawned on this server addressed by their ID.
    Dictionary<ushort, Trainer> Players = new Dictionary<ushort, Trainer>();

    void Start()
    {
        DarkRiftAPI.onData += TrainerBattle;
        ConnectionService.onPlayerConnect += OnPlayerConnect;
    }     
    
    private void TrainerBattle(byte tag, ushort subject, object data)
    {
        //What type of TrainerBattle message is this?
        if(subject == TagIndex.TrainerBattleSubjects.Request)
        {
            //Check to see if target trainer can battle.
            if(Players[(ushort)data].CanBattle)
            {
                //Send a message to the target trainer to request the battle.
            }
            else
            {
                //Send a message back to the requesting trainer that the target trainer is unavailable for battle.
            }
        }
    }
    private void OnPlayerConnect(ConnectionService con)
    {
        
    }  
}