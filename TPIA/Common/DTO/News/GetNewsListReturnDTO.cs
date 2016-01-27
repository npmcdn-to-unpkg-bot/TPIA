using System;

namespace TPIA.Common.DTO.News
{
  public class GetNewsListReturnDTO
  {
    public int NewSID { get; set; }
    public string NewSClass { get; set; }
    public string NewSTitle { get; set; }
    public string DwgUrl { get; set; }
    public DateTime CreateDate { get; set; }
  }
}