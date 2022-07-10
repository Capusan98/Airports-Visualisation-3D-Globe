using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AirportManager : MonoBehaviour
{
    public TextAsset AirportTextData;
    private readonly float radius = 2.024f;
    public GameObject DotPrefab;
    public Transform AirportsTransformParent;
    Vector3 LookPos = new Vector3(0, 0, 0);

    public struct AirportData
    {
        public string IATACode;
        public string AirportName;
        public string City;
        public string Country;
        public float LatitudeDD;
        public float LongitudeDD;
        public int Altitude;
    
        public AirportData(string v1, string v2, string v3, string v4, float v5, float v6,int v7) : this()
        {
            this.IATACode = v1;
            this.AirportName = v2;
            this.City = v3;
            this.Country = v4;
            this.LatitudeDD = v5;
            this.LongitudeDD = v6;
            this.Altitude = v7;
        }
    }
    public List<AirportData> AirportsList;
    public Dictionary<string, GameObject> AirportDict;

    private void Start()
    {
        GetDataFromText();
        PlotAllAirPorts();
    }

    public void GetDataFromText()
    {
        AirportsList = new List<AirportData>();
        AirportDict = new Dictionary<string,GameObject>();
        string[] text = File.ReadAllLines("Assets/Data/GlobalAirportDatabase.txt");
        char separator = ':';
        for(int i = 0; i < text.Length; i++)
        {
            string[] strValues = text[i].Split(separator);
            ///Debug.Log(text[i]);
            AirportsList.Add(new AirportData(strValues[1], strValues[2], strValues[3], strValues[4],float.Parse(strValues[14]), float.Parse(strValues[15]),int.Parse(strValues[13])));
        }
       
    }
    public void PlotAllAirPorts()
    {
        for(int i = 0; i < AirportsList.Count; i++)
        {
            GameObject GO=Plot(AirportsList[i].LatitudeDD, AirportsList[i].LongitudeDD);
            GO.GetComponent<AirportController>().ReceiveAportData(AirportsList[i]);
            SetHeight(GO.transform.GetChild(0), AirportsList[i].Altitude);
            if (AirportsList[i].IATACode != "N/A" && !(AirportDict.ContainsKey(AirportsList[i].IATACode)))
            {
               AirportDict.Add(AirportsList[i].IATACode, GO);
            }
        }
    }

    private void SetHeight(Transform trans,int altitude)
    {
        float height = (float)altitude / 100 + 1;
        trans.localScale = new Vector3(trans.localScale.x, trans.localScale.y, -trans.localScale.z * height);
        //float newPos=
        trans.localPosition = new Vector3(trans.localPosition.x, trans.localPosition.y, ((trans.localScale.z - 1f) * 0.5f));
    }

    public GameObject Plot(float _lat, float _lon)
    {
        _lon = -_lon;
        float x, y, z, phi, theta;
        phi = (90 - _lat) * (Mathf.PI / 180);
        theta = (_lon + 180) * (Mathf.PI / 180);
        x = -((radius) * Mathf.Sin(phi) * Mathf.Cos(theta));
        z = ((radius) * Mathf.Sin(phi) * Mathf.Sin(theta));
        y = ((radius) * Mathf.Cos(phi));
        Vector3 pos = new Vector3(x, y, z);
        //GameObject GO=Instantiate(DotPrefab, pos, Quaternion.identity, AirportsTransformParent);
        GameObject GO=Instantiate(DotPrefab, pos, Quaternion.identity);//parent not set 
        GO.transform.LookAt(LookPos);
        return GO;
    }

   
}
