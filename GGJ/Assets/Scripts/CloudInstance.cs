using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudInstance : MonoBehaviour {

    // speed of the cloud
    public float Speed = 1.0f;
    public float MinFarSpeed = 3.0f;
    public float MaxFarSpeed = 4.0f;
    public float MinCloseSpeed = 0.5f;
    public float MaxCloseSpeed = 10.75f;
    public float MinMediumSpeed = 1.0f;
    public float MaxMediumSpeed = 2.0f;

    public static float MinRangeLittleScale = 0.1f;
    public static float MaxRangeLittleScale = 0.2f;
    public static float MinRangeMediumScale = 0.21f;
    public static float MaxRangeMediumScale = 0.35f;
    public static float MinRangeBigScale = 0.36f;
    public static float MaxRangeBigScale = 0.5f;

    // Use this for initialization
    void Start () {

        if(transform.localScale.x < MinRangeMediumScale)
        {
            Speed = Random.Range(MinFarSpeed, MaxFarSpeed);
        }
        else if (transform.localScale.x > MaxRangeMediumScale)
        {
            Speed = Random.Range(MinCloseSpeed, MaxCloseSpeed);
        }
        else
        {
            Speed = Random.Range(MinMediumSpeed, MaxMediumSpeed);
        }
        
        // destroy after 10 seconds
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update () {
       transform.position = transform.position + new Vector3( Time.deltaTime, 0.0f) * Speed;
    }
}
