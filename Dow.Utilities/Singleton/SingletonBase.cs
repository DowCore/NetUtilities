
namespace Dow.Utilities.Singleton
{
    public class SingletonBase
    {
        protected SingletonBase()
        {

        }
        protected static readonly object locker = new object();
    }
    public sealed class SingletonBase<T>:SingletonBase where T : class,ISingleton, new() 
    {
       
        private SingletonBase() { }

        private volatile static SingletonBase<T> instance = null;
        

        private T singleton = null;
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
                        {
                            singleton = new T();
                        }
                    }

                }
                return singleton;
            }
        }

    }
}
