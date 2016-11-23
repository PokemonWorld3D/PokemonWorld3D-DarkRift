using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MovePanel : MonoBehaviour
{
    public Pokemon pokemon;

    [SerializeField] private GameObject movePrefab;

    private int iconDistance = 67;
    private RectTransform scrollPanel, activeMoveCenter;
    private List<GameObject> MoveIcons;
    private int activeMoveIndex;

    void Awake()
    {
        scrollPanel = transform.FindChild("Scroll Panel").GetComponent<RectTransform>();
        activeMoveCenter = transform.FindChild("Active Move Center").GetComponent<RectTransform>();
    }

	public void Setup()
	{
        if(pokemon.KnownMoves.Count == 0)
            return;

        MoveIcons = new List<GameObject>();

		for(int i = 0; i < pokemon.KnownMoves.Count; i++)
		{
			GameObject moveIcon = Instantiate(movePrefab) as GameObject;

			moveIcon.transform.SetParent(scrollPanel.transform);

			int x = i * iconDistance;
			Vector2 position = new Vector2(x, 2.0f);

			moveIcon.GetComponent<RectTransform>().anchoredPosition = position;
            moveIcon.GetComponent<MoveIcon>().SetupIcon(pokemon.KnownMoves[i]);

            MoveIcons.Add(moveIcon);
		}
	}
	public void Clear()
	{
		foreach(GameObject g in MoveIcons)
			Destroy(g);

		MoveIcons.Clear();
	}
	public void AddMove()
	{
		
	}
	public void UpdateActiveMove(int activeMoveIndex)
	{
		this.activeMoveIndex = activeMoveIndex;
		SnapToIcon(activeMoveIndex * -iconDistance);
	}
		
	private void SnapToIcon(int position)
	{
		Vector2 newPosition = new Vector2(position, scrollPanel.anchoredPosition.y);

		scrollPanel.anchoredPosition = newPosition;
	}
}
