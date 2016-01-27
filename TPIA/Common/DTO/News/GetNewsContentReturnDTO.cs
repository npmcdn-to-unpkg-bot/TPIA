using System;

namespace TPIA.Common.DTO.News
{
  public class GetNewsContentReturnDTO
  {
    public string NewSClass { get; set; }
    public string NewSTitle { get; set; }
    public string NewSContent { get; set; }
    public string DwgUrl { get; set; }
    public DateTime CreateDate { get; set; }
  }
}