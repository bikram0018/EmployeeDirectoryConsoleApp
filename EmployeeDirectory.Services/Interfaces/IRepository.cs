using System;

namespace EmployeeDirectory.Services.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Get();
        void Store(List<T> Data);
    }
}
