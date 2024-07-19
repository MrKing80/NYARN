using UnityEngine;

[CreateAssetMenu(fileName = "TestData", menuName = "testData")]
public class ScritbleOBJ : ScriptableObject
{
    public enum Type
    {
        RICE,
        CURRY
    }

    [SerializeField] private Type type;
    [SerializeField] private int count;
    [SerializeField] private string msg;

    public Type _Type => type;
    public int COUNT { get => count; }
    public string MSG { get => msg; }
}
