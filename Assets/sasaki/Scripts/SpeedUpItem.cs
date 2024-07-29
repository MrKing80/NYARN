using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{
    private PlayerMove move = default;
    private GameObject player = default;
    private float buffTime = 3f;
    [SerializeField] private float magnification = 3.9f;
    private float tmpSpeed = 0;
    private float initialSpeed = default;
    private bool isTouch = false;
    private bool isGet = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        if (isTouch && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            move = player.GetComponent<PlayerMove>();
            initialSpeed = move.SpeedProperty;
            tmpSpeed = move.SpeedProperty * magnification;
            print(tmpSpeed);
            move.SpeedProperty = tmpSpeed;
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<CircleCollider2D>().enabled = false;
            isGet = true;
        }
        
        if(isGet)
        {
            buffTime -= Time.deltaTime;
            print(buffTime);

            if(buffTime <= 0)
            {
                move.SpeedProperty = initialSpeed;
                player = null;
                isGet = false;
                buffTime = 3f;
            }
        }

        print(isGet);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouch = true;
            player = collision.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isTouch = false;
        }
    }
}
