using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class YandexProgressStorage :MonoBehaviour, IProgressStorage
{

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);
    [DllImport("__Internal")]
    private static extern void LoadExtern();


    public static YandexProgressStorage Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Load()
    {
        LoadExtern();
    }

    public void LoadProgress(string data)
    {
        Debug.Log("Load Progress " + data);
        Dictionary<string, object> loadedData = DeserializeDictionary(data);
        Debug.Log("Loaded data " + loadedData);

        foreach (var kvp in loadedData)
        {
            var field = typeof(GameData).GetField(kvp.Key);
            Debug.Log("field of data " + kvp);
            if (field != null && field.GetCustomAttributes(typeof(SaveableFieldAttribute), false).Length > 0)
            {
                // Преобразуем значение в соответствующий тип и устанавливаем его в поле globalContext
                object value = ConvertValue(kvp.Value.ToString(), field.FieldType);
                field.SetValue(GameManager.Instance.globalContext, value);
                Debug.Log("Global context params " + field.Name + " " + GameManager.Instance.globalContext.maxLevel);
            }
        }
        Debug.Log("Global context max level " + GameManager.Instance.globalContext.maxLevel);
    }

    public void Save(GameData gameData, params string[] fields)
    {
        Dictionary<string, object> dataToSave = new Dictionary<string, object>();
        Debug.Log("Save");
        Debug.Log(fields[0]);

        foreach (var fieldName in fields)
        {
            var field = typeof(GameData).GetField(fieldName);
            if (field != null && field.GetCustomAttributes(typeof(SaveableFieldAttribute), false).Length > 0)
            {
                Debug.Log("Field " + field);
                Debug.Log(field.GetValue(gameData));
                object value = field.GetValue(gameData);

                if (value != null)
                {
                    dataToSave[fieldName] = value;
                }
            }
        }

        // Теперь вручную сериализуем словарь
        var jsonData = SerializeDictionary(dataToSave);
        Debug.Log("JSON DATA " + jsonData);
        SaveExtern(jsonData);
    }
    private string SerializeDictionary(Dictionary<string, object> dictionary)
    {
        List<string> entries = new List<string>();
        foreach (var kvp in dictionary)
        {
            string key = kvp.Key;
            string value;

            if (kvp.Value is int || kvp.Value is float || kvp.Value is double)
            {
                value = kvp.Value.ToString(); // Числовые значения без кавычек
            }
            else
            {
                value = $"\"{kvp.Value}\""; // Строковые значения в кавычках
            }

            entries.Add($"\"{key}\":{value}");
        }
        return "{" + string.Join(",", entries) + "}";
    }


    private Dictionary<string, object> DeserializeDictionary(string json)
    {
        Dictionary<string, object> result = new Dictionary<string, object>();

        json = json.TrimStart('{').TrimEnd('}');
        string[] pairs = json.Split(',');

        foreach (var pair in pairs)
        {
            string[] kv = pair.Split(new[] { ':' }, 2); // Разделяем по первому двоеточию
            if (kv.Length == 2)
            {
                string key = kv[0].Trim('"');
                string value = kv[1].Trim();
                result.Add(key, value);
            }
        }
        return result;
    }

    private object ConvertValue(string value, Type targetType)
    {
        if (targetType == typeof(int))
        {
            return int.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
        }
        else if (targetType == typeof(float))
        {
            return float.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
        }
        else if (targetType == typeof(double))
        {
            return double.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
        }
        else
        {
            return value; // По умолчанию оставляем строку
        }
    }
}


