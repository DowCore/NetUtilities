using System;

namespace Dow.Core.Utilities.Singleton
{
    public sealed class SingletonBase<T> where T : class,ISingleton, new()
    {
        private volatile static SingletonBase<T> instance = null;
        private static readonly object locker = new object();

        private  static T singleton =null;
        private SingletonBase() { }

        public static SingletonBase<T> Instance

        {
            get
            {
                if (instance == null)

                {

                    lock (locker)

                    {

                        if (instance == null)

                            instance = new SingletonBase<T>();

                    }

                }
                return instance;
            }
        }

        public T  Singleton
        {
            get
            {
                if (singleton == null)

                {

                    lock (locker)

                    {

                        if (singleton == null)

                            singleton = new T();

                    }

                }
                return singleton;
            }
        }

    }
}
