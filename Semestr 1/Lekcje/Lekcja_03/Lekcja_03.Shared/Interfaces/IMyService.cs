using Lekcja_03.Shared.Entities;

namespace Lekcja_03.Shared.Interfaces
{
    public interface IMyService
    {
        void SetSomeConfig(string inputText);

        MyResult MyMethod(string inputText);
    }
}
