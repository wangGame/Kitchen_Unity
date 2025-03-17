using System.Collections;
using System.Collections.Generic;
using System.IO;
using Sirenix.Serialization;
using UnityEditor;
using UnityEngine;

public class DataScript : MonoBehaviour
{
    [SerializeField]
    private Bean bean;
    private SerializationData serializationData;
    // Start is called before the first frame update
    void Start()
    {
        serializationData = new SerializationData();
        //UnitySerializationUtility.DeserializeUnityObject(this, ref this.serializationData);
        UnitySerializationUtility.SerializeUnityObject(this, ref this.serializationData);
        SerializeData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SerializeData()
    {
        // Save to Assets folder
        string path = Application.dataPath + "/data.json";

        // Initialize some data
        var originalData = new Bean();
        originalData.reference = new Bean();
        originalData.reference.reference = originalData;

        // Unity should be allowed to handle serialization and deserialization of its own weird objects.
        // So if your data-graph contains UnityEngine.Object types, you will need to provide Odin with
        // a list of UnityEngine.Object which it will then use as an external reference resolver.
        List<UnityEngine.Object> unityObjectReferences = new List<UnityEngine.Object>();

        //DataFormat dataFormat = DataFormat.Binary;
        DataFormat dataFormat = DataFormat.JSON;
        //DataFormat dataFormat = DataFormat.Nodes;

        // Serialization
        {
            var bytes = Sirenix.Serialization.SerializationUtility.SerializeValue(originalData, dataFormat, out unityObjectReferences);
            File.WriteAllBytes(path, bytes);

            // If you want the json string, use UTF8 encoding
            // var jsonString = System.Text.Encoding.UTF8.GetString(bytes);
        }

        // Deserialization
        {
            var bytes = File.ReadAllBytes(path);

            // If you have a string to deserialize, get the bytes using UTF8 encoding
            // var bytes = System.Text.Encoding.UTF8.GetBytes(jsonString);

            var data = Sirenix.Serialization.SerializationUtility.DeserializeValue<Bean>(bytes, dataFormat, unityObjectReferences);
            Debug.Log(data);
        }
    }
}
