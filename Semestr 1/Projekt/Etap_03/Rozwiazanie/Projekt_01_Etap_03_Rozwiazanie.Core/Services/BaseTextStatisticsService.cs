using Projekt_01_Etap_03_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_03_Rozwiazanie.Shared.Interfaces;

namespace Projekt_01_Etap_03_Rozwiazanie.Core.Services
{
    public abstract class BaseTextStatisticsService : ITextStatisticsService
    {
        public abstract TextStatisticsData CountStatistics(string text);
        
        public virtual TextPrintingData FillPrintingData(TextStatisticsData statistics)
        {
            TextPrintingData result = new TextPrintingData();
            result.AllSymbolCount = statistics.AllSymbolCount.ToString();
            result.UniqueSymbolCount = statistics.UniqueSymbolCount.ToString();
            result.Entropy = string.Format("{0:0.########}", statistics.Entropy);
            result.SymbolStatistics = new List<SymbolPrintingData>();

            for (int i = 0; i < statistics.SymbolStatistics?.Count; i++)
            {
                SymbolPrintingData symbolPrintingData = new SymbolPrintingData();
                symbolPrintingData.BinaryNotation = GetBinaryNotation(statistics.SymbolStatistics[i].Symbol, 2);
                symbolPrintingData.DecimalNotation = ((short)statistics.SymbolStatistics[i].Symbol).ToString();
                if (statistics.SymbolStatistics[i].Symbol <= 32)
                    symbolPrintingData.Symbol = SpcialChars[statistics.SymbolStatistics[i].Symbol];
                else if (statistics.SymbolStatistics[i].Symbol == 127)
                    symbolPrintingData.Symbol = SpcialChars[SpcialChars.Length - 1];
                else
                    symbolPrintingData.Symbol = statistics.SymbolStatistics[i].Symbol.ToString();
                symbolPrintingData.Frequency = string.Format("{0:0.########}", statistics.SymbolStatistics[i].Frequency);
                symbolPrintingData.Probability = string.Format("{0:0.########}", statistics.SymbolStatistics[i].Probability);
                symbolPrintingData.InformationQuantity = string.Format("{0:0.########}", statistics.SymbolStatistics[i].InformationQuantity);
                result.SymbolStatistics.Add(symbolPrintingData);
            }

            return result;
        }



        private string[] SpcialChars = new string[]
        {
            "NUL - Null",
            "SOH - Start Of Heading",
            "STX - Start of Text",
            "ETX - End of Text",
            "EOT - End of Transmission",
            "ENQ - Enquiry",
            "ACK - Acknowledge",
            "BEL - Bell",
            "BS - Backspace",
            "HT - Horizontal Tab",
            "LF - Line Feed",
            "VT - Vertical Tab",
            "FF - Form Feed",
            "CR - Carriage Return",
            "SO - Shift Out",
            "SI - Shift In",
            "DLE - Data Link Escape",
            "DC1 - Device Control 1 (XON)",
            "DC2 - Device Control 2",
            "DC3 - Device Control 3 (XOFF)",
            "DC4 - Device Control 4",
            "NAK - Negative Acknowledge",
            "SYN - Synchronous Idle",
            "ETB - End of Transmission Block",
            "CAN - Cancel",
            "EM - End of Medium",
            "SUB - Substitute",
            "ESC - Escape",
            "FS - File Separator",
            "GS - Group Separator",
            "RS - Record Separator",
            "US - Unit Separator",
            "Spacja",
            "DEL - Delete"
        };

        private string GetBinaryNotation(char symbol, int bytesCount)
        {
            int bitsCounter = (bytesCount * 8) - 1;
            string bin = "";
            for (int j = bitsCounter; j >= 0; j--)
            {
                if (GetBit(symbol, j))
                    bin += "1";
                else
                    bin += "0";
            }
            return bin;
        }
        private bool GetBit(int _decimal, int _bitNumber)
        {
            return (_decimal & (1 << _bitNumber)) != 0;
        }
    }
}
