using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aviaprak
{
    public class json3
    {
        public List<pereletClass> jason = null;
        public void Load_data_from_Json()
        {
            string file_name = "C:\\js\\avia1.json";

            if (File.Exists(file_name) == true)
            {
                var list = JsonConvert.DeserializeObject < List<pereletClass>>(File.ReadAllText(file_name));
                if (list != null)
                    jason = list;
                else
                    MessageBox.Show("Файл пустой", "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Файл не найден", "Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        public List<json2> Get_all_display_data()
        {
            Load_data_from_Json();
            if (jason != null)
            {
                List<json2> all = new List<json2>();
                for (int i = 0; i < jason.Count; i++)
                {
                    json2 record = new json2
                    {
                        Departure_city = jason[i].startCity,
                        Departure_city_code = jason[i].startCityCode,
                        City_of_arrival = jason[i].endCity,
                        City_of_arrival_code = jason[i].endCityCode,
                        Arrival_time = jason[i].endDate.ToLocalTime(),
                        Dparture_time = jason[i].startDate.ToLocalTime(),
                        Price = jason[i].price,
                    };
                    all.Add(record);
                }
                return all;
            }
            return null;
        }
    }
}
