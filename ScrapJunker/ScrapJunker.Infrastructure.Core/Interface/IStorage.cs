namespace ScrapJunker.Infrastructure.Core.Interface
{
    public interface IStorage
    {
        void Store<T>(T item, string filePath, string fileName);
    }
}
