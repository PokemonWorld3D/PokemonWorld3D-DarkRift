using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SFXScaryFace : MonoBehaviour
{
	[SerializeField] private float time = 1.5f;

    private Image scaryFace;
	private float timer;

    void Awake()
    {
        scaryFace = transform.FindChild("Canvas").FindChild("Image").GetComponent<Image>();
    }
	void Update()
	{
		scaryFace.CrossFadeAlpha(0.0f, time, false);
		timer += Time.deltaTime;

		if(timer >= time)
		{
			timer = 0.0f;
			gameObject.SetActive(false);
		}
	}
}
