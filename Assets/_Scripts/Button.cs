using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    [SerializeField] bool isSelected = false;
    Button[] allButtons;

	void Start () {
        allButtons = FindObjectsOfType<Button>();
        if(!isSelected)
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }
	
    public void UnSelect(){
        isSelected = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }

    public void Select()
    {
        isSelected = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
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
