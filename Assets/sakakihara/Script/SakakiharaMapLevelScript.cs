using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakakiharaMapLevelScript : MonoBehaviour
{
    //���ō�������x��

   [SerializeField] private int mapLevel;
    public static int MAPLevel;

    private void Awake()
    {
        mapLevel = 0;

    }
    void Update()
    {
        MAPLevel = mapLevel;
    }
}
