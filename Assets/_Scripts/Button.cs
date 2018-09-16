using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public static GameObject selectedDefender;
    [SerializeField] GameObject defenderPrefab;
    [SerializeField] bool isSelected = false;
    Button[] allButtons;

    private Text costText;

    public static GameObject defenderParent;

	void Start ()
    {
        allButtons = FindObjectsOfType<Button>();
        UnSelectAll();
        FindParent();
        SetCostText();

    }

    private void SetCostText()
    {
        costText = GetComponentInChildren<Text>();
        if(costText){
            costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
        } else {
            Debug.LogWarning(name + " has no costText");
        }
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
