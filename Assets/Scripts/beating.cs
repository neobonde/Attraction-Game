using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beating : MonoBehaviour
{

    Vector3 velocityBeat = Vector3.zero;
    Vector3 ScaleGoal; 
    Vector3 StartSize; 
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

        StartSize = transform.localScale;
    }

    int beatState = 0;

    // Update is called once per frame
    void Update()
    {
        switch (beatState)
        {
            case 0:
                ScaleGoal = StartSize * 1.2f;
                velocityBeat = Vector3.zero;
                beatState = 1;
                break;

            case 1:
                transform.localScale = Vector3.SmoothDamp(transform.localScale, ScaleGoal, ref velocityBeat, 0.05f*speed);
                if (Mathf.Abs(transform.localScale.x - ScaleGoal.x) < 0.05)
                {
                    beatState = 2;
                }
                break;
            case 2:
                ScaleGoal = transform.localScale * 5f/6f;
                velocityBeat = Vector3.zero;
                beatState = 3;
                break;
            case 3:
                transform.localScale = Vector3.SmoothDamp(transform.localScale, ScaleGoal, ref velocityBeat, 0.5f*speed);
                if (Mathf.Abs(transform.localScale.x - ScaleGoal.x) < 0.05)
                {
                    beatState = 0;
                }
                break;

        }
        
    }
}
