using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{

    public Texture2D crosshairTexture;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void OnGUI()
    {
        var mousePos = Event.current.mousePosition;
        GUI.DrawTexture(new Rect(mousePos.x - (crosshairTexture.width / 2),
                        mousePos.y - (crosshairTexture.height / 2),
                        crosshairTexture.width,
                        crosshairTexture.height), crosshairTexture);
    }
}
