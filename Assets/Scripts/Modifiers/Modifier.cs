using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Modifier : MonoBehaviour
{
    void Start()
    {

    }

    protected abstract IEnumerator ModFunction();
}
