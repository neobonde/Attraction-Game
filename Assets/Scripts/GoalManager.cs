using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{

    GameObject LevelManager;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager = GameObject.Find("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        object[] tempStorage = new object[2];
        tempStorage[0] = other;
        tempStorage[1] = transform;
        LevelManager.SendMessage("GoalEntered",tempStorage);
    }


}
