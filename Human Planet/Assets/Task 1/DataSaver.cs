using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;
using System;

public class DataSaver : MonoBehaviour
{
    const string FILENAME = "string.data";

    public static void Save(string[] strArray, List<string>[] lists, Dictionary<string, string>[] dictionaries)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = GetFilePath();

        FileStream stream = new FileStream(path, FileMode.Create);
        string[] encodedArray = FormEncodedArray(strArray);
        List<string>[] encodedList = FormEncodedList(lists);
        Dictionary<string, string>[] encodedDict = FormEncodedDict(dictionaries);

        Data data = new Data(encodedArray, encodedList, encodedDict);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Data Load()
    {
        string path = GetFilePath();
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(stream) as Data;

            string[] decodedStr = FormDecodedArray(data.str);
            List<string>[] decodedList = FormDecodedList(data.lists);
            Dictionary<string, string>[] decodedDict = FormDecodedDict(data.dictionaries);

            Data decodedData = new Data(decodedStr, decodedList, decodedDict);
            stream.Close();

            return decodedData;
        }
        else
        {
            return null;
        }
    }

    private static string GetFilePath()
    {
        string filePath = Path.Combine(Application.persistentDataPath, FILENAME);
        return filePath;
    }

    private static string[] FormEncodedArray(string[] strArray)
    {
        string[] encodedArray = new string[strArray.Length];
        for (int i = 0; i < encodedArray.Length; i++)
        {
            string encodedStr = EncodeToBase64(strArray[i]);
            encodedArray[i] = encodedStr;
        }

        return encodedArray;
    }

    private static List<string>[] FormEncodedList(List<string>[] lists)
    {
        List<string>[] encodedListArray = new List<string>[lists.Length];
        for (int i = 0; i < encodedListArray.Length; i++)
        {
            encodedListArray[i] = new List<string>();
            foreach (var str in lists[i])
            {
                string encodedStr = EncodeToBase64(str);
                encodedListArray[i].Add(encodedStr);
            }
        }

        return encodedListArray;
    }

    private static Dictionary<string, string>[] FormEncodedDict(Dictionary<string, string>[] dictionaries)
    {
        Dictionary<string, string>[] encodedDictArray = new Dictionary<string, string>[dictionaries.Length];

        for (int i = 0; i < encodedDictArray.Length; i++)
        {
            encodedDictArray[i] = new Dictionary<string, string>();
            Dictionary<string, string> dict = dictionaries[i];

            foreach (KeyValuePair<string, string> kvp in dict)
            {
                var encodedKey = EncodeToBase64(kvp.Key);
                var encodedValue = EncodeToBase64(kvp.Value);

                encodedDictArray[i].Add(encodedKey, encodedValue);
            }
        }

        return encodedDictArray;
    }

    private static string EncodeToBase64(string str)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(str);
        return Convert.ToBase64String(plainTextBytes);
    }

    private static string DecodeFromBase64(string str)
    {
        var encodedBytes = Convert.FromBase64String(str);
        return Encoding.UTF8.GetString(encodedBytes);
    }

    private static string[] FormDecodedArray(string[] strArray)
    {
        string[] decodedArray = new string[strArray.Length];
        for (int i = 0; i < decodedArray.Length; i++)
        {
            string encodedStr = DecodeFromBase64(strArray[i]);
            decodedArray[i] = encodedStr;
        }

        return decodedArray;
    }

    private static Dictionary<string, string>[] FormDecodedDict(Dictionary<string, string>[] dictionaries)
    {
        Dictionary<string, string>[] decodedDictArray = new Dictionary<string, string>[dictionaries.Length];

        for (int i = 0; i < decodedDictArray.Length; i++)
        {
            decodedDictArray[i] = new Dictionary<string, string>();
            Dictionary<string, string> dict = dictionaries[i];

            foreach (KeyValuePair<string, string> kvp in dict)
            {
                var encodedKey = DecodeFromBase64(kvp.Key);
                var encodedValue = DecodeFromBase64(kvp.Value);

                decodedDictArray[i].Add(encodedKey, encodedValue);
            }
        }

        return decodedDictArray;
    }

    private static List<string>[] FormDecodedList(List<string>[] lists)
    {
        List<string>[] decodedListArray = new List<string>[lists.Length];
        for (int i = 0; i < decodedListArray.Length; i++)
        {
            decodedListArray[i] = new List<string>();
            foreach (var str in lists[i])
            {
                string encodedStr = DecodeFromBase64(str);
                decodedListArray[i].Add(encodedStr);
            }
        }

        return decodedListArray;
    }
}
