using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTest : MonoBehaviour
{
    [SerializeField] private Test_2 testLists;
    [SerializeField] [Range(0, 2)] private int range;

    void Update()
    {
        range = Random.Range(0, 3);
        Debug.Log(testLists.GetLists()[range].COUNT);
        Debug.Log(testLists.GetLists()[range].MSG);
    }
}
