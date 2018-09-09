using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {


    Camera myCamera;

	void Start () {
        myCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Vector2 worldPos = SnapToGrid(CalculateWorldPointOfMouseClick());
        Instantiate(Button.selectedDefender, worldPos, Quaternion.identity);
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
