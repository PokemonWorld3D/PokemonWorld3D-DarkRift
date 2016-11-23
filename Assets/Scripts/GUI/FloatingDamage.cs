using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloatingDamage : MonoBehaviour
{
	[HideInInspector] public Color color;

    [SerializeField] private float scroll = 0.5f, duration = 0.5f, alpha = 1.0f;

    private Text text;

    void Awake()
    {
        text = transform.FindChild("Canvas").FindChild("Text").GetComponent<Text>();
    }
	void Update()
	{
//		if(alpha > 0)
//		{
			Vector3 curPos = transform.position;

			curPos.y += scroll * Time.deltaTime;
			transform.position = curPos;
//			alpha -= Time.deltaTime / duration;
//
//			Color curColor = theText.color;
//
//			curColor.a = alpha;
//			theText.color = color = curColor;
//		}
//		else
//			Destroy(gameObject);
	}

	public void AssignValues(Color color, string amount, bool crit)
	{
		text.color = color;
		text.text = amount;
		if(crit)
		{
			text.fontStyle = FontStyle.BoldAndItalic;
			text.fontSize = 18;
		}
	}
}
