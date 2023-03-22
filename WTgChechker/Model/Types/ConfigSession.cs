namespace WTgChechker.Model.Types;
    public class ConfigSession
    {
        public int Id { get; set; }
        public ClientConfig ClientConfig { get; set; }

        public string ConfigTgClient(string what)
        {

            if (what == "api_id") return ClientConfig.Id;
            if (what == "api_hash") return ClientConfig.Hash;
            if (what == "session_pathname") return ClientConfig.session_pathname;
            if (what == "device_model") return ClientConfig.device_model;
            if (what == "system_version") return ClientConfig.system_version;
            if (what == "app_version") return "9.0.2";
            if (what == "lang_code") return "ru"; //system_lang_code En-en
            if (what == "system_lang_code") return "ru"; //system_lang_code En-en

            if (what == "first_name") return ClientConfig.first_name;
            //if (what == "server_address") return "149.154.167.50:443";
            //if (what == "lang_pack") return null;
            if (what == "last_name") return ClientConfig.last_name;
            if (what == "phone_number") return ClientConfig.phone_number;
            if (what == "verification_code")
            {

                //var resultGetSms = Sms.GetCode(ClientConfig.SmsResult).Result; // Ожидает код втечении минуты
                //if (resultGetSms != null && resultGetSms.IsSuccess)
                //{
                //    //  Logger.AddLog($"Код: {resultActivation.Item2}");
                //    return resultGetSms.Code;
                //}

                //var status = Sms.CancleNumber(ClientConfig.SmsResult).Result;
                // Logger.AddLog("Не удалось получить код");
                throw new Exception("Не удалось получить код");
            }
            return null;
        }
    }