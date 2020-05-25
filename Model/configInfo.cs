using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StdScoreViewerConfig.Model
{
    /// <summary>
    /// 接收資料庫回傳之物件(原住民資料)
    /// </summary>
    class configInfo
    {
        /// <summary>
        /// 設定項目名稱 
        /// </summary>
        public string  configName { get; set; }

        /// <summary>
        /// 設定內容
        /// </summary>
        public string  configContent { get; set; }


        /// <summary>
        ///  Table 【student_info_ext】 是否此學生之資料
        /// </summary>
        public Boolean NoExtensoinRecord { get; set; }


        internal configInfo()
        {
            this.NoExtensoinRecord = false;
            this.configName = "";
            this.configContent = "";
        }
    }
}
