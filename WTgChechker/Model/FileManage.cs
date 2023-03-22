using Newtonsoft.Json;
using System.IO;
using WTgChechker.Helper;
using WTgChechker.Model.Types;

namespace WTgChechker.Model
{
    public class FileManage
    {
        public FileManage()
        {
            if (!Directory.Exists(Paths.GoodDir))
                Directory.CreateDirectory(Paths.GoodDir);
            if (!Directory.Exists(Paths.BadDir))
                Directory.CreateDirectory(Paths.BadDir);
        }

        public async Task<List<ConfigSession>> GetConfigSessions()
        {
            List<ConfigSession> sessions = new();
            string[] files = Directory.GetFiles("Accounts").Where(x => Path.GetExtension(x) == ".json").ToArray();

            foreach (string file in files)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string text = await sr.ReadToEndAsync();
                    var account = JsonConvert.DeserializeObject<JsonSession>(text);

                    //string file_name = Path.GetFileNameWithoutExtension(file);
                    var config = new ConfigSession()
                    {
                        ClientConfig = new ClientConfig
                        {
                            phone_number = account.phone,
                            session_pathname = Path.Combine("Accounts", $"{account.phone}.session"),
                            system_version = account.sdk,
                            device_model = account.device,
                            Id = account.app_id,//.Split(":")[0],
                            Hash = account.app_hash, // account.RegIdAndHash.Split(":")[1],
                            first_name = account.first_name,
                            last_name = account.last_name,
                        }
                    };
                    sessions.Add(config);
                }
            }

            return sessions;
        }

        public void MoveGood(string path)
        {
            try
            {
                string fileName = Path.GetFileName(path);
                string jsonFile = fileName.Replace(".session", ".json");
                File.Move(path, Paths.GoodDirFile(fileName), true);
                File.Move(path.Replace(".session", ".json"), Paths.GoodDirFile(jsonFile), true);
            }
            catch (Exception ex)
            {
                Loger.Print(ex.Message, TypeLog.ERROR);
            }
        }
        public void MoveBad(string path)
        {
            try
            {
                string fileName = Path.GetFileName(path);
                File.Move(path, Paths.BadDirFile(fileName), true);
                File.Delete(path.Replace(".session", ".json"));
            }
            catch (Exception ex)
            {
                Loger.Print(ex.Message, TypeLog.ERROR);
            }
        }
    }
}
