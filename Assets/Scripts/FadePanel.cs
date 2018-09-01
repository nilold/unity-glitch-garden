using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{

    public float fadeTime = 3f;
    private Color currentColor = Color.white;

    Image fadePanel;

    // Use this for initialization
    void Start()
    {
        fadePanel = GetComponent<Image>();
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad < fadeTime){
            float alphaChange = Time.deltaTime / fadeTime;
            currentColor.a -= alphaChange;
            fadePanel.color = currentColor;
        } else{
            gameObject.SetActive(false);
        }

    }

}
