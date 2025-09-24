namespace Api.Class
{
    public class ClassToken
    {
        public static async Task<bool> VereficarToken(string token)
        {
            bool result = await Task.Run(() => {
                try
                {
                    if (token == "4007005B-3F7A-4D5B-A6E3-0711DF09FA55")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    return false;
                }
            });
            return result;
        }
    }
}
