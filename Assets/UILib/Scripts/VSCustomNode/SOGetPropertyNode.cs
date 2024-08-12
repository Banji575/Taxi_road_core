using System.Reflection;
using UnityEngine;
using Unity.VisualScripting;

[UnitTitle("SO Get Property by name")]
[UnitCategory("Custom")]
public class SOGetPropertyNode : Unit
{
    [DoNotSerialize]
    public ValueInput scriptableObjectInput;

    [DoNotSerialize]
    public ValueOutput fieldValueOutput;

    // Поле для ввода имени
    [SerializeField]
    private string fieldName = "defaultFieldName";

    [DoNotSerialize]
    public ValueInput fieldNameInput;

    protected override void Definition()
    {
        // Определяем входное значение для ScriptableObject
        scriptableObjectInput = ValueInput<ScriptableObject>("ScriptableObject");

        // Определяем входное значение для имени поля
        fieldNameInput = ValueInput<string>("FieldName", fieldName);

        // Определяем выходное значение
        fieldValueOutput = ValueOutput<object>("FieldValue", (flow) =>
        {
            ScriptableObject scriptableObject = flow.GetValue<ScriptableObject>(scriptableObjectInput);
            string fieldName = flow.GetValue<string>(fieldNameInput)?.ToLower(); // Преобразуем имя поля в нижний регистр

            if (scriptableObject != null && !string.IsNullOrEmpty(fieldName))
            {
                // Получаем список всех полей из ScriptableObject
                var fields = scriptableObject.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                // Ищем поле с учетом регистра
                foreach (var field in fields)
                {
                    if (field.Name.ToLower() == fieldName)
                    {
                        return field.GetValue(scriptableObject);
                    }
                }

                Debug.LogError($"Field {fieldName} not found in {scriptableObject.GetType().Name}");
                return null;
            }
            return null;
        });
    }
}
