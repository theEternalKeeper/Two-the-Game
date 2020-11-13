using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTestlevel : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;

    private void Start()
    {
        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/scenes");
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("TestMap");
    }
}
