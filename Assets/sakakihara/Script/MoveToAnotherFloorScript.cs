using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAnotherFloorScript : MonoBehaviour
{

    //FirstFloorなど階段前につけるスクリプト
    //ほかの階に移動

    [SerializeField] GameObject player;//プレイヤー
    [SerializeField] GameObject minMap;//  ミニマップ

    [Header("階層と出現場所")]
    [SerializeField] GameObject firstFloorMap1;//一階
    [SerializeField] GameObject spawnPos1;//一階出現場所

    [SerializeField] GameObject secondFloorMap2;//二階
    [SerializeField] GameObject spawnPos2;//一階出現場所
    private void Start()
    {
        secondFloorMap2.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (this.tag == ("FirstFloor")) //自分が一階だったら
            {
                firstFloorMap1.SetActive(false);
                minMap.SetActive(false);
                Invoke(nameof(MoveToTheSecondFloor),1f);//1秒後に表示
            }

            if (this.tag == ("SecondFloor")) //自分が一階だったら
            {
                secondFloorMap2.SetActive(false);
                minMap.SetActive(false);
                Invoke(nameof(MoveToTheFirstFloor), 1f);//1秒後に表示
            }
        }
    }
    void MoveToTheSecondFloor()//2階を表示
    {
        minMap.SetActive(true);
        secondFloorMap2.SetActive(true);
        player.transform.position = spawnPos2.transform.position;//プレイヤーを2階に移動
    }
    void MoveToTheFirstFloor()//1階を表示
    {
        minMap.SetActive(true);
        firstFloorMap1.SetActive(true);
        player.transform.position = spawnPos1.transform.position;//プレイヤーを2階に移動
    }
}
