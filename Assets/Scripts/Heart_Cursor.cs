using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Cursor : MonoBehaviour
{

    List<Transform> suiters;
    Transform closestSuiter;
    Transform sprite;
    SpriteRenderer spriteRenderer;
    public bool stop = false;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = transform.GetChild(0);
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
        suiters = new List<Transform>();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Suiter");
        foreach( GameObject go in gos)
        {
            Transform t = go.transform;
            suiters.Add(t);
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if( ! stop ){
            spriteRenderer.enabled = Input.GetMouseButton(0);
            Cursor.visible = ! Input.GetMouseButton(0);

            if (Input.GetMouseButtonDown(0))
            {
                gameObject.GetComponent<ClickSound>().playClip();
            }

            gameObject.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            closestSuiter = GetClosestTransform(suiters.ToArray());
            Quaternion q = lookTowards(closestSuiter.position);
            sprite.rotation = Quaternion.RotateTowards(sprite.rotation, q, 500 * Time.deltaTime); 
        }
        else{
            spriteRenderer.enabled = false;
            Cursor.visible = true;
        }
    }
    Transform GetClosestTransform(Transform[] transforms)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = base.transform.position;
        foreach (Transform t in transforms)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

    Quaternion lookTowards(Vector3 target){
        target.z = 0f;

        Vector3 objectPos = transform.position;
        target.x = target.x - objectPos.x;
        target.y = target.y - objectPos.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
