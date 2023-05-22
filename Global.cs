using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_Project
{
    public static class Global
    {
        public static SqlConnection conn = null;

        public enum sql_push_type
        {
            insert,
            delete,
            update
        }

        public static void sql_push(string sql, sql_push_type action)
        {
            SqlDataAdapter sql_query = new SqlDataAdapter();
            switch (action)
            {
                case sql_push_type.insert:
                    {
                        sql_query.InsertCommand = new SqlCommand(sql, conn);
                        sql_query.InsertCommand.ExecuteNonQuery();
                    }
                    break;
                case sql_push_type.delete:
                    {
                        sql_query.DeleteCommand = new SqlCommand(sql, conn);
                        sql_query.DeleteCommand.ExecuteNonQuery();
                    }
                    break;
                case sql_push_type.update:
                    {
                        sql_query.UpdateCommand = new SqlCommand(sql, conn);
                        sql_query.UpdateCommand.ExecuteNonQuery();
                    }
                    break;
            }

        }
    }
}
