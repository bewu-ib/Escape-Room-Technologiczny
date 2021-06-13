using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    public IDictionary<string, bool> bools = new Dictionary<string, bool>();

    private SoundManager sm;

    private void Start()
    {
        sm = FindObjectOfType<SoundManager>();
        sm.playEffect(sm.startup);

        bools.Add("boardSolved", false);
        bools.Add("kartkaSolved", false);
        bools.Add("wybielaczSolved", false);
        bools.Add("latarnikSolved", false);
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
