using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{

    Text starText;
    int starCount = 100;
    public enum Status { SUCCESS, FAILURE };

    // Use this for initialization
    void Start()
    {
        starText = GetComponent<Text>();
        starText.text = starCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddStars(int amount)
    {
        starCount += amount;
        starText.text = starCount.ToString();
    }

    public Status UseStars(int amount)
    {
        if (starCount >= amount)
        {
            starCount -= amount;
            starText.text = starCount.ToString();
            return Status.SUCCESS;
        }
        Debug.Log("Not enough star to spend.");
        return Status.FAILURE;
    }

}
