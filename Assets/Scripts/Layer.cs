using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer
{

    int resolution;

    Texture2D layer;
    int index;

    public Layer(int _res, int _index) {
        resolution = _res;
        index = _index;
    }

    // Start is called before the first frame update
    void Start()
    {
        layer = new Texture2D(resolution, resolution);
        for (int i = 0; i < resolution; i++) {
            for (int j = 0; j < resolution; j++) {
                layer.SetPixel(i, j, new Color((float)i / resolution, (float)i / resolution, (float)i / resolution));
            }
        }
        layer.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
