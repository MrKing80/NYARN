using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    [SerializeField, Header("HPを入れるところだよ〜")] private int playerHp;
    private int maxHP = 3;    //復帰した時のHPを入れる

    [SerializeField, Header("ゲームオーバーテキスト入れるところだよ〜")] private TMP_Text gameOverUi;

    [SerializeField, Header("ゲームオーバーテキスト入れるところだよ〜")] private GameObject continueUi;

    //無敵かどうか
    private bool isInvincible = false;

    //切り替え時間
    private float flgChangeTime = 1.5f;

    private float intarval = 1.0f;

    //カウント時間
    private float countTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gameOverUi.enabled = false;

        continueUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHp <= 0)
        {
            gameOverUi.enabled = true;
        }

        if (gameOverUi.enabled)
        {
            countTime += Time.deltaTime;

            if(intarval <= countTime)
            {
                Time.timeScale = 0;

                gameOverUi.enabled = false;
                countTime = 0f;
                continueUi.SetActive(true);

            }
            playerHp = +maxHP;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //敵に触れたとき
        if (collision.gameObject.CompareTag("Enemy") && !isInvincible)
        {
            playerHp--;
            print("HIT!");
            isInvincible = true;
            StartCoroutine(NoHpDecreasesTime());
        }
    }

    private IEnumerator NoHpDecreasesTime()
    {
        yield return new WaitForSeconds(flgChangeTime);
        isInvincible = false;
    }

    //private IEnumerator GoToContinue()
    //{
    //    yield return new WaitForSeconds(1.0f);
    //    SceneManager.LoadScene("ContinuationScenes");
    //}
}
