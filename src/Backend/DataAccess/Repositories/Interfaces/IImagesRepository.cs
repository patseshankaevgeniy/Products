using System;

namespace DataAccess.Repositories.Interfaces
{
    public interface IImagesRepository
    {
        byte[] Get(Guid id);
        void Create(Guid id, byte[] image);
        bool Delete(Guid id);
    }
}
