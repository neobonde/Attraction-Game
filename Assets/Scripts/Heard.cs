using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heard : MonoBehaviour
{

    public bool stop;
    public float speed = 6;
    public bool enemy = true;
    
    Transform mTransform;
    Vector3 mMousePosition;
    float distance;
    Vector2 direction;
    Vector3 translation;
    Rigidbody2D mRigidbody;
    Transform mTargetTransform;

    // Start is called before the first frame update
    void Start()
    {
        mTransform = gameObject.transform;
        mRigidbody = gameObject.GetComponent<Rigidbody2D>();
        mTargetTransform = GameObject.FindGameObjectWithTag("Target").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if( !stop){
            translation = Vector3.zero;
            if(Input.GetMouseButton(0))
            {
                mMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                distance = Vector2.Distance(mMousePosition,mTransform.position);
                direction = (mMousePosition - mTransform.position);
                direction.Normalize();
                if (distance < 10f){
                    // mRigidbody.MovePosition(mTransform.position + Vector3.ClampMagnitude(direction* Time.deltaTime * -speed/Mathf.Exp(distance),0.035f));
                    translation += Vector3.ClampMagnitude(direction* Time.deltaTime * -speed/Mathf.Exp(distance),0.035f);
                    // translation = Vector3.ClampMagnitude(direction* Time.deltaTime * -speed/distance,0.035f);
                    // mTransform.Translate(translation);   
                    // Debug.Log("direction: "+ direction + " distance: " + -speed/distance + " exp: " + -speed/Mathf.Exp(distance)); // " translate mag: " + trans.magnitude);
                }
            }
            if(enemy){
                direction = (mTargetTransform.position - mTransform.position);
                direction.Normalize();
                translation += (Vector3)direction * Time.deltaTime * speed/20;
                // mRigidbody.MovePosition(mTransform.position + (Vector3)direction * Time.deltaTime * speed/20);   
            }
            mRigidbody.MovePosition(mTransform.position + translation);
        }
    }
}