using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class end : MonoBehaviour
{
    [SerializeField] private Button endsd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCllic()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //SceneManager.LoadScene("");
    }
}
