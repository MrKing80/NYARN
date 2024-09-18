using UnityEngine;

public class ParticleCheck : MonoBehaviour
{
    [SerializeField] private bool isItemObj = true;

    private void Update()
    {
        // �q�I�u�W�F�N�g�̃R���C�_�[�擾
        isItemObj = this.GetComponentInParent<CircleCollider2D>().enabled;

        // true�̎��̓��^�[���Afalse�̎��͌����Ȃ�����
        if (isItemObj) return;
        this.gameObject.SetActive(false);
    }
}
