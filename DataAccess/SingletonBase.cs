
using BusnessObject;

namespace DataAccess
{
    public class SingletonBase<T> where T : class, new()
    {
        private static T _instance;
        private static readonly Object _lock = new object();
        public static BookStoreContext _context = new BookStoreContext();
        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                    return _instance;
                }
            }
        }
    }
}
