using OrakUtilDotNetCore.FiDataContainer;

namespace OrakUtilDotNetCore.FiMetas
{
  public static class FimLogTypes
  {
    public static FiMeta Info(){
      return new FiMeta("info");
    }

    public static FiMeta Error(){
      return new FiMeta("error");
    }

  }
}