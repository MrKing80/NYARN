using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemPlacement : MonoBehaviour
{
    [SerializeField] private GameObject[] items = default;
    private GameObject childObject = default;
    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, 6);
        childObject = Instantiate(items[i], transform.position, Quaternion.identity);
        childObject.transform.parent = transform.parent;
    }

    // Update is called once per frame
}
