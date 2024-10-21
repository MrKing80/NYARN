using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    // Start is called before the first frame update
    Transform ParentTrans;
    EnemyVisionScript GetVision;
    void Start()
    {
        //ParentTrans = transform.parent;
        GetVision = GetComponentInParent<EnemyVisionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //print("oooooo");
        //print(GetVision.GetMyRotation);
        transform.rotation = Quaternion.Euler(0, 0, GetVision._getMyRotation);
    }
}
