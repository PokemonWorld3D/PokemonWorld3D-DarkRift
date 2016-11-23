using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveIcon : MonoBehaviour
{
	private Move move;
    private Image border, icon, timer;
    private Text pp;
	private Color[] MoveTypes;

    void Awake()
    {
        border = GetComponent<Image>();
        icon = transform.FindChild("Move Icon").GetComponent<Image>();
        timer = icon.transform.FindChild("Cool Down Timer").GetComponent<Image>();
        pp = timer.transform.FindChild("PP").GetComponent<Text>();
        MoveTypes = new Color[19];
        MoveTypes[0] = Color.white;
        MoveTypes[1] = new Color(168, 183, 32);
        MoveTypes[2] = new Color(112, 88, 72);
        MoveTypes[3] = new Color(112, 56, 248);
        MoveTypes[4] = new Color(247, 207, 48);
        MoveTypes[5] = new Color(237, 152, 171);
        MoveTypes[6] = new Color(191, 48, 40);
        MoveTypes[7] = new Color(239, 147, 48);
        MoveTypes[8] = new Color(168, 144, 240);
        MoveTypes[9] = new Color(112, 88, 152);
        MoveTypes[10] = new Color(120, 200, 80);
        MoveTypes[11] = new Color(223, 191, 104);
        MoveTypes[12] = new Color(151, 215, 215);
        MoveTypes[13] = new Color(167, 167, 119);
        MoveTypes[14] = new Color(159, 64, 159);
        MoveTypes[15] = new Color(247, 88, 135);
        MoveTypes[16] = new Color(183, 159, 86);
        MoveTypes[17] = new Color(183, 183, 207);
        MoveTypes[18] = new Color(104, 143, 209);
    }
    void Update()
	{
		if(move.coolDownTime > 0.0f)
			timer.fillAmount = move.coolDownTimer / move.coolDownTime;
		else
			timer.fillAmount = 0.0f;
	}

	public void SetupIcon(Move move)
	{
		this.move = move;
		border.color = MoveTypes[(int)move.type];
		icon.sprite = move.icon;
		timer.fillAmount = move.coolDownTimer / move.coolDownTime;
		pp.text = move.ppCost.ToString();
	}
}

