using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BDLite.Model
{
	public class TypeAgreement : Model
	{
		public int Id { get; set; }
		public string Type { get; set; }

		public static List<TypeAgreement> GetList()
		{
			var list = new List<TypeAgreement>();
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = "SELECT * FROM typeAgreement";
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						int id = reader.GetInt32(0);
						string type = reader.GetString(1);
						var typeAgreement = new TypeAgreement
						{
							Id = id,
							Type = type
						};
						list.Add(typeAgreement);
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			return list;
		}
		public static void Add(TypeAgreement typeAgreement)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"INSERT INTO typeAgreement (Type) VALUES(@type)");
					command.Parameters.AddWithValue("type", typeAgreement.Type);

					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Update(TypeAgreement typeAgreement)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"UPDATE typeAgreement SET Type=@type WHERE id=@id");
					command.Parameters.AddWithValue("type", typeAgreement.Type);
					command.Parameters.AddWithValue("id", typeAgreement.Id);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Delete(TypeAgreement typeAgreement)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"DELETE FROM typeAgreement WHERE id = @id");
					command.Parameters.AddWithValue("id", typeAgreement.Id);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public TypeAgreement()
		{

		}
		public TypeAgreement(int id, string type)
		{
			Id = id;
			Type = type;
		}


	}
}
