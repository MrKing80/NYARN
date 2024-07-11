using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    [SerializeField] private ItemDataBase.ItemData itemData;
    [SerializeField] private string itemName = default; // ñºëO
    [SerializeField] private float weight = default; // èdÇ≥
    //éùÇøï®ä«óù
    List<ItemDataBase.ItemData> MotimonoList = new List<ItemDataBase.ItemData>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
