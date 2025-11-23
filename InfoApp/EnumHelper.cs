using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace InfoApp
{
    public static class EnumHelper
    {
        // Получить описание для значения enum
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? value.ToString();
        }

        // Получить все значения enum с описаниями
        public static Dictionary<T, string> GetValuesWithDescriptions<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .ToDictionary(x => x, x => x.GetDescription());
        }

        // Получить список для ComboBox (Value-Text пары)
        public static List<KeyValuePair<T, string>> GetComboBoxData<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(e => new KeyValuePair<T, string>(e, e.GetDescription()))
                .ToList();
        }
    }
}
