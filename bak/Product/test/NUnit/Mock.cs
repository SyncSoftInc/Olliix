using System;
using System.Linq;

namespace NUnit.Framework
{
    public static class Mock
    {
        public static T CreateWithRandomData<T>()
            where T : class
        {
            var type = typeof(T);
            var obj = typeof(T).CreateInstance();

            type.GetProperties().ForEach(p =>
            {
                if (p.GetSetMethod().IsNull()) return;

                if (p.PropertyType.Is<string>())
                {
                    p.SetValue(obj, Guid.NewGuid().ToLowerNString());
                }
                else if (p.PropertyType.IsStruct<int>())
                {
                    p.SetValue(obj, new Random().Next(1, 100));
                }
                else if (p.PropertyType.IsStruct<decimal>())
                {
                    p.SetValue(obj, new Random().Next(1, 100) + (decimal)new Random().NextDouble());
                }
            });

            return (T)obj;
        }

        private static bool Is<T>(this Type type)
        {
            return type == typeof(T);
        }

        private static bool IsStruct<T>(this Type type)
            where T : struct
        {
            return type == typeof(T) || type == typeof(Nullable<T>);
        }
    }
}
