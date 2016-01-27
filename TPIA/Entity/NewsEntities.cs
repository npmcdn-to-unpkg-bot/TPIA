using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using TPIA.Common.DTO.News;
using TPIA.Common.Enumeration;

namespace TPIA.Entiy
{
    public class NewsEntities
    {
        private string DBConn = ConfigurationManager.ConnectionStrings["TPAIConn"].ConnectionString;

        //public GetNewsContentReturnDTO GetNewsContent(int NewsID) /*廣告推播*/
        //{
        //  GetNewsContentReturnDTO dtoGetNewsContentReturn = new GetNewsContentReturnDTO();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();

        //      string strsqlcmd = @"SELECT NewSClass, NewSTitle,NewSContent,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS WHERE NewSID=@dtoNewsID";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      cmd.Parameters.Add("@dtoNewsID", SqlDbType.Int).Value = NewsID;

        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dtoGetNewsContentReturn.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dtoGetNewsContentReturn, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //        }
        //      }

        //    }

        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }

        //  return dtoGetNewsContentReturn;
        //}

        #region 最新消息
        /// <summary>
        /// 取得最新消息 Title 列表
        /// </summary>
        /// <returns></returns>
        public List<GetNewsListReturnDTO> GetNewsList() /*最新消息標題列表*/
        {
            List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();

            try
            {
                for (int i = 1; i < 51; i++)
                {
                    GetNewsListReturnDTO newsDto = new GetNewsListReturnDTO();
                    newsDto.NewSID = i;
                    if (i % 3 == 0)
                    {
                        newsDto.NewSTitle = "你拿到的是Title TTTTTT" + i.ToString(); 
                        newsDto.NewSClass = "類別1";
                        newsDto.DwgUrl = "house2.jpg";
                        newsDto.CreateDate = DateTime.Now.AddDays(-5);
                    }
                    if (i % 3 == 1)
                    {
                        newsDto.NewSTitle = "你拿到的是Title TTTTTTFFFFFFFFFFFFFFF" + i.ToString();
                        newsDto.NewSClass = "類別2";
                        newsDto.DwgUrl = "house3.jpg";
                        newsDto.CreateDate = DateTime.Now.AddDays(-10);
                    }
                    if (i % 3 == 2)
                    {
                        newsDto.NewSTitle = "你拿到的是Title TTTTTTwerqwer qwrgdasgewrtqwet e" + i.ToString();
                        newsDto.NewSClass = "類別3";
                        newsDto.DwgUrl = "house4.jpg";
                        newsDto.CreateDate = DateTime.Now.AddDays(-15);
                    }
                    lstGetNewsListReturn.Add(newsDto);
                }
                //using (SqlConnection conn = new SqlConnection(DBConn))
                //{
                //    if (conn.State != ConnectionState.Open)
                //        conn.Open();

                //    string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";

                //    SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
                //    cmd.CommandType = CommandType.Text;

                //    using (SqlDataReader reader = cmd.ExecuteReader())
                //    {
                //        while (reader.Read())
                //        {
                //            GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
                //            for (int i = 0; i < reader.FieldCount; i++)
                //            {
                //                PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
                //                if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
                //                    property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i), null);
                //            }
                //            lstGetNewsListReturn.Add(dto);
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
            return lstGetNewsListReturn;
        }
        public GetNewsContentReturnDTO GetNewsContent(int NewsID) /*最新消息內容*/
        {
            GetNewsContentReturnDTO dtoGetNewsContentReturn = new GetNewsContentReturnDTO();
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConn))
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    string strsqlcmd = @"SELECT NewSClass, NewSTitle,NewSContent,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS WHERE NewSID=@dtoNewsID";
                    SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@dtoNewsID", SqlDbType.Int).Value = NewsID;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                PropertyInfo property = dtoGetNewsContentReturn.GetType().GetProperty(reader.GetName(i));
                                if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
                                    property.SetValue(dtoGetNewsContentReturn, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i), null);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return dtoGetNewsContentReturn;
        }
        public enErrorCode AddNews(AddNewsRequestDTO dtoAddNewsRequest)  /*新增最新消息*/
        {
            enErrorCode eResult = enErrorCode.EXCEPTION;
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConn))
                {
                    string strsqlcmd = @"INSERT INTO Jaysus_test.dbo.NewS
                               (NewSClass,NewSTitle,NewSContent,CreateDate,DwgUrl) 
                               VALUES(@dtoNewsClass,@dtoNewsTitle,@dtoNewsContent,GETDATE(),@dtoDwgUrl) ";

                    SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@dtoNewsClass", SqlDbType.NVarChar, 50).Value = dtoAddNewsRequest.dtoNewsClass;
                    cmd.Parameters.Add("@dtoNewsTitle", SqlDbType.NVarChar, 50).Value = dtoAddNewsRequest.dtoNewsTitle;
                    cmd.Parameters.Add("@dtoNewsContent", SqlDbType.NVarChar, 4096).Value = dtoAddNewsRequest.dtoNewsContent;
                    cmd.Parameters.Add("@dtoDwgUrl", SqlDbType.NVarChar, 50).Value = dtoAddNewsRequest.dtoDwgUrl;
                    try
                    {
                        conn.Open();
                        int iResult = cmd.ExecuteNonQuery();
                        if (iResult > 0)
                            eResult = enErrorCode.SUCCESS;
                        else
                        {
                            eResult = enErrorCode.INS_FAIL;
                        }

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return eResult;
        }
        public enErrorCode EditNews(EditNewsRequestDTO dtoEditNewsRequest)  /*修改最新消息*/
        {
            enErrorCode eResult = enErrorCode.EXCEPTION;
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConn))
                {
                    string strsqlcmd = @"UPDATE Jaysus_test.dbo.NewS
                               SET NewSClass=@dtoNewsClass,
                               NewSTitle=@dtoNewsTitle,
                               NewSContent=@dtoNewsContent,
                               EditDate=GETDATE(),
                               DwgUrl=@dtoDwgUrl
                               WHERE NewSID=@dtoNewsID";

                    SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@dtoNewsID", SqlDbType.Int).Value = dtoEditNewsRequest.dtoNewsID;
                    cmd.Parameters.Add("@dtoNewsClass", SqlDbType.NVarChar, 50).Value = dtoEditNewsRequest.dtoNewsClass;
                    cmd.Parameters.Add("@dtoNewsTitle", SqlDbType.NVarChar, 50).Value = dtoEditNewsRequest.dtoNewsTitle;
                    cmd.Parameters.Add("@dtoNewsContent", SqlDbType.NVarChar, 4096).Value = dtoEditNewsRequest.dtoNewsContent;
                    cmd.Parameters.Add("@dtoDwgUrl", SqlDbType.NVarChar, 50).Value = dtoEditNewsRequest.dtoDwgUrl;
                    try
                    {
                        conn.Open();
                        int iResult = cmd.ExecuteNonQuery();
                        if (iResult > 0)
                            eResult = enErrorCode.SUCCESS;
                        else
                        {
                            eResult = enErrorCode.UPT_FAIL;
                        }

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return eResult;
        }
        public enErrorCode DelNews(DelNewsRequestDTO dtoDelNewsRequest)  /*刪除最新消息*/
        {
            enErrorCode eResult = enErrorCode.EXCEPTION;
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConn))
                {
                    string strsqlcmd = @"DELETE FROM Jaysus_test.dbo.NewS
                               WHERE NewSID=@dtoNewsID";
                    SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@dtoNewsID", SqlDbType.Int).Value = dtoDelNewsRequest.dtoNewsID;
                    try
                    {
                        conn.Open();
                        int iResult = cmd.ExecuteNonQuery();
                        if (iResult > 0)
                            eResult = enErrorCode.SUCCESS;
                        else
                        {
                            eResult = enErrorCode.DEL_FAIL;
                        }

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return eResult;
        }
        #endregion

        //#region 關於公會
        //public List<GetNewsListReturnDTO> GetNewsList() /*關於公會*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*公會沿革*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*公會簡介*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*公會組織*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*會務發展*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*工會組織圖*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //#endregion

        //#region 公會規章
        //public List<GetNewsListReturnDTO> GetNewsList() /*公會規章*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*公會章程*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*會員入會須知*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*入、退費暨繳費細則*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //#endregion

        //#region 友好相連
        //public List<GetNewsListReturnDTO> GetNewsList() /*學術單位連結*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*印刷新知連結*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*印前資訊連結*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*印刷資訊連結*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*印後資訊連結*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*原料資訊連結*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //#endregion

        //#region 會員專區
        //public List<GetNewsListReturnDTO> GetNewsList() /*印刷會訊*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*出版品訂購*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*新進會員介紹*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*會員名錄*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //#endregion

        //#region 法令轉載
        //public List<GetNewsListReturnDTO> GetNewsList() /*政府公告*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*常用法令*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //public List<GetNewsListReturnDTO> GetNewsList() /*統計資料*/
        //{
        //  List<GetNewsListReturnDTO> lstGetNewsListReturn = new List<GetNewsListReturnDTO>();
        //  try
        //  {
        //    using (SqlConnection conn = new SqlConnection(DBConn))
        //    {
        //      if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //      string strsqlcmd = @"SELECT NewSID,NewSClass,NewSTitle,CreateDate,DwgUrl FROM Jaysus_test.dbo.NewS ORDER BY CreateDate DESC";
        //      SqlCommand cmd = new SqlCommand(strsqlcmd, conn);
        //      cmd.CommandType = CommandType.Text;
        //      using (SqlDataReader reader = cmd.ExecuteReader())
        //      {
        //        while (reader.Read())
        //        {
        //          GetNewsListReturnDTO dto = new GetNewsListReturnDTO();
        //          for (int i = 0; i < reader.FieldCount; i++)
        //          {
        //            PropertyInfo property = dto.GetType().GetProperty(reader.GetName(i));
        //            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //              property.SetValue(dto, (reader.IsDBNull(i)) ? "[NULL]" : reader.GetValue(i));
        //          }
        //          lstGetNewsListReturn.Add(dto);
        //        }
        //      }
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    throw;
        //  }
        //  return lstGetNewsListReturn;
        //}
        //#endregion

    }
}