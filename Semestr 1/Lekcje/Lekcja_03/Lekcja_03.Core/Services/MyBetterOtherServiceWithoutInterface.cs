using Lekcja_03.Shared.Entities;

namespace Lekcja_03.Core.Services
{
    public class MyBetterOtherServiceWithoutInterface
    {
        private string _name = "default";

        public void SetSomeConfig(string inputText)
        {
            _name = inputText;
        }

        public MyResult MyOtherMethod(string inputText)
        {
            MyResult result = new MyResult();
            result.MyText = _name + " - MyBetterOtherServiceWithoutInterface - " + inputText;
            return result;
        }
    }
}
