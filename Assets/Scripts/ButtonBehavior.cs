using UnityEngine;
using System.Collections;

public class ButtonBehavior : MonoBehaviour
{

    //if you want it private do:
    [SerializeField]
    Texture2D cursor;

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

}