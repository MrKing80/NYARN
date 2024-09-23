using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonOn : MonoBehaviour
{
    [SerializeField] Button focusButton;

    void Start()
    {
        // ボタンコンポーネントの取得
        focusButton = focusButton.GetComponent<Button>();
    }

    public void OnClick()
    {
        //全てのフォーカスを解除する
        EventSystem.current.SetSelectedGameObject(null);
        //focusButtonにフォーカスする
        focusButton.Select();
        //Canvasコンポーネントを無効にする。Buttonコンポーネントで設定可。
    }
}