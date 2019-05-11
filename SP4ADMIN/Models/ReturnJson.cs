namespace SP4ADMIN.Models
{
    public class ReturnJson
    {
        public enum StatusType
        {
            True = 100,
            False = 900,
            Logout = 999
        }
        public static string Return(StatusType status, string text = "", string location = "")
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                status,
                text,
                location
            });
        }
        public static string Return(StatusType status, object obj, string text = "", string location = "")
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                status,
                text,
                location,
                obj
            });
        }
        public static string SplitPipe(string text)
        {
            return text.Contains("|") ? text.Split('|')[1] : text;
        }
    }
}