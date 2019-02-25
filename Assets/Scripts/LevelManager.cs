using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{

    public GameObject endScreen;
    public GameObject failedScreen;
    public GameObject tutorialScreen;
    public GameObject cursor;
    public Text time_label;
    public float timeMax = 60;
    public float score3Hearts = 70;
    public Sprite fullHeart;
    float startTime;

    bool levelRunning = true;
    float endTime;

    GameObject[] suiters;

    float score;
    float labelScore = 0;
    float heartScore = 0;
    float velocity = 0;
    float heartLerpTime = 0;

    Text scoreText;
    Image Heart1;
    Image Heart2;
    Image Heart3;

    int played = 0;

    // Start is called before the first frame update
    void Start()
    {
        endScreen.SetActive(false);
        endTime = 0;
        suiters = GameObject.FindGameObjectsWithTag("Suiter");
        startTime = Time.time;
        scoreText = endScreen.transform.Find("Score").GetComponent<Text>();
        Heart1 = endScreen.transform.Find("Hearts").Find("Heart1").GetComponent<Image>();
        Heart2 = endScreen.transform.Find("Hearts").Find("Heart2").GetComponent<Image>();
        Heart3 = endScreen.transform.Find("Hearts").Find("Heart3").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(levelRunning)
        {
            time_label.text = "Time: " + (Time.time - startTime).ToString(("0.0")) + " s";
        }
    
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            levelFailed();
        }


        if( endTime != 0 ){

            labelScore = Mathf.SmoothDamp(labelScore, score, ref velocity, 0.70f);
            scoreText.text = labelScore.ToString("0.00");
            
            if (Mathf.Abs(labelScore - score) < 0.01)
            {
                heartLerpTime += 0.01f * Time.deltaTime;
                heartScore = Mathf.Lerp(heartScore,score,heartLerpTime);
                
                // heartScore = Mathf.SmoothDamp(heartScore, score, ref velocityHearts, 3f);
                if (heartScore > score3Hearts/3)
                {
                    if( played == 0)
                    {
                        endScreen.transform.Find("Hearts").Find("Heart1").GetComponent<ClickSound>().playClip();
                        played ++;
                    }
                    Heart1.sprite = fullHeart;
                }
                if (heartScore > 2*score3Hearts/3)
                {
                    if( played == 1)
                    {
                        endScreen.transform.Find("Hearts").Find("Heart2").GetComponent<ClickSound>().playClip();
                        played ++;
                    }
                    Heart2.sprite = fullHeart;
                }
                if (heartScore > 3*score3Hearts/3)
                {
                    if ( played == 2)
                    {
                        endScreen.transform.Find("Hearts").Find("Heart3").GetComponent<ClickSound>().playClip();
                        played ++;
                    }
                    Heart3.sprite = fullHeart;              
                }
            }

        }

    }

    public void levelFailed()
    {
        failedScreen.SetActive(true);
        failedScreen.GetComponent<ClickSound>().playClip();

    }

    public void levelComplete(Collider2D other, Transform goal)
    {
            endScreen.GetComponent<ClickSound>().playClip();
            // gameObject.GetComponent<ClickSound>().playClip();
            endScreen.SetActive(true);
            levelRunning = false;
            float totalDistance = 0;
            foreach( GameObject suiter in suiters)
            {
                if (suiter != other.gameObject){
                    suiter.GetComponent<Heard>().stop = true;
                    totalDistance += Vector2.Distance(goal.position,suiter.transform.position);
                }
            }
            // Debug.Log(totalDistance);
            score = (timeMax - endTime) + totalDistance; 



            Debug.Log("Score: " + score);
    }

    public void GoalEntered(object[] package)
    {
        Collider2D other = (Collider2D) package[0];
        Transform goal = (Transform) package[1];
        if (endTime == 0)
        {

            GameObject[] gos = GameObject.FindGameObjectsWithTag("Tutorial");
            foreach (var go in gos)
            {
                go.SetActive(false);
            }

            time_label.gameObject.SetActive(false);
            if (tutorialScreen != null)
            {
                tutorialScreen.SetActive(false);
            }
            endTime = Time.time - startTime;
            cursor.GetComponent<Heart_Cursor>().stop = true;


            Dress.dress_colors female_dress = goal.parent.Find("FemaleSprite").GetComponent<Dress>().dress_color;
            // Dress.dress_colors female_dress = GameObject.Find("Target").transform.Find("FemaleSprite").GetComponent<Dress>().dress_color;
            Dress.dress_colors male_dress = other.GetComponent<Dress>().dress_color;

            if( female_dress == male_dress )
            {
                levelComplete(other, goal);
            }
            else
            {
                levelFailed(  );
            }
            

        }
    }
}
