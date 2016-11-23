using DarkRift;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Trainer localPlayer;
    public bool isServer;
    public TrainerData trainerData;

    [System.Serializable] public struct TrainerData
    {
        public string username;
        public string trainername;
        public Genders gender;
        public TrainerColors color;
        public int funds;
        public string lastZone;
        public Vector3 lastPosition;
        public List<PokemonData> Pokemon;
    }

    [SerializeField] private HUD hud;
    [SerializeField] private Text loadingProgress;
    [SerializeField] private GameObject[] TrainerPrefabs;

    private string serverIP = "127.0.0.1";
    private AsyncOperation async = null;
    private TrainerComponents components;
    private Vector3 lastPosition;
    private Quaternion lastRotation;

    void OnApplicationQuit()
    {
        if(DarkRiftAPI.isConnected)
            DarkRiftAPI.Disconnect();
    }
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(hud.gameObject);
    }
    void Update()
    {
        if(DarkRiftAPI.isConnected)
            DarkRiftAPI.Receive();
    }

    public IEnumerator JoinServer(Text messageText)
    {
        hud.loadingPanel.SetActive(true);
        hud.gameObject.SetActive(true);

        int port = 4296;

        if(trainerData.lastZone == "Pallet Town")
            port = PortIndex.PalletTown;
        else if(trainerData.lastZone == "Route One")
            port = PortIndex.RouteOne;

        DarkRiftAPI.Connect(serverIP, port);

        if(DarkRiftAPI.isConnected)
            DarkRiftAPI.onDataDetailed += ReceiveData;
        else
			messageText.text = "Failed to connect to the server!";

        StopCoroutine(JoinServer(messageText));

        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        async = SceneManager.LoadSceneAsync(trainerData.lastZone);

        while(!async.isDone)
        {
            loadingProgress.text = (async.progress * 100.0f).ToString() + "%";
            yield return null;
        }
    }

    private void ReceiveData(ushort senderID, byte tag, ushort subject, object data)
    {
        if(tag == TagIndex.Controller)
        {
            if(subject == TagIndex.ControllerSubjects.JoinMessage)
                DarkRiftAPI.SendMessageToID(senderID, TagIndex.Controller, TagIndex.ControllerSubjects.SpawnPlayer, localPlayer.transform.position);

            if(subject == TagIndex.ControllerSubjects.SpawnPlayer)
            {
                GameObject clone = Instantiate(TrainerPrefabs[(int)trainerData.color], (Vector3)data, Quaternion.identity) as GameObject;

                clone.GetComponent<Trainer>().networkID = senderID;

                if(senderID == DarkRiftAPI.id)
                {
                    localPlayer = clone.GetComponent<Trainer>();
                    localPlayer.localPlayer = true;
                    localPlayer.Init(trainerData);
                }
            }
        }
        if(tag == TagIndex.Chat)
        {
            if(subject == TagIndex.ChatSubjects.MainChat)
                    hud.AddToMainChat((string)data);
            if(subject == TagIndex.ChatSubjects.BattleChat)
                    hud.AddToBattleChat((string)data);
        }
    }
    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        hud.loadingPanel.SetActive(false);

        if(DarkRiftAPI.isConnected)
        {
            DarkRiftAPI.SendMessageToOthers(TagIndex.Controller, TagIndex.ControllerSubjects.JoinMessage, "hi");
            DarkRiftAPI.SendMessageToAll(TagIndex.Controller, TagIndex.ControllerSubjects.SpawnPlayer, trainerData.lastPosition);
        }
        else
            Debug.LogWarning("There is no connection to the server right now.");

        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
}