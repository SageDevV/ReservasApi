namespace Data.Interfaces
{
    public interface IDapperConfig<T>
    {
        IEnumerable<T> Query(string query, object param = null);
        public int Execute(string query, object param);
    }
}