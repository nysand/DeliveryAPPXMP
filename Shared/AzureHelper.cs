using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
    public class AzureHelper
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("https://deliveryxamdemo1.azurewebsites.net/");

        public static async Task<bool> Insert<T>(T objectToInsert)
        {

            try
            {
                await MobileService.GetTable<T>().InsertAsync(objectToInsert);
                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }
    }
}
