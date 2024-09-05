namespace _04.Wild_Farm.Creators
{
    public interface ICreator<T>
    {
        public T Create(string[] args);
    }
}
