using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IHotbar
{
    public string Name { get; set; }
    public RawImage Image { get; set; }
    
    public Vector3[] ImagePositions { get; }
        
    public void Add();

    public void Remove();
}
