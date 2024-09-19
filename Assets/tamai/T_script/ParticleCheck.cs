using UnityEngine;

public class ParticleCheck : MonoBehaviour
{
    [SerializeField] private bool isItemObj = true;

    private void Update()
    {
        if (gameObject.transform.parent.tag == "Item")
        {   
            // 子オブジェクトのコライダー取得
            isItemObj = this.GetComponentInParent<BoxCollider2D>().enabled;
        }
        else
        {
            isItemObj = this.GetComponentInParent<CircleCollider2D>().enabled;

        }
        // trueの時はリターン、falseの時は見えなくする
        if (isItemObj) return;
        this.gameObject.SetActive(false);
    }
}
