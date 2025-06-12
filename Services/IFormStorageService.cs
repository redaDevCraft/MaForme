using System.Collections.Generic;
using MaForme.Models;

namespace MaForme.Services
{
    public interface IFormStorageService
    {
        void SaveInstance(FormInstance instance);
        FormInstance LoadInstance(Guid instanceId);
        IEnumerable<FormInstance> LoadAllInstances();
        void DeleteInstance(Guid instanceId);
    }
}
