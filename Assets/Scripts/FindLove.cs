using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindLove : MonoBehaviour
{
    Transform particles;
    // Start is called before the first frame update
    void Start()
    {
        particles = transform.Find("HeartParticles");
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Target");
        List<Dress.dress_colors> target_dress = new List<Dress.dress_colors>();
        Dress.dress_colors my_color = gameObject.GetComponent<Dress>().dress_color;
        foreach (var go in gos)
        {
            // Transform t = go.transform.Find("FemaleSprite");
            Dress d = go.GetComponentInChildren<Dress>();
            target_dress.Add(d.dress_color);
            // target_dress.Add(go.transform.Find("FemaleSprite").GetComponent<Dress>().dress_color);
        }
        // Dress.dress_colors target_dress = GameObject.Find("Target").transform.Find("FemaleSprite").GetComponent<Dress>().dress_color;
        particles.gameObject.SetActive(target_dress.Contains(my_color));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
