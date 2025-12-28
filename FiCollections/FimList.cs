using OrakUtilDotNetCore.FiDataContainer;

namespace OrakUtilDotNetCore.FiCollections
{
  public class FimList : List<FiMeta>
  {
    public FimList()
    {
    }

    public FimList(int capacity) : base(capacity)
    {
    }

    public FimList(IEnumerable<FiMeta> collection) : base(collection)
    {
    }


  }
}