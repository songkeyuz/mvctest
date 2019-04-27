using System.ComponentModel;

namespace mvctest.Models
{
    public class SystemUser
    {
        /// <summary>
        /// 
        /// </summary>
        public int SysNo { get; set; }

        /// <summary>
        /// 要求全局唯一
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LoginPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserFullName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CellPhone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AvatarImageUrl { get; set; }

        /// <summary>
        /// 状态，通用状态，共两种：有效，无效，删除是将状态设置为-1
        /// </summary>
        public CommonStatus CommonStatus { get; set; }
    }
    
    public enum Gender
    {
        [Description("未知")]
        Unknown = -1,
        [Description("男")]
        Male = 1,
        [Description("女")]
        Female = 0
    }
}