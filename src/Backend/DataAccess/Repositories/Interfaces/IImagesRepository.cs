using System;

namespace DataAccess.Repositories.Interfaces
{
    public interface IImagesRepository
    {
        byte[] Get(Guid id);
        void Create(byte[] image);
        bool Delete(Guid id);
    }
}
