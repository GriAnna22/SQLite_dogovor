using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BDLite.Model
{
	public class Person : Model
	{
		public int ID { get; set; }
		public string Shifer { get; set; }
		public string Inn { get; set; }
		public string Type { get; set; }
		public string Data { get; set; }
		public static List<Person> GetList()
		{
			var list = new List<Person>();
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = "SELECT * FROM Person";
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						int id = reader.GetInt32(0);
						string inn = reader.GetString(1);
						string type = reader.GetString(2);
						string shifer = reader.GetString(3);
						string data = reader.GetString(4);

						var person = new Person
						{
							ID = id,
							Shifer = shifer,
							Inn = inn,
							Type = type,
							Data = data

						};
						list.Add(person);
					}

				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			return list;
		}
		public static void Add(Person person)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"INSERT INTO person (shifer, inn, type, data) VALUES (@shifer, @inn, @type, @data)");
					command.Parameters.AddWithValue("shifer", person.Shifer);
					command.Parameters.AddWithValue("inn", person.Inn);
					command.Parameters.AddWithValue("type", person.Type);
					command.Parameters.AddWithValue("data", person.Data.ToString());

					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Update(Person person)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"UPDATE person SET shifer=@shifer,inn=@inn, type=@type, data=@data WHERE id=@id");
					command.Parameters.AddWithValue("shifer", person.Shifer);
					command.Parameters.AddWithValue("inn", person.Inn);
					command.Parameters.AddWithValue("type", person.Type);
					command.Parameters.AddWithValue("data", person.Data);
					command.Parameters.AddWithValue("id", person.ID);

					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Delete(Person person)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"DELETE FROM person WHERE id = @id");
					command.Parameters.AddWithValue("id", person.ID);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public Person()
		{

		}
	}
}