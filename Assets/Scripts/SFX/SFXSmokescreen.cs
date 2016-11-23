using UnityEngine;
using System.Collections;

public class SFXSmokescreen : MonoBehaviour
{
	private Smokescreen move;
	private ParticleSystem smokescreen;
	private float lastTime;

	void Awake()
	{
		move = transform.root.GetComponent<Smokescreen>();
		smokescreen = GetComponent<ParticleSystem>();
	}
	void Update()
	{
		if(move.activeMove && move.components.pokemon.attacking)
		{
			if(Time.time - lastTime >= 1.0f)
			{
				move.components.pokemon.DeductPP();
				lastTime = Time.time;
			}
		}
	}
}
