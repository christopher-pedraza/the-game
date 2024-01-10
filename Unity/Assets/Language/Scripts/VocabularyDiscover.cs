using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct DiscoverableWords
{
    public string word;
    public string translation;
}

public class VocabularyDiscover : MonoBehaviour
{
    // List of words and their translations that this object will provide
    public List<DiscoverableWords> words = new List<DiscoverableWords>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
