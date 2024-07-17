using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = default;

    private Rigidbody2D rig = default;

    private float inputX = 0f;
    private float inputY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal") * speed;
        inputY = Input.GetAxisRaw("Vertical") * speed;

        //rig.velocity = new Vector2(inputX, inputY) * Time.deltaTime;
        #region//テスト用
        
        if (inputX > 0)
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else if(inputX < 0)
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        if(inputY > 0)
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if(inputY < 0)
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }

        #endregion

        this.transform.position += (new Vector3(inputX, inputY) * Time.deltaTime);
    }

   
}
