using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevel : MonoBehaviour
{
    public CheckLevel checkLevel;
    public GameObject lockUp;

    public SaveCheckLevel saveCheckLevel;

    private void Start()
    {
        if(checkLevel.isOpenLevel)
        {
            lockUp.SetActive(false);
        }

        saveCheckLevel.LoadData();
    }
}
