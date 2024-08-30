using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript: MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject TeleObj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector2(TeleObj.transform.position.x, TeleObj.transform.position.y - 5);
        }
    }
}
