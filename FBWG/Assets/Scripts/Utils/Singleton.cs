using System;

namespace Backend.Utils
{
    public class Singleton<T> where T : class
    {
        private static readonly object Locker = new object();

        private static T _instance;

        public static T Instance
        {
            get
            {
                // Double-checked locking (Thread Safe)
                lock (Locker)
                {
                    if (_instance == null)
                    {
                        CreateInstance();
                    }

                    return _instance;
                }
            }
        }

        private static void CreateInstance()
        {
            lock (Locker)
            {
                var type = typeof(T);
                var constructorInfos = type.GetConstructors();
                if (constructorInfos.Length > 0)
                {
                    var name = type.Name;
                    var message = $"{name} has at least one accessible constructor making it impossible to enforce singleton behaviour";

                    throw new InvalidOperationException(message);
                }

                _instance = (T)Activator.CreateInstance(type, true);
            }
        }
    }
}
