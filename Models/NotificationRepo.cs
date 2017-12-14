using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Notifications.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Notifications.Models
{
    public class NotificationRepo
    {

        public IEnumerable<Notifications> GetData()
        {

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT [Id],[Text],[UserId],[CreatedDate]
               FROM [dbo].[NotificationList]", connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    SqlDependency dependency = new SqlDependency(command);

                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var reader = command.ExecuteReader())
                        return reader.Cast<IDataRecord>()
                            .Select(x => new Notifications()
                            {
                                //   Id = x.GetInt32(0),
                                Text = x.GetString(1),
                                //  CreatedDate = x.GetDateTime(3),
                                //UserId = x.GetInt32(2)
                            }).ToList();



                }
            }
        }
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            var result = GetData();
            NitificationHub.Show(result);
        }
    }

}