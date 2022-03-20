using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{

    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
