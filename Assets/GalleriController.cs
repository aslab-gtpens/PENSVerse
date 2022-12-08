using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GalleriController : MonoBehaviour
{
    [SerializeField] List<GameObject> galeriObject;
    [SerializeField] TextMeshProUGUI text;
    int index = 0;

    private void Start()
    {
        galeriObject[index].SetActive(true);
        text.text = galeriObject[index].name;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            galeriObject[index].SetActive(false);
            index = (index + 1 == galeriObject.Count) ? 0 : index + 1;
            galeriObject[index].SetActive(true);
            text.text = galeriObject[index].name;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            galeriObject[index].SetActive(false);
            index = (index - 1 == -1) ? galeriObject.Count - 1 : index -1;
            galeriObject[index].SetActive(true);
            text.text = galeriObject[index].name;
        }
    }
}
