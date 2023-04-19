namespace SingletonPattern
{
    //This example is NOT thread safe
    public class Singleton 
    {
        private Singleton() { }
        //Ensures thread safety
        private static readonly object syncObj = new Object();

        private int _counter = 0;

        private static Singleton? _instance;

        public static Singleton Instance
        {
            get
            {
                // Check if syncObj has been created before creating the instance
                // Ensures one thread 
                lock (syncObj)
                {
                    if (_instance == null)
                        _instance = new Singleton();
                }
                return _instance;

            }
        }
        public int Increment()
        {
            return _counter++;
        }
        public string GetCount()
        {
            return "Counter Value: " + _counter.ToString();
        }

        public void LogException(string message)
        {
            throw new NotImplementedException();
        }
    }
}
