using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private int ScreenSenario;

    [SerializeField] private GameObject[] Senerio1Objects;

    [SerializeField] private GameObject[] Senerio2Objects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadSenario(int senario)
    {
        emptyObjectActive();
        ScreenSenario = senario;
        switch (ScreenSenario)
        {
            case 1:
            {
                for (int i = 0; i < Senerio1Objects.Length; i++)
                {
                    addObjectToScreen(Senerio1Objects[i]);
                }
                break;
            }
            case 2:
            {
                for (int i = 0; i < Senerio2Objects.Length; i++)
                {
                    addObjectToScreen(Senerio2Objects[i]);
                }
                break;
            }
        }
    }

    private void addObjectToScreen(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    private void emptyObjectActive()
    {
        for (int i = 0; i < Senerio1Objects.Length; i++)
        {
            Senerio1Objects[i].SetActive(false);
        }

        for (int i = 0; i < Senerio2Objects.Length; i++)
        {
            Senerio2Objects[i].SetActive(false);
        }
    }
}
