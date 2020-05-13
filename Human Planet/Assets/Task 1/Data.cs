using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public string[] str;
    public List<string>[] lists;
    public Dictionary<string, string>[] dictionaries;

    public Data(string[] str, List<string>[] lists, Dictionary<string, string>[] dictionaries)
    {
        this.str = str;
        this.lists = lists;
        this.dictionaries = dictionaries;
    }
}
