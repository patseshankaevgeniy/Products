using System;

namespace BusinessLogic.Services.Interfaces
{
    public interface IImageService
    {
        byte[] Get(Guid id);
        byte[] Create(Guid id,byte[] image);
        bool Delete(Guid id);
    }
}
