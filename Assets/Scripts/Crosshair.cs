using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    public Texture2D crosshairTexture;
<<<<<<< HEAD
=======
    public int crosshairWidth = 3;
    public int crosshairHeight = 3;
>>>>>>> origin/master

    void Start()
    {
        Cursor.visible = false;
<<<<<<< HEAD
        Cursor.lockState = CursorLockMode.Confined;
=======
>>>>>>> origin/master
    }

    void OnGUI()
    {
<<<<<<< HEAD
=======
        ///crosshairTexture.width = crosshairWidth;
        ///crosshairTexture.height = crosshairHeight;
>>>>>>> origin/master
        Debug.Log(crosshairTexture.width);
        Debug.Log(crosshairTexture.height);
        var mousePos = Event.current.mousePosition;
        GUI.DrawTexture(new Rect(mousePos.x - (crosshairTexture.width / 2),
                        mousePos.y - (crosshairTexture.height / 2),
                        crosshairTexture.width,
                        crosshairTexture.height), crosshairTexture);
    }
}
