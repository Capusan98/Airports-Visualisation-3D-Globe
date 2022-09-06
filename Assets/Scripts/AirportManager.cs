using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AirportManager : MonoBehaviour
{
    //public TextAsset AirportTextData;
   
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
            AirportsList.Add(new AirportData(strValues[1], strValues[2], strValues[3], strValues[4],float.Parse(strValues[14]), float.Parse(strValues[15]),int.Parse(strValues[13])));
        }
    }
    public void PlotAllAirPorts()
    {
        for(int i = 0; i < AirportsList.Count; i++)
        {
            GameObject GO=TowerSpawner.Instance.Plot(AirportsList[i].LatitudeDD, AirportsList[i].LongitudeDD, AirportsList[i].Altitude);
            GO.GetComponent<AirportController>().ReceiveAportData(AirportsList[i]);
            if (AirportsList[i].IATACode != "N/A" && !(AirportDict.ContainsKey(AirportsList[i].IATACode)))
            {
               AirportDict.Add(AirportsList[i].IATACode, GO);
            }
        }
    }

  

   
}
