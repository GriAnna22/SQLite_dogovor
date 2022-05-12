using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BDLite.Model
{
	public class StatusAgreement : Model
	{
		public int Id { get; set; }
		public string Status { get; set; }
		public static List<StatusAgreement> GetList()
		{
			var list = new List<StatusAgreement>();
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = "SELECT * FROM statusAgreement";
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						int id = reader.GetInt32(0);
						string status = reader.GetString(1);
						var statusAgreement = new StatusAgreement
						{
							Id = id,
							Status = status
						};
						list.Add(statusAgreement);
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			return list;
		}
		public static void Add(StatusAgreement statusAgreement)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"INSERT INTO statusAgreement (status) VALUES(@status)");
					command.Parameters.AddWithValue("status", statusAgreement.Status);

					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Update(StatusAgreement statusAgreement)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"UPDATE statusAgreement SET status=@status WHERE id=@id");
					command.Parameters.AddWithValue("status", statusAgreement.Status);
					command.Parameters.AddWithValue("id", statusAgreement.Id);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Delete(StatusAgreement statusAgreement)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"DELETE FROM statusAgreement WHERE id = @id");
					command.Parameters.AddWithValue("id", statusAgreement.Id);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public StatusAgreement()
		{

		}
		public StatusAgreement(int id, string status)
		{
			Id = id;
			Status = status;
		}


	}
}
