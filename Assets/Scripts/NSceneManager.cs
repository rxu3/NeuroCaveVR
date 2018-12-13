using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NSceneManager : MonoBehaviour
{

    public DataLoader connectomeDataLoader;
    public ConnectomeBuilder connectomeBuilder;

    private string[] connectomeFolderNames;
    private List<Dictionary<string, string[][]>> connectomeList = new List<Dictionary<string, string[][]>>();

    // Use this for initialization
    void Start()
    {
        connectomeList = connectomeDataLoader.LoadConnectomes();
        connectomeFolderNames = connectomeDataLoader.GetConnectomeFolderName();
        connectomeBuilder.Build(connectomeList, connectomeFolderNames);
    }

    // Update is called once per frame
    void Update()
    {
  

    }

    public void resetConnectomeBuilder()
    {
        connectomeBuilder.DestroyConnectomes();
        connectomeBuilder.Build(connectomeList, connectomeFolderNames, true);
    }
   
}
