using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {


    Camera myCamera;
    StarDisplay starDisplay;

	void Start () {
        myCamera = FindObjectOfType<Camera>();
        starDisplay = FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        int starCost =  Button.selectedDefender.GetComponent<Defender>().starCost;
        if(starDisplay.UseStars(starCost) == StarDisplay.Status.SUCCESS){
            CreateNewDefnder();
        }
    }

    private void CreateNewDefnder()
    {
        GameObject defender = Button.selectedDefender;
        Vector2 worldPos = SnapToGrid(CalculateWorldPointOfMouseClick());
        Quaternion zeroRot = Quaternion.identity;
        GameObject newDefender = Instantiate(defender, worldPos, zeroRot);
        newDefender.transform.parent = Button.defenderParent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos){
        float roundX = Mathf.Round(rawWorldPos.x);
        float roundY = Mathf.Round(rawWorldPos.y);
        return new Vector2(roundX, roundY);
    }

    Vector2 CalculateWorldPointOfMouseClick(){

        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f; //doesnt metter

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPos;
    }

}
