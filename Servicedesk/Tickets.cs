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
        public string ShortDiscription { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int OpenBy { get; set; }
        public int HandledBy { get; set; }

        private static readonly Column[] columns = {
            new Column("TicketNumber", ColumnType.PRIMARY_KEY),
            new Column("ShortDiscription",ColumnType.STRING),
            new Column("Type",ColumnType.STRING),
            new Column("Status",ColumnType.STRING),
            new Column("OpenBy",ColumnType.INT),
            new Column("HandledBy",ColumnType.INT),
        };

        protected override Column[] Columns => columns;

        protected override string TableName => "TicketData";

        protected override Column PrimaryKey => Columns[0];

        public List<Tickets> GetTickets()
        {
            return GetList<Tickets>(dr => new Tickets() {
                TicketNumber = dr.GetInt32(0),
                Type = dr.GetStringOrNull(1),
                ShortDiscription = dr.GetStringOrNull(2),
                Status = dr.GetStringOrNull(3),
                OpenBy = dr.GetInt32(4),
                HandledBy = dr.GetInt32(5),
            });
        }
    }
}
