using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class FormClassWrapper 
{
    public List<FormClass> TransformList;

    public FormClassWrapper()
    {
        TransformList = new List<FormClass>();
        TransformList.Add(new FormClass());
    }
}
