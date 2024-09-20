using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 要修正
/// ゲームオーバースクリーンでｈｐが消えるようにしよう
/// </summary>

public class PlayerHPManage : MonoBehaviour
{
    public PlayerHP playerHP;
    public GameObject player;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public Sprite heare_1; // full
    public Sprite heare_2; // から

    private Image heartImage1;
    private Image heartImage2;
    private Image heartImage3;
    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetSceneByName("ContinuationScenes");
        playerHP = player.GetComponent<PlayerHP>();
        heartImage1 = heart1.GetComponent<Image>();
        heartImage2 = heart2.GetComponent<Image>();
        heartImage3 = heart3.GetComponent<Image>();
    }

void Update()
    {
        if (!scene.IsValid())
        {
             this.gameObject.SetActive(true);
        }
        else
        {
             this.gameObject.SetActive(false);
        }

        if (playerHP.playerHp <= 0)
        {
             this.gameObject.SetActive(false);

        }

        switch (playerHP.playerHp)
        {
            case 3:
                heartImage1.sprite = heare_1;
                heartImage2.sprite = heare_1;
                heartImage3.sprite = heare_1;

                break;

            case 2:
                heartImage1.sprite = heare_1;
                heartImage2.sprite = heare_1;
                heartImage3.sprite = heare_2;
                break;

            case 1:
                heartImage1.sprite = heare_1;
                heartImage2.sprite = heare_2;
                heartImage3.sprite = heare_2;
                break;

            default:

                break;
        }
    }
}
