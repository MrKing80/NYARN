using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAnotherFloorScript : MonoBehaviour
{

    //FirstFloorなど階段前につけるスクリプト
    //ほかの階に移動
    [Header("プレイヤー")]
    [SerializeField] GameObject player;//プレイヤー
    [Header("ミニマップ達（MinMaps）")]
    [SerializeField] GameObject minMap;//  ミニマップ
    [Header("読み込み背景（LoadingBackground）")]
    [SerializeField] GameObject loadingBackground;//読み込み背景
    private float loadingTime = 0.5f;//読み込み時間

    [Header("階層と出現場所")]
    [Header("一階")]
    [SerializeField] GameObject firstFloorMap1;//一階
    [SerializeField] GameObject spawnPos1;//一階出現場所
    [Header("二階")]
    [SerializeField] GameObject secondFloorMap2;//二階
    [SerializeField] GameObject spawnPos2;//一階出現場所

    private void Start()
    {
        loadingBackground.SetActive(false);//読み込み画面非表示
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.SetActive(false);//プレイヤー非表示

        if (collision.CompareTag("Player"))
        {
            if (this.tag == ("FirstFloor")) //自分が一階だったら
            {
                firstFloorMap1.SetActive(false);//マップ非表示
                minMap.SetActive(false);//ミニマップ非表示

                loadingBackground.SetActive(true);//読み込み画面表示

                Invoke(nameof(MoveToTheSecondFloor), loadingTime);//1秒後に表示
            }

            if (this.tag == ("SecondFloor")) //自分が2階だったら
            {
                secondFloorMap2.SetActive(false);//マップ非表示
                minMap.SetActive(false);//ミニマップ非表示

                loadingBackground.SetActive(true);//読み込み画面表示

                Invoke(nameof(MoveToTheFirstFloor), loadingTime);//1秒後に表示
            }
        }
    }

    private void MoveToTheSecondFloor()//2階を表示
    {
        player.SetActive(true);//プレイヤー表示
        player.transform.position = spawnPos2.transform.position;//プレイヤーを2階に移動

        minMap.SetActive(true);//ミニマップを表示
        secondFloorMap2.SetActive(true);//1階を表示

        loadingBackground.SetActive(false);//読み込み画面非表示
    }

    private void MoveToTheFirstFloor()//1階を表示
    {
        player.SetActive(true);//プレイヤー表示
        player.transform.position = spawnPos1.transform.position;//プレイヤーを1階に移動

        minMap.SetActive(true);//ミニマップを表示
        firstFloorMap1.SetActive(true);//1階を表示

        loadingBackground.SetActive(false);//読み込み画面非表示
    }
}
