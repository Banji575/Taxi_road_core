using System.Reflection;
using UnityEngine;
using Unity.VisualScripting;

[UnitTitle("SO Get Property by Index")]
[UnitCategory("Custom")]
public class SOGetPropertyByIndexNode : Unit
{
    [DoNotSerialize]
    public ValueInput scriptableObjectInput;

    [DoNotSerialize]
    public ValueOutput fieldValueOutput;

    // Поле для ввода индекса
    [SerializeField]
    private int fieldIndex = 0;

    [DoNotSerialize]
    public ValueInput fieldIndexInput;

    protected override void Definition()
    {
        // Определяем входное значение для ScriptableObject
        scriptableObjectInput = ValueInput<ScriptableObject>("ScriptableObject");

        // Определяем входное значение для индекса поля
        fieldIndexInput = ValueInput<int>("FieldIndex", fieldIndex);

        // Определяем выходное значение
        fieldValueOutput = ValueOutput<object>("FieldValue", (flow) =>
        {
            ScriptableObject scriptableObject = flow.GetValue<ScriptableObject>(scriptableObjectInput);
            int index = flow.GetValue<int>(fieldIndexInput);

            if (scriptableObject != null)
            {
                // Получаем список всех полей из ScriptableObject
                var fields = scriptableObject.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                // Проверяем, что индекс находится в допустимых пределах
                if (index >= 0 && index < fields.Length)
                {
                    // Получаем поле по индексу
                    var field = fields[index];

                    // Возвращаем значение поля
                    return field.GetValue(scriptableObject);
                }
                else
                {
                    Debug.LogError($"Index {index} is out of range for {scriptableObject.GetType().Name}");
                }
            }
            return null;
        });
    }
}
