using System;

namespace BusinessLogic.Services.Interfaces
{
    public interface IImageService
    {
        byte[] Get(Guid id);
        bool Delete(Guid id);
    }
}
