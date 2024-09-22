using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

// やること、エネミーのトライアングルコライダーの調整

public class TamaiEnemyTest : MonoBehaviour
{
    // ナビメッシュ取得
    [SerializeField] private NavMeshAgent enemyNav;
    // 目的地オブジェ
    [SerializeField] private GameObject destination;
    [SerializeField] private PolygonCollider2D enemyLight;
    [SerializeField] private Vector3 MyVector;
    // ターゲットの位置を記録
    [SerializeField] private Vector3 targetPos = default;
    // 追いかけるかのスイッチ用
    [SerializeField] private bool isTarget = default;
    // 次の目的地
    [SerializeField] private int nextPoint;
    // 目的地を各自決めるためパブリック
    public Transform[] points;


    private void Start()
    {
        enemyNav = this.GetComponent<NavMeshAgent>();
        //目的地のオブジェクトを取得
        destination = GameObject.Find("Player");
        MyVector = this.gameObject.transform.position;
        enemyLight = this.GetComponent<PolygonCollider2D>();

        // 2D対応用らしい
        enemyNav.updateRotation = false;
        enemyNav.updateUpAxis = false;

        isTarget = false;
        //目的地を設定
        enemyNav.SetDestination(targetPos);
        // autoBraking を無効にすると、目標地点の間を継続的に移動します。エージェントは目標地点に近づいても速度をおとしません
        enemyNav.autoBraking = false;

        GotoNextPoint();
    }

    private void FixedUpdate()
    {
        // 目的地の場所を渡す
        targetPos = destination.transform.position;
    }

    private void Update()
    {
        if (!isTarget)
        {
            // エージェントが現目標地点に近づいてきたら、
            // 次の目標地点を選択します
            if (!enemyNav.pathPending && enemyNav.remainingDistance < 0.5f)
                GotoNextPoint();
        }
        else
        {
            print("isTarget_true");
            //目的地を設定
            enemyNav.SetDestination(targetPos);
            // 目的地の場所を渡す
            targetPos = destination.transform.position;
            Vector3 direction = targetPos - MyVector;
            float _targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }

        /*        // 目的地を見る
                // this.transform.LookAt(points[nextPoint].position);
                //上記の文は3D空間用なのですごい動きになります。LookAtは3D用
                Vector3 diff = (this.points[nextPoint].position - this.transform.position).normalized;
                this.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("OnEnter");
        // 触れたのがプレイヤーだったら
        if (other.gameObject.CompareTag("Player"))
        {
            print("OnEnter_Get");
            // isTriggerをtrue化
            isTarget = true;
        }
    }    
    
    private void OnTriggerExit2D(Collider2D other)
    {
        print("OnExit");
        // 抜けたのがプレイヤーだったら
        if (other.gameObject.CompareTag("Player"))
        {
            print("OnExit_Get");
            // isTriggerをtrue化
            isTarget = false;
        }
    }

    private void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返します
        if (points.Length == 0)
            return;

        // エージェントが現在設定された目標地点に行くように設定します
        enemyNav.destination = points[nextPoint].position;

        // 配列内の次の位置を目標地点に設定し、必要ならば出発地点にもどります
        nextPoint = (nextPoint + 1) % points.Length;
    }
}
