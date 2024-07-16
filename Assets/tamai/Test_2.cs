using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestDataBase", menuName = "testData/test")]
public class Test_2 : ScriptableObject
{
    [SerializeField] private List<ScritbleOBJ> testLists = new();

    public List<ScritbleOBJ> GetLists() // アイテムリストを返す
    {
        return testLists;
    }
}
