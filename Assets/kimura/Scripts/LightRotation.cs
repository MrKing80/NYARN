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
        ParentTrans = transform.parent;
        GetVision = ParentTrans.GetComponent<EnemyVisionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, GetVision.GetMyRotation);
    }
}
