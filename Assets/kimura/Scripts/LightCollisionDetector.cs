using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollisionDetector : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isDetecting = default;
    public bool ExistIsDetecting
    {
        get { return isDetecting; }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDetecting)
        {
            //print("ìñÇΩÇ¡ÇƒÇ»Ç¢Ç∫ÅB");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    isDetecting = true;
        //    print("ìñÇΩÇ¡ÇƒÇÈÇ∫ÅB");
        //}

       
    }
}
