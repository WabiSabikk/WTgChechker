using WTgChechker.Helper;
using WTgChechker.Model.Types;

namespace WTgChechker.Model
{
    public class TgWorker
    {
        public async Task<bool> Login(ConfigSession config)
        {
            try
            {
                using (var client = new WTelegram.Client(config.ConfigTgClient))
                {
                    var res = await client.LoginUserIfNeeded(); // если вход успешный, сохраняется сессия
                    Loger.Print($"{config.ClientConfig.phone_number}\tgood", TypeLog.GOOD);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Loger.Print($"{config.ClientConfig.phone_number}\t{ex.Message}", TypeLog.ERROR);

                return false;
            }
        }
    }
}
