using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHolder : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            col.transform.parent = gameObject.transform;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            col.transform.parent = null;
        }
    }
}
