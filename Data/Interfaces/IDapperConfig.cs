namespace Data.Interfaces
{
    public interface IDapperConfig<T>
    {
        IEnumerable<T> Query(string query, object param = null);
        public int Insert(string query, object param);
    }
}