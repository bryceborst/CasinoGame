using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private GameObject[][] SenerioObjects;

    [SerializeField] private int[] objectNumbers;

    [SerializeField] private GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objectsInASenerio = new GameObject[100];

        int objectPlacer = 0;
        
        int numberOfSenerios = 0;
        for (int i = 0; i < objectNumbers.Length; i++)
        {
            if (numberOfSenerios < objectNumbers[i])
            {
                numberOfSenerios = objectNumbers[i];
            }
        }
        
        SenerioObjects = new GameObject[numberOfSenerios][];
        for (int i = 0; i < SenerioObjects.Length; i++)
        {
            SenerioObjects[i] = new GameObject[objectsInASenerio.Length];
        }
        
        for (int i = 1; i <= numberOfSenerios; i++)
        {
            for (int j = 0; j < objectNumbers.Length; j++)
            {
                if (objectNumbers[j] == i)
                {
                    objectsInASenerio[objectPlacer] = objects[j];
                    objectPlacer += 1;
                }
            }
            for (int j = 0; j < SenerioObjects[i-1].Length; j++)
            {
                SenerioObjects[i-1][j] = objectsInASenerio[j];
            }
            
            objectPlacer = 0;

            for (int j = 0; j < objectsInASenerio.Length; j++)
            {
                objectsInASenerio[j] = null;
            }
        }
      /*  for (int i = 0; i < SenerioObjects.Length; i++)
        {
            for (int j = 0; j < SenerioObjects[i].Length; j++)
            {
                Debug.Log(SenerioObjects[i][j]);
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadSenario(int senario)
    {
        emptyObjectActive();
        for (int i = 0; i < SenerioObjects[senario-1].Length; i++)
        {
            if (SenerioObjects[senario-1][i] != null)
            {
                SenerioObjects[senario-1][i].SetActive(true);
            }

        }
    }

    private void emptyObjectActive()
    {
        for (int i = 0; i < SenerioObjects.Length; i++)
        {
            for (int j = 0; j < SenerioObjects[i].Length; j++)
            {
                if (SenerioObjects[i][j] != null)
                {
                    SenerioObjects[i][j].SetActive(false);                    
                }
            }
        }
    }
}
