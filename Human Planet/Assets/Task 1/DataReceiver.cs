using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReceiver : MonoBehaviour
{
    private string[] strs;
    // Start is called before the first frame update
    void Start()
    {
        string[] strs = { "Hi", "Hello", "Good Morning", "Bye" };
        List<string>[] strings = { new List<string>() {"Pop", "Vokod" } };
        Dictionary<string, string>[] numbers = new Dictionary<string, string>[] { new Dictionary<string, string> { { "0", "2" }, { "5", "6" } } };
        DataSaver.Save(strs, strings, numbers);
        Debug.Log("Saved");
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Data data = DataSaver.Load();
            if (data != null)
            {
                //foreach (var str in data.str)
                //{
                //    Debug.Log(str);
                //}

                foreach (var list in data.lists)
                {
                    foreach (var element in list)
                    {
                        Debug.Log(element);
                    }

                }

                //foreach (var dict in data.dictionaries)
                //{
                //    foreach (KeyValuePair<string, string> kvp in dict)
                //    {
                //        Debug.Log(kvp.Key);
                //        Debug.Log(kvp.Value);
                //    }

                //}
            }
        }
    }

}
