using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public static TowerSpawner Instance { get; private set; }

    private readonly float radius = 2.024f;
    public GameObject DotPrefab;
    public Transform TransformParent;
    Vector3 LookPos = new Vector3(0, 0, 0);

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public GameObject Plot(float _lat, float _lon,int height)
    {
        _lon = -_lon;
        float x, y, z, phi, theta;
        phi = (90 - _lat) * (Mathf.PI / 180);
        theta = (_lon + 180) * (Mathf.PI / 180);
        x = -((radius) * Mathf.Sin(phi) * Mathf.Cos(theta));
        z = ((radius) * Mathf.Sin(phi) * Mathf.Sin(theta));
        y = ((radius) * Mathf.Cos(phi));
        Vector3 pos = new Vector3(x, y, z);
        //GameObject GO = Instantiate(DotPrefab, pos, Quaternion.identity);//parent not set
        GameObject GO=Instantiate(DotPrefab, pos, Quaternion.identity, TransformParent); //parent set
        SetHeight(GO.transform.GetChild(0), height);
        GO.transform.LookAt(LookPos);
        return GO;
    }

    private void SetHeight(Transform trans, int altitude)
    {
        float height = (float)altitude / 100 + 1;
        trans.localScale = new Vector3(trans.localScale.x, trans.localScale.y, -trans.localScale.z * height);
        trans.localPosition = new Vector3(trans.localPosition.x, trans.localPosition.y, ((trans.localScale.z - 1f) * 0.5f));
    }
}
