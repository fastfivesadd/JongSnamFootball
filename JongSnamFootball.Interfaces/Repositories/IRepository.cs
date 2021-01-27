namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Create(T model);

        T Updete(T model);

        void Delete(T model);

    }
}
