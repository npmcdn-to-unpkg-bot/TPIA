using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPIA.Common.Enumeration
{
  public enum enErrorCode:int
  {
    SUCCESS=1,

    #region [Data]
    INS_FAIL = -1001,
    UPT_FAIL = -1002,
    DEL_FAIL = -1003,
    #endregion

    #region [System]

    EXCEPTION=-9999
    #endregion
  }
}