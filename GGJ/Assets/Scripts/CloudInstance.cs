using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudInstance : MonoBehaviour {

    // speed of the cloud
    public float Speed = 1.0f;
    public float MinFarSpeed = 3.0f;
    public float MaxFarSpeed = 4.0f;
    public float MinCloseSpeed = 0.5f;
    public float MaxCloseSpeed = 1.0f;
    public float MinMediumSpeed = 1.0f;
    public float MaxMediumSpeed = 2.0f;

    public static float MinScale = 0.1f;
    public static float MaxScale = 0.5f;

    public float LifeTime = 20.0f;

    // Use this for initialization
    void Start () {

        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        float scaleInterval = CloudInstance.MaxScale - CloudInstance.MinScale;
        if (transform.localScale.x < scaleInterval/3.0f)
        {
            Speed = Random.Range(MinCloseSpeed, MaxCloseSpeed);
            sr.sortingOrder = -2;
        }
        else if (transform.localScale.x > 2.0f * scaleInterval / 3.0f)
        {
            Speed = Random.Range(MinFarSpeed, MaxFarSpeed);
            sr.sortingOrder = -4;
        }
        else
        {
            Speed = Random.Range(MinMediumSpeed, MaxMediumSpeed);
            sr.sortingOrder = -3;
        }
        
        // destroy after 10 seconds
        Destroy(gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update () {
       transform.position = transform.position + new Vector3( Time.deltaTime, 0.0f) * Speed;
    }
}
