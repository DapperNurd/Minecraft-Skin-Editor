using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer
{
    public Texture2D texture;
    public int index;
    public bool enabled;

    public Layer(Texture2D _texture, int _index) {
        texture = _texture;
        index = _index;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
