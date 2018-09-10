using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public static GameObject selectedDefender;
    [SerializeField] GameObject defenderPrefab;
    [SerializeField] bool isSelected = false;
    Button[] allButtons;

    public static GameObject defenderParent;

	void Start ()
    {
        allButtons = FindObjectsOfType<Button>();

        UnSelectAll();

        FindParent();

    }

    private void FindParent()
    {
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }

    private void UnSelectAll()
    {
        if (isSelected)
        {
            Select();
        }
        else
        {
            UnSelect();
        }
    }

    public void UnSelect(){
        isSelected = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }

    public void Select()
    {
        isSelected = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        Button.selectedDefender = defenderPrefab;
    }

    private void OnMouseDown()
    {
        foreach(Button button in allButtons)
        {
            button.UnSelect();
        }
        Select();
    }
}
