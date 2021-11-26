using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyStuff : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}