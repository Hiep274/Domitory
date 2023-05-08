using System.ComponentModel;

namespace tmss.BaseResults
{
    public class BaseResult
    {
        public Result Result { get; set; } = Result.Success;
        public string Message { get; set; } = "";
    }

    public enum Result
    {
        [Description("Thành công")]
        Success = 1,
        [Description("Thất bại")]
        Failed = 2,
        [Description("Lỗi hệ thống")]
        SystemError = 3
    }
}
