using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etap3.UI.Presenters
{
    internal class Form1Presenter
    {
        private TextBox _tb_AllSymbols;
        private TextBox _tb_UniqueItems;
        private TextBox _tb_Entropy;
        private TextBox _tb_Time;
        private RichTextBox _rtb_Statistics;

        public Form1Presenter(TextBox tb_AllSymbols, TextBox tb_UniqueItems, TextBox tb_Entropy,
            TextBox tb_Time, RichTextBox rtb_Statistics)
        {
            _tb_AllSymbols = tb_AllSymbols;
            _tb_UniqueItems = tb_UniqueItems;
            _tb_Entropy = tb_Entropy;
            _tb_Time = tb_Time;
            _rtb_Statistics = rtb_Statistics;

            // aktywacja serwisów
        }

        public void PerformTextAnalysis(string text)
        {
            // przeprowadzenie analizy

            // przygotowanie tekstu do drukowania

            // drukowanie wyników
        }
    }
}
