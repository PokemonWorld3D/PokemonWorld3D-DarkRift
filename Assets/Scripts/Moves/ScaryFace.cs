using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScaryFace : Move
{
	public GameObject scaryFace;
	public Image face;
	public Debuff speedDown = new Debuff
	{
		type = Debuff.Types.SpdDown,
		percentage = 0.50f,
		duration = 10.0f
	};
	
	public ScaryFace()
	{
		ResetMoveData("Scary Face", "The user frightens the target with a scary face to harshly lower its speed temporarily.", false, false, false, false, false, PokemonTypes.NORMAL,
			MoveCategories.STATUS, 0.0f, 0);
	}
	public void StartScaryFace()
	{
        components.pokemon.CannotMove();
        face.CrossFadeAlpha(1.0f, 0.0f, false);
		scaryFace.SetActive(true);
		components.audioS.PlayOneShot(soundEffect);
	}
	public void ScaryFaceEffect()
	{
        if(!GameManager.instance.isServer)
            return;

		Collider[] cols = Physics.OverlapSphere(gameObject.transform.position, range);
		
		for(int i = 0; i < cols.Length; i++)
		{
			if(cols[i].gameObject == components.pokemon.enemy)
			{
				PokemonComponents targetComponents = cols[i].GetComponent<PokemonComponents>();

				if(!targetComponents.buffsDebuffs.Debuffs.Contains(speedDown))
				{
					targetComponents.buffsDebuffs.Debuffs.Add(speedDown);
					targetComponents.stats.AdjSpeed(speedDown.percentage);

                    Networking.StatModMessage(targetComponents.pokemon, this, StatType.SPEED, false);
				}
			}
		}
	}
}