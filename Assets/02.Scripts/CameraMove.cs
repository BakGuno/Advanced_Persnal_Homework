using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _Player;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    
    void Update()
    {
        //-9
        if (_Player.transform.position.x <= minX)
        {
            transform.position = new Vector3(minX,0,-10);    
        }
        else if (_Player.transform.position.x >= maxX)
        {
            transform.position = new Vector3(maxX,0,-10);
        }
        else transform.position = new Vector3(_Player.transform.position.x,0,-10);
    }
}
