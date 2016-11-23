using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private Text messageText, usernameText, passwordText, regNameText, regUsernameText, regPassText, regConfPassText, regEmailText, regConfEmailText, trainernameText;
    [SerializeField] private Text[] CharacterButtonTexts;
    [SerializeField] private GameObject logInPanel, registerPanel, trainerPanel, trainerModel, creationPanel;
    [SerializeField] private GameObject[] CreateButtons, CharacterButtons;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Material[] Colors;

    private int color;
    private SkinnedMeshRenderer trainerRenderer;

    void Awake()
    {
        trainerRenderer = trainerModel.GetComponentInChildren<SkinnedMeshRenderer>();
    }

    public void Register()
    {
        messageText.text = string.Empty;

        if(string.IsNullOrEmpty(regNameText.text) || string.IsNullOrEmpty(regUsernameText.text) || string.IsNullOrEmpty(regPassText.text) || string.IsNullOrEmpty(regConfPassText.text)
            || string.IsNullOrEmpty(regEmailText.text) || string.IsNullOrEmpty(regConfEmailText.text))
            messageText.text = "Please complete all fields.";
        else
        {
            if(regPassText.text == regConfPassText.text && regEmailText.text == regConfEmailText.text)
            {
                WWWForm form = new WWWForm();
                form.AddField("name", regNameText.text);
                form.AddField("username", regUsernameText.text);
                form.AddField("password", regPassText.text);
                form.AddField("email", regEmailText.text);
                WWW w = new WWW("http://pokemonworld3d.dx.am/pw3dregister.php", form);
                StartCoroutine(Register(w));
            }
            else if(regPassText.text != regConfPassText.text)
                messageText.text = "Your passwords do not match.";
            else if(regEmailText.text != regConfEmailText.text)
                messageText.text = "Your e-mail addresses do not match.";
        }
    }
    public void LogIn()
	{
		messageText.text = string.Empty;
		
		if (string.IsNullOrEmpty(usernameText.text) || string.IsNullOrEmpty(passwordText.text))
		    messageText.text = "Please complete all fields.";
		else
		{
			WWWForm form = new WWWForm();
			form.AddField("username", usernameText.text);
			form.AddField("userpassword", passwordText.text);
			WWW w = new WWW("http://pokemonworld3d.dx.am/pw3dlogin.php", form);
			StartCoroutine(LogIn(w));
		}
	}
    public void CreateCharacter()
	{
        messageText.text = string.Empty;
		
		if(string.IsNullOrEmpty(trainernameText.text))
            messageText.text = "Please complete all fields.";
		else
		{
			WWWForm form = new WWWForm();
			form.AddField("username", usernameText.text);
			form.AddField("trainername", trainernameText.text);
            form.AddField("color", color);
			WWW w = new WWW("http://pokemonworld3d.dx.am/pw3dcreatetrainer.php", form);
			StartCoroutine(CreateCharacter(w, usernameText.text));
		}
	}
    public void ChangeColor(int color)
    {
        this.color = color;
        trainerRenderer.material = Colors[this.color];
    }
	public void SelectCharacter(Text text)
	{
        WWWForm form = new WWWForm();
        form.AddField("trainername", text.text);
        WWW w = new WWW("http://pokemonworld3d.dx.am/pw3dgettrainerinfo.php", form);
		StartCoroutine(SelectCharacter(w, text.text));
	}

    private IEnumerator Register(WWW w)
	{
		yield return w;

		if(w.error == null)
        {
            registerPanel.SetActive(false);
            logInPanel.SetActive(true);
            messageText.text = w.text;
        }
		else
            messageText.text = "ERROR: " + w.error;
	}
    private IEnumerator LogIn(WWW w)
	{
		yield return w;
		if (w.error == null)
		{
			if (w.text == "Log in successful!")
			{
				logInPanel.SetActive(false);
				trainerPanel.SetActive(true);

                WWWForm form = new WWWForm();
                form.AddField("username", usernameText.text);
                WWW ww = new WWW("http://pokemonworld3d.dx.am/pw3dgetuserstrainers.php", form);
				StartCoroutine(CharacterSelection(ww));
			}
			else
				messageText.text = w.text;
		}
		else
            messageText.text = "ERROR: " + w.error;
	}
    private IEnumerator CharacterSelection(WWW w)
	{
		yield return w;
		
		foreach(GameObject go in CreateButtons)
			go.SetActive(true);
		foreach(GameObject go in CharacterButtons)
			go.SetActive(false);
		
		string[] CharacterNames = w.text.Split(',');

		for(int c = 0; c < CharacterNames.Length; c++)
		{
			CreateButtons[c].SetActive(false);
			CharacterButtons[c].SetActive(true);
			CharacterButtonTexts[c].text = CharacterNames[c];
		}
	}
    private IEnumerator CreateCharacter(WWW w, string username)
	{
		yield return w;

		messageText.text = w.text;

        WWWForm form = new WWWForm();
        form.AddField("username", usernameText.text);
        WWW ww = new WWW("http://pokemonworld3d.dx.am/pw3dgetuserstrainers.php" + username);

        trainerModel.SetActive(false);
        creationPanel.SetActive(false);
		trainerPanel.SetActive(true);
		StartCoroutine(CharacterSelection(ww));
	}
	private IEnumerator SelectCharacter(WWW w, string trainername)
	{
		yield return w;

		if(w.text == "That character doesn't exist!")
		{
            messageText.text = w.text;
		}
		else
		{
            string[] results = w.text.Split(',');

            gameManager.trainerData = new GameManager.TrainerData();
            gameManager.trainerData.username = results[0];
            gameManager.trainerData.trainername = results[1];
            gameManager.trainerData.gender = (Genders)int.Parse(results[2]);
            gameManager.trainerData.color = (TrainerColors)int.Parse(results[3]);
            gameManager.trainerData.funds = int.Parse(results[4]);
            gameManager.trainerData.lastZone = results[5];
            gameManager.trainerData.lastPosition.x = float.Parse(results[6]);
            gameManager.trainerData.lastPosition.y = float.Parse(results[7]);
            gameManager.trainerData.lastPosition.z = float.Parse(results[8]);

            WWWForm form = new WWWForm();
            form.AddField("trainername", trainername);
            WWW ww = new WWW("http://pokemonworld3d.dx.am/pw3dgettrainerspokemon.php", form);
		    StartCoroutine(DownloadPokemon(ww, trainername));
        }
	}
    private IEnumerator DownloadPokemon(WWW w, string trainername)
    {
        yield return w;

        if(w.text == trainername + " has no Pokemon.")
        {
            StartCoroutine(gameManager.JoinServer(messageText));
            gameObject.SetActive(false);
        }
        else
        {
            gameManager.trainerData.Pokemon = new List<PokemonData>();

            string[] results = w.text.Split('!');
            string[][] ModifiedResults = new string[results.Length - 1][];

            for(int i = 0; i < results.Length - 1; i++)
            {
                ModifiedResults[i] = new string[37];
                ModifiedResults[i] = results[i].Split(',');
            }

            for(int x = 0; x < ModifiedResults.Length - 1; x++)
            {
                PokemonData data = new PokemonData();
                data.pokemonName = ModifiedResults[x][0];
                data.nickname = ModifiedResults[x][1];
                data.equippedItem = ModifiedResults[x][2];
                int.TryParse(ModifiedResults[x][3], out data.gender);
                int.TryParse(ModifiedResults[x][4], out data.nature);
                int.TryParse(ModifiedResults[x][5], out data.level);
                int.TryParse(ModifiedResults[x][6], out data.curMaxHP);
                int.TryParse(ModifiedResults[x][7], out data.curMaxPP);
                int.TryParse(ModifiedResults[x][8], out data.curMaxATK);
                int.TryParse(ModifiedResults[x][9], out data.curMaxDEF);
                int.TryParse(ModifiedResults[x][10], out data.curMaxSPATK);
                int.TryParse(ModifiedResults[x][11], out data.curMaxSPDEF);
                int.TryParse(ModifiedResults[x][12], out data.curMaxSPD);
                int.TryParse(ModifiedResults[x][13], out data.curHP);
                int.TryParse(ModifiedResults[x][14], out data.curPP);
                int.TryParse(ModifiedResults[x][15], out data.curATK);
                int.TryParse(ModifiedResults[x][16], out data.curDEF);
                int.TryParse(ModifiedResults[x][17], out data.curSPATK);
                int.TryParse(ModifiedResults[x][18], out data.curSPDEF);
                int.TryParse(ModifiedResults[x][19], out data.curSPD);
                int.TryParse(ModifiedResults[x][20], out data.hpEV);
                int.TryParse(ModifiedResults[x][21], out data.ppEV);
                int.TryParse(ModifiedResults[x][22], out data.atkEV);
                int.TryParse(ModifiedResults[x][23], out data.defEV);
                int.TryParse(ModifiedResults[x][24], out data.spatkEV);
                int.TryParse(ModifiedResults[x][25], out data.spdefEV);
                int.TryParse(ModifiedResults[x][26], out data.spdEV);
                int.TryParse(ModifiedResults[x][27], out data.hpIV);
                int.TryParse(ModifiedResults[x][28], out data.ppIV);
                int.TryParse(ModifiedResults[x][29], out data.atkIV);
                int.TryParse(ModifiedResults[x][30], out data.defIV);
                int.TryParse(ModifiedResults[x][31], out data.spatkIV);
                int.TryParse(ModifiedResults[x][32], out data.spdefIV);
                int.TryParse(ModifiedResults[x][33], out data.spdIV);
                int.TryParse(ModifiedResults[x][34], out data.curEXP);
                int fromTrade = 0;
                data.fromTrade = int.TryParse(ModifiedResults[x][35], out fromTrade) ? false : true;
                int slot;
                data.id = int.TryParse(ModifiedResults[x][36], out slot) ? 0 : slot;

                gameManager.trainerData.Pokemon.Add(data);
            }

            StartCoroutine(gameManager.JoinServer(messageText));
            gameObject.SetActive(false);
        }
    }

 //   public void CreateBulbasaurStarter()
	//{
 //       //starter = Instantiate(bulbasaurPrefab, transform.position, transform.rotation) as GameObject;
 //       //Pokemon bulbasaur = starter.GetComponent<Pokemon>();
 //       //bulbasaur.level = 5;
 //       //bulbasaur.nickname = string.IsNullOrEmpty(nicknameText.text) ? string.Empty : nicknameText.text;
 //       //bulbasaur.equippedItem = string.Empty;
 //       //bulbasaur.slot = 0;
 //       //bulbasaur.SetupPokemonFirstTime();
 //       //PokemonData starterData = new PokemonData(bulbasaur.pokemonName, bulbasaur.nickname, bulbasaur.equippedItem, (int)bulbasaur.gender, (int)bulbasaur.nature, bulbasaur.level,
 //       //    bulbasaur.components.hpPP.curMaxHP, bulbasaur.components.hpPP.curMaxPP, bulbasaur.components.stats.curMaxATK, bulbasaur.components.stats.curMaxDEF,
 //       //    bulbasaur.components.hpPP.curMaxPP, bulbasaur.components.stats.curMaxSPDEF, bulbasaur.components.stats.curMaxSPD, bulbasaur.components.hpPP.curHP,
 //       //    bulbasaur.components.hpPP.curPP, bulbasaur.components.stats.curATK, bulbasaur.components.stats.curDEF, bulbasaur.components.stats.curSPATK, bulbasaur.components.stats.curSPDEF,
 //       //    bulbasaur.components.stats.curSPD, 0, 0, 0, 0, 0, 0, 0, bulbasaur.components.hpPP.hpIV, bulbasaur.components.hpPP.ppIV, bulbasaur.components.stats.atkIV,
 //       //    bulbasaur.components.stats.defIV, bulbasaur.components.stats.spatkIV, bulbasaur.components.stats.spdefIV, bulbasaur.components.stats.spdIV, bulbasaur.curEXP, 0, false);
 //       //netManager.starterData = starterData;
 //       //LogIn();
 //       messageText.text = "We're sorry, but Bulbasaur is currently unavailable for selection.";
	//}
	//public void CreateCharmanderStarter()
	//{
	//	starter = Instantiate(charmanderPrefab, transform.position, transform.rotation) as GameObject;
	//	Pokemon charmander = starter.GetComponent<Pokemon>();
	//	charmander.level = 5;
 //       charmander.nickname = string.IsNullOrEmpty(nicknameText.text) ? string.Empty : nicknameText.text;
 //       charmander.equippedItem = string.Empty;
	//	charmander.slot = 0;
 //       charmander.SetupPokemonFirstTime();
 //       PokemonData starterData = new PokemonData(charmander.pokemonName, charmander.nickname, charmander.equippedItem, (int)charmander.gender, (int)charmander.nature, charmander.level,
 //           charmander.components.hpPP.curMaxHP, charmander.components.hpPP.curMaxPP, charmander.components.stats.curMaxATK, charmander.components.stats.curMaxDEF,
 //           charmander.components.hpPP.curMaxPP, charmander.components.stats.curMaxSPDEF, charmander.components.stats.curMaxSPD, charmander.components.hpPP.curHP,
 //           charmander.components.hpPP.curPP, charmander.components.stats.curATK, charmander.components.stats.curDEF, charmander.components.stats.curSPATK, charmander.components.stats.curSPDEF,
 //           charmander.components.stats.curSPD, 0, 0, 0, 0, 0, 0, 0, charmander.components.hpPP.hpIV, charmander.components.hpPP.ppIV, charmander.components.stats.atkIV,
 //           charmander.components.stats.defIV, charmander.components.stats.spatkIV, charmander.components.stats.spdefIV, charmander.components.stats.spdIV, charmander.curEXP, 0, false);
	//	connectionManager.starterData = starterData;
	//	LogIn();
	//}
	//public void CreateSquirtleStarter()
	//{
 //       //starter = Instantiate(squirtlePrefab, transform.position, transform.rotation) as GameObject;
 //       //Pokemon squirtle = starter.GetComponent<Pokemon>();
 //       //squirtle.level = 5;
 //       ////squirtle.nickName = string.IsNullOrEmpty(nicknameText.text) ? string.Empty : nicknameText.text;
 //       //squirtle.equippedItem = string.Empty;
 //       //squirtle.slot = 0;
 //       //      squirtle.SetupPokemonFirstTime();
 //       //      PokemonData starterData = new PokemonData(squirtle.pokemonName, squirtle.nickname, squirtle.equippedItem, (int)squirtle.gender, (int)squirtle.nature, squirtle.level,
 //       //          squirtle.components.hpPP.curMaxHP, squirtle.components.hpPP.curMaxPP, squirtle.components.stats.curMaxATK, squirtle.components.stats.curMaxDEF,
 //       //          squirtle.components.hpPP.curMaxPP, squirtle.components.stats.curMaxSPDEF, squirtle.components.stats.curMaxSPD, squirtle.components.hpPP.curHP,
 //       //          squirtle.components.hpPP.curPP, squirtle.components.stats.curATK, squirtle.components.stats.curDEF, squirtle.components.stats.curSPATK, squirtle.components.stats.curSPDEF,
 //       //          squirtle.components.stats.curSPD, 0, 0, 0, 0, 0, 0, 0, squirtle.components.hpPP.hpIV, squirtle.components.hpPP.ppIV, squirtle.components.stats.atkIV,
 //       //          squirtle.components.stats.defIV, squirtle.components.stats.spatkIV, squirtle.components.stats.spdefIV, squirtle.components.stats.spdIV, squirtle.curEXP, 0, false);
 //       //netManager.starterData = starterData;
 //       //LogIn();
 //       messageText.text = "We're sorry, but Squirtle is currently unavailable for selection.";
 //   }


	//public void MouseEnterPokeBall(Image pokeBall)
	//{
	//	pokeBall.color = transparentColor;
	//}
	//public void MouseExitPokeBall(Image pokeBall)
	//{
	//	pokeBall.color = defaultColor;
	//}
}
