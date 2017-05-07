using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    public Texture2D crosshairTexture;
<<<<<<< HEAD
=======
    public int crosshairWidth = 3;
    public int crosshairHeight = 3;
>>>>>>> 0d60e099eaaf923084403c783f48bfab63dafc7d

    void Start()
    {
        Cursor.visible = false;
<<<<<<< HEAD
        Cursor.lockState = CursorLockMode.Confined;
=======
>>>>>>> 0d60e099eaaf923084403c783f48bfab63dafc7d
    }

    void OnGUI()
    {
<<<<<<< HEAD
=======
        ///crosshairTexture.width = crosshairWidth;
        ///crosshairTexture.height = crosshairHeight;
>>>>>>> 0d60e099eaaf923084403c783f48bfab63dafc7d
        Debug.Log(crosshairTexture.width);
        Debug.Log(crosshairTexture.height);
        var mousePos = Event.current.mousePosition;
        GUI.DrawTexture(new Rect(mousePos.x - (crosshairTexture.width / 2),
                        mousePos.y - (crosshairTexture.height / 2),
                        crosshairTexture.width,
                        crosshairTexture.height), crosshairTexture);
    }
}
