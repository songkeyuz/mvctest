using System.ComponentModel;

namespace mvctest.Models
{
    public class QF_SystemUser : QueryFilter
    {
        public int ? SysNo { get; set; }

        public string LoginName { get; set; }

        public string UserFullName { get; set; }

        public string CellPhone { get; set; }

        public CommonStatus? CommonStatus { get; set; }
    }

    public enum CommonStatus : int
    {
        [Description("有效")]
        Actived = 1,
        [Description("无效")]
        DeActived = 0,
        [Description("已删除")]
        Deleted = -1
    }
}