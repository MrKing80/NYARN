using UnityEngine;
using UnityEngine.AI;

public class TamaiEnemyTest : MonoBehaviour
{
    // ナビメッシュ取得
    [SerializeField] private NavMeshAgent enemyNav;
    // 目的地オブジェ
    [SerializeField] private GameObject Destination;
    // ターゲットの位置を記録
    [SerializeField] private Vector3 targetPos = default;

    void Start()
    {
        enemyNav = GetComponent<NavMeshAgent>();
        //目的地のオブジェクトを取得
        Destination = GameObject.FindWithTag("Player");
        // 目的地の場所を渡す
        targetPos = Destination.transform.position;
        // 2D対応用らしい
        enemyNav.updateRotation = false;
        enemyNav.updateUpAxis = false;
        //目的地を設定
        enemyNav.SetDestination(targetPos);
    }

    private void FixedUpdate()
    {
        // 経路探索の準備ができているか、目標地点の間の距離が0.1f以上か
        if (enemyNav.pathPending || enemyNav.remainingDistance > 0.1f)
        {
            return;
        }
        // 目的地の場所を渡す
        targetPos = Destination.transform.position;
        //目的地を設定
        enemyNav.SetDestination(targetPos);
 }
}
