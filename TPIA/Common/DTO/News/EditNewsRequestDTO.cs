
using TPIA.Common.Enumeration;
namespace TPIA.Common.DTO.News
{
    /// <summary>
    /// 編輯消息
    /// </summary>
  public class EditNewsRequestDTO
  {
      /// <summary>
      /// 消息編號
      /// </summary>
      public int NewsID { get; set; }
      /// <summary>
      /// 消息類別
      /// </summary>
      public enNewsCategory Category { get; set; }
      /// <summary>
      /// 消息標題
      /// </summary>
      public string Title { get; set; }
      /// <summary>
      /// 消息內文
      /// </summary>
      public string NewsContent { get; set; }
  }
}
