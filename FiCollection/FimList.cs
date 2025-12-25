using OrakUtilDotNetCore.FiDataContainer;

namespace OrakUtilDotNetCore.FiCollection
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