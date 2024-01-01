using Projekt_01_Etap_07_Rozwiazanie.Shared.Interfaces;

namespace Projekt_01_Etap_07_Rozwiazanie.Presenters
{
    // Metoda wytwórcza - wprowadzenie
    // Metoda wytwórcza pozwoli nam usystematyzować proces tworzenia poszczególnych obiektów. W zależności od różnych czynników,
    // możemy chcieć by powołany obiekt delikatnie się różnił. W poprzedniej wersji programu drukowaliśmy wyniki do kontrolki
    // RichTextBox. Pozostała część procesu była jednak taka sama. Tak samo pozyskiwane były dane wejściowe, proces przeliczenia
    // statystyk był taki sam, różnił się jedynie sposób prezentacji danych. Można rozważyć sensowność zbudowania Metoda wytwórczej,
    // która będzie w stanie zwrócić nam klasę Presenter dopasowaną do DataGridView lub do RichTextBox.

    // Metoda wytwórcza - kork 1
    // Pierwszym krokiem będzie stworzenie inerfejsu IFormPresenter (patrz: projekt Shared, folder Interfaces). Interfejs ten pozwoli
    // nam grupować wiele różnych rodzajaów Presenterów w jedną grupę.

    // Metoda wytwórcza - kork 2
    // Drugim krokiem jest zbudowanie abstrakcyjnej klasy, która usystematyzuje nam nazwę oraz parametry metody, której zadaniem będzie
    // wytworzenie nowej instacji danej klasy.
    public abstract class PresenterCreator
    {
        public abstract IFormPresenter FactoryMethod(
            // zakładka Statystyka
            TextBox tb_Statistics_AllSymbols,
            TextBox tb_Statistics_UniqueItems,
            TextBox tb_Statistics_Entropy,
            TextBox tb_Statistics_Time,
            Control ctrl_Statistics_Statistics,
            // zakładka Kompresowanie
            TextBox tb_Compression_CodesTime,
            TextBox tb_Compression_CompressionTime,
            DataGridView dgv_Compression_Codes,
            // zakładka Dekompresowanie
            TextBox tb_Decompression_CodesTime,
            TextBox tb_Decpression_DecompressionTime,
            DataGridView dgv_Decpression_Codes,
            RichTextBox rtb_Decompression_CileContents
        );
    }

    // Metoda wytwórcza - kork 3
    // Trzecim krokiem jest uwtorzenie konkretnych instancji klas (kreatorów), które dziedziczą po naszej klasie abstrakcyjnej. W przypadku
    // naszego projektu klasy takie będa dwie. Jedna tworzyć będzie Presenter, który współpracuje z kontrolką RichTextBox, druga
    // współpracować będzie z kontrolką DataGridView.
    // Poszczególne implementacje Presenterów znajdują się w folderze Presenters w projekcie z interfejsem graficznym.
    public class RichTextBoxFormPresenterCreator : PresenterCreator
    {
        public override IFormPresenter FactoryMethod(
            TextBox tb_Statistics_AllSymbols, TextBox tb_Statistics_UniqueItems, TextBox tb_Statistics_Entropy, TextBox tb_Statistics_Time, Control ctrl_Statistics_Statistics,
            TextBox tb_Compression_CodesTime, TextBox tb_Compression_CompressionTime, DataGridView dgv_Compression_Codes,
            TextBox tb_Decompression_CodesTime, TextBox tb_Decpression_DecompressionTime, DataGridView dgv_Decpression_Codes, RichTextBox rtb_Decompression_CileContents)
        {
            if (ctrl_Statistics_Statistics != null && ctrl_Statistics_Statistics is RichTextBox)
            {
                RichTextBox rtb = ctrl_Statistics_Statistics as RichTextBox;
                return new RichTextBoxFormPresenter(
                    tb_Statistics_AllSymbols, tb_Statistics_UniqueItems, tb_Statistics_Entropy, tb_Statistics_Time, rtb,
                    tb_Compression_CodesTime, tb_Compression_CompressionTime, dgv_Compression_Codes,
                    tb_Decompression_CodesTime, tb_Decpression_DecompressionTime, dgv_Decpression_Codes, rtb_Decompression_CileContents);
            }
            else
                return null;
        }
    }

    public class DataGridViewFormPresenterCreator : PresenterCreator
    {
        public override IFormPresenter FactoryMethod(
            TextBox tb_Statistics_AllSymbols, TextBox tb_Statistics_UniqueItems, TextBox tb_Statistics_Entropy, TextBox tb_Statistics_Time, Control ctrl_Statistics_Statistics,
            TextBox tb_Compression_CodesTime, TextBox tb_Compression_CompressionTime, DataGridView dgv_Compression_Codes,
            TextBox tb_Decompression_CodesTime, TextBox tb_Decpression_DecompressionTime, DataGridView dgv_Decpression_Codes, RichTextBox rtb_Decompression_CileContents)
        {
            if (ctrl_Statistics_Statistics != null && ctrl_Statistics_Statistics is DataGridView)
            {
                DataGridView dgv = ctrl_Statistics_Statistics as DataGridView;
                return new DataGridViewFormPresenter(
                    tb_Statistics_AllSymbols, tb_Statistics_UniqueItems, tb_Statistics_Entropy, tb_Statistics_Time, dgv,
                    tb_Compression_CodesTime, tb_Compression_CompressionTime, dgv_Compression_Codes,
                    tb_Decompression_CodesTime, tb_Decpression_DecompressionTime, dgv_Decpression_Codes, rtb_Decompression_CileContents);
            }
            else
                return null;
        }
    }
}
