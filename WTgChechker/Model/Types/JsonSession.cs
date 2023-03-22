namespace WTgChechker.Model.Types;
    public class JsonSession
    {
        public string session_file { get; set; }
        public string phone { get; set; }
        public string app_id { get; set; }
        public string app_hash { get; set; }
        public string sdk { get; set; }
        public string device { get; set; }
        public string app_version { get; set; }
        public long register_time { get; set; }
        public string lang_pack { get; set; }
        public string system_lang_pack { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string proxy { get; set; }
        public int last_check_time { get; set; }
        public bool success_registred { get; set; }
        public bool ipv6 { get; set; }
        public string avatar { get; set; }
    }
