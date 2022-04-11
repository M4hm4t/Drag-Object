using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    [SerializeField]
    private Transform hexagonPlace;
    private Vector2 initialPosion;
    private float deltaX, deltaY;
    public static bool locked;
    private void Start()
    {
        initialPosion = transform.position;
    }
    private void Update()
    {
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - hexagonPlace.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - hexagonPlace.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(hexagonPlace.position.x, hexagonPlace.position.y);
                        locked = true;
                    }
                    else
                    {
                        transform.position = new Vector2(initialPosion.x, initialPosion.y);
                    }
                    break;
            }

        }
    }
}
