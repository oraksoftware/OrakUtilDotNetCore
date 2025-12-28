using OrakUtilDotNetCore.FiContainer;

namespace OrakUtilDotNetCore.FiCollections
{
  public class FkbList: List<FiKeybean>
  {
    public string txTemplate { get; set; }

    public string txValue { get; set; }

    public FicList ficList { get; set; }

    //public FiKeycol fiKeycol { get; set; }

    public FkbList()
    {
    }

    public FkbList(int capacity) : base(capacity)
    {
    }

    public FkbList(IEnumerable<FiKeybean> collection) : base(collection)
    {
    }


  }
}