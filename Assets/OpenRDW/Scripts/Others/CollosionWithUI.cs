using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;

public class CollisionWithUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionStay(Collision collision)
    {
        if (Input.anyKey)
        {
            transform.GetComponent<Button>().onClick.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
