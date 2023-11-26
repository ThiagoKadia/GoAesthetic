namespace GoAesthetic.Respostas
{
    public class RespostaGeraGrafico : RespostaPadrao
    {
        public List<string> Labels { get; set; }
        public List<DataSetGrafico> Datasets { get; set; }
    }

    public class DataSetGrafico
    {
        public string Label { get; set; }
        public List<double> Data { get; set; }
        public string BackGroundColor { get; set; }
        public string BorderColor { get; set; }
        public int BorderWidth { get; set; }
    }

}
