using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dress : MonoBehaviour
{
    public enum dress_colors {green, blue, red, yellow, black, purple, orange};
    public dress_colors dress_color = dress_colors.green;

    public Sprite dress_green;
    public Sprite dress_blue;
    public Sprite dress_red;
    public Sprite dress_yellow;
    public Sprite dress_black;
    public Sprite dress_purple;
    public Sprite dress_orange;

    Sprite dress;
    // Start is called before the first frame update
    void Start()
    {
        switch(dress_color)
        {
            case dress_colors.green:
                dress = dress_green;
                break;
            case dress_colors.blue:
                dress = dress_blue;
                break;
            case dress_colors.red:
                dress = dress_red;
                break;
            case dress_colors.yellow:
                dress = dress_yellow;
                break;
            case dress_colors.black:
                dress = dress_black;
                break;
            case dress_colors.purple:
                dress = dress_purple;
                break;
            case dress_colors.orange:
                dress = dress_orange;
                break;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = dress;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
