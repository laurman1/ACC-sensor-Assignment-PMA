using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Samples  : MonoBehaviour
{
    private bool startStop;
    private List<Vector3> listOfSamples = new List<Vector3>();
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startStop == true)
        {
            listOfSamples.Add(Input.acceleration);
        }
    }

    public void buttonPressed()
    {
        if (startStop == true)
        {
            startStop = false;
            writeSCV();
        }
        else
        {
            startStop = true;
        }
    }

    void writeSCV()
    {
        TextWriter tw = new StreamWriter("./data.csv", true);
        tw.WriteLine("x,y,z");

        foreach (Vector3 vec in listOfSamples)
        {
            tw.WriteLine($"{vec.x},{vec.y},{vec.z}");
        }
        tw.Close();
    }
        
    
}
