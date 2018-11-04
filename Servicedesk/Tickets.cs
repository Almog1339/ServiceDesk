using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Servicedesk
{
    public class Tickets : DatabaseEntity
    {
        public int TicketNumber { get; set; }
        public string Type { get; set; }
        public string ShortDescription { get; set; }
        public string Status { get; set; }
        public int OpenBy { get; set; }
        public int HandledBy { get; set; }
        //  public string Priority { get; set; }

        private static readonly Column[] columns = {
            new Column("TicketNumber", ColumnType.PRIMARY_KEY),
            new Column("ShortDescription",ColumnType.STRING),
            new Column("Type",ColumnType.STRING),
            new Column("Status",ColumnType.STRING),
            new Column("OpenBy",ColumnType.INT),
            new Column("HandledBy",ColumnType.INT),
          //  new Column("Priority",ColumnType.INT),
        };

        protected override Column[] Columns => columns;

        protected override string TableName => "TicketData";

        protected override Column PrimaryKey => Columns[0];

        public List<Tickets> GetTickets()
        {
            return GetList(dr => new Tickets() {
                TicketNumber = dr.GetInt32(0),
                Type = dr.GetString(1),
                ShortDescription = dr.GetString(2),
                Status = dr.GetString(3),
                OpenBy = dr.GetInt32(4),
                HandledBy = dr.GetInt32(5),
                // Priority = dr.GetInt32(6),

            });
        }

        public List<Tickets> NewIncident()
        {
            return GetList(dr => new Tickets() {
                TicketNumber = dr.GetInt32(0),
                Type = dr.GetString(1),
                ShortDescription = dr.GetString(2),
                Status = dr.GetString(3),
                OpenBy = dr.GetInt32(4),
                HandledBy = dr.GetInt32(5),
                // Priority = dr.GetInt32(6),

            });
        }



        private List<SqlParameter> GetSqlParameters(bool withTicketNumber = true)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (withTicketNumber)
                parameters.Add(new SqlParameter("@TicketNumber", TicketNumber));
            parameters.Add(new SqlParameter("@Type", Type));
            parameters.Add(new SqlParameter("@ShortDescription", ShortDescription));
            parameters.Add(new SqlParameter("@Status", Status));
            parameters.Add(new SqlParameter("@OpenBy", OpenBy));
            parameters.Add(new SqlParameter("@HandledBy", HandledBy));
            //  parameters.Add(new SqlParameter("@Priority", Priority));

            foreach (SqlParameter param in parameters) {
                if (param.Value == null) {
                    param.Value = DBNull.Value;
                }
            }
            return parameters;
        }

    }
}
    

