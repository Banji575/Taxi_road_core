using System.Reflection;
using UnityEngine;
using Unity.VisualScripting;

[UnitTitle("SO Set Property by name")]
[UnitCategory("Custom")]
public class SOSetPropertyNode : Unit
{
    [DoNotSerialize]
    public ValueInput scriptableObjectInput;

    [DoNotSerialize]
    public ValueInput valueInput;

    [DoNotSerialize]
    public ControlInput setInput;

    [DoNotSerialize]
    public ControlOutput setOutput;

    [SerializeField]
    private string fieldName = "defaultFieldName"; // Поле для имени по умолчанию

    [DoNotSerialize]
    public ValueInput fieldNameInput;

    protected override void Definition()
    {
        // Определяем входные значения
        scriptableObjectInput = ValueInput<ScriptableObject>("ScriptableObject");
        fieldNameInput = ValueInput<string>("FieldName", fieldName); // Значение по умолчанию

        valueInput = ValueInput<object>("Value");

        // Определяем контрольный вход и выход
        setInput = ControlInput("Set", (flow) =>
        {
            // Получаем значения из входов
            ScriptableObject scriptableObject = flow.GetValue<ScriptableObject>(scriptableObjectInput);
            string fieldName = flow.GetValue<string>(fieldNameInput)?.ToLower(); // Преобразуем имя в нижний регистр
            object value = flow.GetValue<object>(valueInput);

            if (scriptableObject != null && !string.IsNullOrEmpty(fieldName))
            {
                // Получаем список всех полей из ScriptableObject
                var fields = scriptableObject.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                bool fieldFound = false;

                // Ищем поле с учетом регистра
                foreach (var field in fields)
                {
                    if (field.Name.ToLower() == fieldName)
                    {
                        // Устанавливаем значение
                        field.SetValue(scriptableObject, value);
                        fieldFound = true;
                        break; // Завершаем выполнение
                    }
                }

                if (!fieldFound)
                {
                    // Опционально: Вы можете добавить код для обработки случая, когда поле не найдено
                    // Например, можно установить значение по умолчанию или создать исключение
                }
            }

            return setOutput; // Завершаем выполнение
        });

        setOutput = ControlOutput("Done");
    }
}
