using Lekcja_03.Shared.Entities;
using Lekcja_03.Shared.Interfaces;

namespace Lekcja_03.Core.Services
{
    public class MyService : IMyService
    {
        private string _name = "default";

        public void SetSomeConfig(string inputText)
        {
            _name = inputText;
        }

        public MyResult MyMethod(string inputText)
        {
            MyResult result = new MyResult();
            result.MyText = _name + " - MyService - " + inputText;
            return result;
        }
    }
}
