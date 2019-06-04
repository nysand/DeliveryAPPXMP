using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
    public class DeliveryPerson
    {
            public string Id { get; set; }

            public static async Task<DeliveryPerson> GetDeliveries(string id)
            {
                DeliveryPerson person = new DeliveryPerson();

                person = (await AzureHelper.MobileService.GetTable<DeliveryPerson>().Where(d => d.Id == id).ToListAsync()).FirstOrDefault();

                return person;
            }
    }
}
