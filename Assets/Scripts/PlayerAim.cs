using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAim : MonoBehaviour
{
    public Vector2 mousePos;

    public Rigidbody2D rb;
    public Camera cam;


    // Start is called before the first frame update
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

   
    void FixedUpdate()
    {

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        Debug.Log(angle);
        rb.rotation = angle;

    }
}
