using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordonateController : MonoBehaviour
{
    private readonly float radius=2.034f;
    public  GameObject DotPrefab;

    public void Plot(float _lat,float _lon)
    {
        _lon = -_lon;
        float x, y, z, phi, theta;
        phi = (90 - _lat) * (Mathf.PI / 180);
        theta = (_lon + 180) * (Mathf.PI / 180);
        x = -((radius) * Mathf.Sin(phi) * Mathf.Cos(theta));
        z = ((radius) * Mathf.Sin(phi) * Mathf.Sin(theta));
        y = ((radius) * Mathf.Cos(phi));
        Vector3 pos = new Vector3(x, y, z);
        Instantiate(DotPrefab, pos, Quaternion.identity);
    }
}
