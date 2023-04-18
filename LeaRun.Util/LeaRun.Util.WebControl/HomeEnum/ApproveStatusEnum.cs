using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Util.WebControl.HomeEnum
{
    /// <summary>
    /// 枚举：申报状态
    /// </summary>
    public enum DeclarationStatus
    {
        /// <summary>
        /// 待补全
        /// </summary>
        Incomplete,

        /// <summary>
        /// 待申报
        /// </summary>
        ToBeDeclared,

        /// <summary>
        /// 待审核
        /// </summary>
        ToBeReviewed,

        /// <summary>
        /// 审核完成
        /// </summary>
        Reviewed,

        /// <summary>
        /// 审核未通过
        /// </summary>
        NotReviewed
    }

}
