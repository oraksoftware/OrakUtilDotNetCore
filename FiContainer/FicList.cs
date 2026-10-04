namespace OrakUtilDotNetCore.FiContainer
{
  public class FicList : List<FiCol>
  {
    public FicList()
    {
    }
    public FicList(int capacity) : base(capacity)
    {
    }
    public FicList(IEnumerable<FiCol> collection) : base(collection)
    {
    }
  }
}