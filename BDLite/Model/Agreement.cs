using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BDLite.Model
{
    public class Agreement : Model
    {
        public int Id { get; set; }
        public int PersonID { get; set; }
        public string PersonShifer { get; set; }
        public int TypeID { get; set; }
        public string Type { get; set; }
        public int StatusID { get; set; }
        public string Status { get; set; }
        public string Number { get; set; }
        public string DataOpen { get; set; }
        public string DataClose { get; set; }

        public static List<Agreement> GetList()
        {
            var list = new List<Agreement>();
            try
            {
                using (var connect = new SQLiteConnection(_ConnectionString))
                {
                    connect.Open();
                    var command = connect.CreateCommand();
                    command.CommandText = "SELECT Agreement.id, (SELECT shifer FROM person WHERE id = PersonID)," +
                        "(SELECT type FROM typeagreement WHERE id = TypeID)," +
                        "(SELECT status FROM statusagreement WHERE id = StatusID)," +
                        "number,dataOpen,dataClose FROM agreement";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string personShifer = reader.GetString(1);
                        string type = reader.GetString(2);
                        string status = reader.GetString(3);
                        string number = reader.GetString(4);
                        string dataopen = reader.GetString(5);
                        string dataclose = reader.GetString(6);

                        var agreement = new Agreement
                        {
                            Id = id,
                            PersonShifer = personShifer,
                            Type = type,
                            Status = status,
                            Number = number,
                            DataOpen = dataopen,
                            DataClose = dataclose,

                        };
                        list.Add(agreement);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return list;
        }



        public static void Add(Agreement agreement)
        {
            try
            {
                using (var connect = new SQLiteConnection(_ConnectionString))
                {
                    connect.Open();
                    var command = connect.CreateCommand();
                    command.CommandText = String.Format(@"INSERT INTO Agreement (PersonID, typeid, statusid, number, dataopen, dataclose) 
                                                        VALUES (@personid, @typeid, @statusid, @number, @dataopen, @dataclose)");
                    command.Parameters.AddWithValue("PersonID", agreement.PersonID);
                    command.Parameters.AddWithValue("typeid", agreement.TypeID);
                    command.Parameters.AddWithValue("statusid", agreement.StatusID);
                    command.Parameters.AddWithValue("number", agreement.Number);
                    command.Parameters.AddWithValue("dataopen", agreement.DataOpen.ToString());
                    command.Parameters.AddWithValue("dataclose", agreement.DataClose.ToString());

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        public static void Update(Agreement agreement)
        {
            try
            {
                using (var connect = new SQLiteConnection(_ConnectionString))
                {
                    connect.Open();
                    var command = connect.CreateCommand();
                    command.CommandText = String.Format(@"UPDATE agreement SET personID=@personid, typeID=@typeid, statusID=@statusid, 
                                                                 number=@number, dataopen=@dataopen, dataclose=@dataclose WHERE id=@id");
                    command.Parameters.AddWithValue("id", agreement.Id);
                    command.Parameters.AddWithValue("personid", agreement.PersonID);
                    command.Parameters.AddWithValue("typeid", agreement.TypeID);
                    command.Parameters.AddWithValue("statusid", agreement.StatusID);
                    command.Parameters.AddWithValue("number", agreement.Number);
                    command.Parameters.AddWithValue("dataopen", agreement.DataOpen.ToString());
                    command.Parameters.AddWithValue("dataclose", agreement.DataClose.ToString());

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        public static void Delete(Agreement agreement)
        {
            try
            {
                using (var connect = new SQLiteConnection(_ConnectionString))
                {
                    connect.Open();
                    var command = connect.CreateCommand();
                    command.CommandText = String.Format(@"DELETE FROM agreement WHERE id = @id");
                    command.Parameters.AddWithValue("id", agreement.Id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        public Agreement()
        {

        }
    }
}