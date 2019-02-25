using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spash : MonoBehaviour
{

    public bool first = false;
    public spash next;
    public string sceneName;

    float alphaVelocity = 0;
    float alpha = 0;
    Color color;

    Image image;

    bool go = false;

    Vector3 velocityScale = Vector3.zero;
    Vector3 ScaleGoal; 
    Vector3 StartSize; 


    // Start is called before the first frame update
    void Start()
    {
        go = first;
        image = gameObject.GetComponent<Image>();
        color = image.color;
        color.a = 0;
        image.color = color;
    }


    public void start()
    {
        go = true;
    }

    int fadeState = 0;
    float lerpTime;
    // Update is called once per frame
    void Update()
    {
        if(go)
        {
            switch (fadeState)
            {
                case 0:
                    alphaVelocity = 0.0f;
                    fadeState = 1;
                    ScaleGoal = transform.localScale;
                    transform.localScale = 0.8f * transform.localScale;
                    break;

                case 1:
                    transform.localScale = Vector3.SmoothDamp(transform.localScale, ScaleGoal, ref velocityScale, 1f);
                    alpha = Mathf.SmoothDamp(image.color.a, 1.0f, ref alphaVelocity, 1f);
                    color.a = alpha;
                    image.color = color;
                    if (alpha > 0.99)
                    {
                        fadeState = 2;
                    }
                    break;
                case 2:
                    alphaVelocity = 0.0f;
                    fadeState = 3;
                    lerpTime = 0;
                    break;
                case 3:
                    lerpTime += 1f * Time.deltaTime;
                    alpha = Mathf.Lerp(1,0,lerpTime);
                    // alpha = Mathf.SmoothDamp(image.color.a, 0.0f, ref alphaVelocity, 0.5f);
                    color.a = alpha;
                    image.color = color;
                    if (alpha < 0.02)
                    {
                        fadeState = 4;
                    }
                    break;
                case 4:
                    go = false;
                    if(next != null)
                    {
                        next.start();
                        
                    }else{
                        if(sceneName != null)
                        {
                            Debug.Log("changing scene to: " + sceneName);
                            SceneManager.LoadScene(sceneName);
                        }
                    }
                    break;

            }
        }
    }
}
