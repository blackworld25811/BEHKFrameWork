using BEHKFrameWork.Message;
using BEHKFrameWork.Binding;

public class SampleData : IData
{
    private string name;

    private string id;

    [Binding("Text_0")]
    public string Name { get => name; set => name = value; }
     
    public string Id { get => id; set => id = value; }
}
