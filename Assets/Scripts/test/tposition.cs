using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
public class tposition : MonoBehaviour {

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/position.dat");
        Debug.Log(gameObject.name);
        CubePosition cp = new CubePosition();
        cp.x = gameObject.transform.position.x;
        cp.y = gameObject.transform.position.y;
        cp.z = gameObject.transform.position.z;

        bf.Serialize(file, cp);
        file.Close();
    }

    public void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/position.dat", FileMode.Open);
        CubePosition data = (CubePosition)bf.Deserialize(file);
        file.Close();

        Vector3 pos = new Vector3(data.x, data.y, data.z);
        gameObject.transform.position = pos;
    }

    [Serializable]
    class CubePosition
    {
        public float x;
        public float y;
        public float z;
    }
}
