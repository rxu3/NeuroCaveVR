using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectomeBuilder : MonoBehaviour {

    public GameObject nodePrefab;
    public GameObject edgePrefab;
    public GameObject connectomePrefab;

    public float thresholdMax;
    public float thresholdMin;

    public Color32 leftCerebellum;
    public Color32 leftSubcortical;
    public Color32 brainstem;
    public Color32 leftFrontal;
    public Color32 leftOccipital;

    public Color32 leftParietal;
    public Color32 leftTemporal;
    public Color32 rightCerebellum;
    public Color32 rightFrontal;
    public Color32 rightOccipital;

    public Color32 rightParietal;
    public Color32 rightSubcortical;
    public Color32 rightTemporal;
    public Color32 thalamus;
    public Color32 Caudate;

    public Color32 Cingulate;
    public Color32 Pallidum;
    public Color32 Paracentral;
    public Color32 SuperiorFrontalCortex;
    public Color32 hippocampus;

    public Color32 precuneus;
    public Color32 putamen;
    public Color32 superiorParietal;
    public Color32 nonRichclub;

    private GameObject _connectomeTopLevel;
    private GameObject _connectomeParentEmpty;
    private List<GameObject> _connectomeTopLevelList = new List<GameObject>();
    private List<GameObject> _connectomeParentList = new List<GameObject>();
    private List<Color32> nodeColorList = new List<Color32>();
    private Dictionary<string, Material> classificationMaterialDictionary = new Dictionary<string, Material>();
    private float rotationRadius = 4;

    private string[] classification = { "leftCerebellum", "leftSubcortical", "brainstem", "leftFrontal", "leftOccipital",
            "leftParietal", "leftTemporal", "rightCerebellum", "rightFrontal", "rightOccipital", "rightParietal", "rightSubcortical",
            "rightTemporal", "thalamus", "Caudate", "Cingulate", "Pallidum", "Paracentral", "Superior frontal Cortex", "hippocampus",
            "precuneus", "putamen", "superiorParietal", "non-RichClub" };

    // Use this for initialization
    void Awake () {

        _connectomeTopLevel = Resources.Load("Prefabs/ConnectomeTopLevel") as GameObject;
        _connectomeParentEmpty = Resources.Load("Prefabs/SingleConnectome") as GameObject;
        
        nodeColorList.Add(leftCerebellum);
        nodeColorList.Add(leftSubcortical);
        nodeColorList.Add(brainstem);
        nodeColorList.Add(leftFrontal);
        nodeColorList.Add(leftOccipital);

        nodeColorList.Add(leftParietal);
        nodeColorList.Add(leftTemporal);
        nodeColorList.Add(rightCerebellum);
        nodeColorList.Add(rightFrontal);
        nodeColorList.Add(rightOccipital);

        nodeColorList.Add(rightParietal);
        nodeColorList.Add(rightSubcortical);
        nodeColorList.Add(rightTemporal);
        nodeColorList.Add(thalamus);
        nodeColorList.Add(Caudate);

        nodeColorList.Add(Cingulate);
        nodeColorList.Add(Pallidum);
        nodeColorList.Add(Paracentral);
        nodeColorList.Add(SuperiorFrontalCortex);
        nodeColorList.Add(hippocampus);

        nodeColorList.Add(precuneus);
        nodeColorList.Add(putamen);
        nodeColorList.Add(superiorParietal);
        nodeColorList.Add(nonRichclub);


        for (int i = 0; i < classification.Length; i++)
        {
            Material classificationMaterial = new Material(Shader.Find("Standard"));
            classificationMaterial.color = nodeColorList[i];
            classificationMaterialDictionary.Add(classification[i], classificationMaterial);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Build(List<Dictionary<string, string[][]>> connectomeList,string[] connectomeNames, bool isConnectomeReset=false)
    {
        float n = connectomeList.Count;
        float[] anglearray = new float[connectomeList.Count];
        anglearray[0] = -(n - 1) / 2;

        for (int j = 1; j < connectomeList.Count; j++)
            anglearray[j] = anglearray[j - 1] + 1;

        for (int i=0; i<connectomeList.Count; i++)
        {
            //build parent gameobject
            float angle = rotationRadius * 0.2f;
            float rotationAngle = angle * anglearray[i];
            float posZ = Mathf.Cos(rotationAngle) * rotationRadius;
            float posX = Mathf.Sin(rotationAngle) * rotationRadius;

            GameObject ConnectomeTopLevel = Instantiate(_connectomeTopLevel, new Vector3(posX, 0, posZ), Quaternion.identity);
            ConnectomeTopLevel.transform.parent = connectomePrefab.transform;
            _connectomeTopLevelList.Add(ConnectomeTopLevel);

            GameObject ConnectomeParent = Instantiate(_connectomeParentEmpty, new Vector3(posX, 0, posZ), Quaternion.identity);
            ConnectomeParent.transform.parent = ConnectomeTopLevel.transform;
            ConnectomeParent.name = connectomeNames[i];
            ConnectomeParent.tag = "SingleConnectome";
            _connectomeParentList.Add(ConnectomeParent);

            //attach singleconnectome script
            _connectomeParentList[i].AddComponent<SingleConnectome>().attachConnectomeData(connectomeList[i], connectomeNames[i], nodePrefab, edgePrefab, thresholdMax,thresholdMin, classificationMaterialDictionary, rotationAngle, isConnectomeReset);
            _connectomeParentList[i].AddComponent<BoxCollider>();
            _connectomeParentList[i].GetComponent<BoxCollider>().size = new Vector3(2.0f, 2.0f, 2.0f);
            _connectomeParentList[i].AddComponent<HoloToolkit.Unity.InputModule.Utilities.Interactions.SingleConnectomeManipulation>();
        }
    }

    public void DestroyConnectomes()
    {
        for (int i = 0; i < _connectomeParentList.Count; i++)
        {
            if(_connectomeParentList[i]!=null)
                Destroy(_connectomeParentList[i]);
        }
            
    }

}
