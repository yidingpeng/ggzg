using MySql.Data.MySqlClient;
using RW.PMS.IDAL;
using RW.PMS.Model.graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.DAL
{
    public class DAL_Graph : IDAL_Graph
    {
        public int AddGraphData(GraphModel model)
        {
            var datetime = (new DAL_BaseInfo()).GetServerDateTime();
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"insert into graph_data(dateTime,torque,angle,graphName) 
                                    values(@dateTime,@torque,@angle,@graphName)";
            pList.Add(new MySqlParameter("@dateTime", model.dateTime));
            pList.Add(new MySqlParameter("@torque", model.torque));
            pList.Add(new MySqlParameter("@angle", model.angle));
            pList.Add(new MySqlParameter("@graphName", model.graphName));

            return db.ExecuteNonQuery(sql, pList.ToArray());

        }
    }
}
